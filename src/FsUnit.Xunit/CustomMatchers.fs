module FsUnit.CustomMatchers

open System
open System.Collections
open System.Globalization
open NHamcrest
open NHamcrest.Core
open System.Reflection

let equal expected =
    CustomMatcher<obj>($"Equals %A{expected}", (fun actual -> expected = actual))

let equalSeq (func: seq<'a> -> seq<'a> -> unit) (expected: seq<'a>) =
    let matches(actual: obj) =
        try
            func expected (unbox(actual))
            true
        with _ ->
            false

    CustomMatcher<obj>($"Equals %A{expected}", Func<_, _> matches)

let equivalent f expected =
    let matches(actual: obj) =
        try
            let toCollection o =
                o |> Seq.cast |> Seq.toArray :> ICollection

            match actual with
            | :? IEnumerable as e ->
                f (toCollection expected) (toCollection e)
                true
            | _ -> false
        with _ ->
            false

    CustomMatcher<obj>($"Equivalent to %A{expected}", Func<_, _> matches)

let equalWithin (tolerance: obj) (expected: obj) =
    let matches(actual: obj) =
        let parseValue(v: string) =
            match Double.TryParse(v, NumberStyles.Any, CultureInfo("en-US")) with
            | true, x -> Some(x)
            | false, _ -> None

        let actual = string actual |> parseValue
        let expect = string expected |> parseValue
        let tol = string tolerance |> parseValue

        if [| actual; expect; tol |] |> Array.contains None |> not then
            abs(actual.Value - expect.Value) <= tol.Value
        else
            false

    CustomMatcher<obj>($"%A{expected} with a tolerance of %A{tolerance}", Func<_, _> matches)

let not'(x: obj) =
    match box x with
    | null -> Is.Not<obj>(Is.Null())
    | :? IMatcher<obj> as matcher -> Is.Not<obj>(matcher)
    | x -> Is.Not<obj>(CustomMatcher<obj>($"Equals %A{x}", (fun a -> a = x)) :> IMatcher<obj>)

let throw(t: Type) =
    let matches(f: obj) =
        let wrap testFunc =
            try
                testFunc()
                false
            with ex ->
                t.IsAssignableFrom(ex.GetType())

        match f with
        | :? (unit -> unit) as testFunc -> wrap testFunc
        | :? (unit -> obj) as testFunc -> wrap(testFunc >> ignore)
        | _ -> false

    CustomMatcher<obj>(string t, Func<_, _> matches)

let throwWithMessage (m: string) (t: Type) =
    let matches(f: obj) =
        let wrap testFunc =
            try
                testFunc()
                false
            with ex ->
                ex.GetType() = t && ex.Message = m

        match f with
        | :? (unit -> unit) as testFunc -> wrap testFunc
        | :? (unit -> obj) as testFunc -> wrap(testFunc >> ignore)
        | _ -> false

    CustomMatcher<obj>($"{string t} \"{m}\"", Func<_, _> matches)

let be = id

let Null = Is.Null()

let Empty =
    let matches(o: obj) =
        match o with
        | :? IEnumerable as e -> e |> Seq.cast |> Seq.isEmpty
        | _ -> false

    CustomMatcher<obj>("A non empty", Func<_, _> matches)

let EmptyString =
    CustomMatcher<obj>("A non empty string", (fun s -> (string s).Trim() = ""))

let NullOrEmptyString =
    CustomMatcher<obj>("A not empty or not null string", (fun s -> String.IsNullOrEmpty(unbox s)))

let True = CustomMatcher<obj>("True", (fun b -> unbox b = true))

let False = CustomMatcher<obj>("False", (fun b -> unbox b = false))

let NaN =
    let matches(actual: obj) =
        match actual with
        | :? single as s -> Single.IsNaN(s)
        | :? double as d -> Double.IsNaN(d)
        | _ -> false

    CustomMatcher<obj>("NaN", Func<_, _> matches)

let unique =
    let matches(actual: obj) =
        match actual with
        | :? IEnumerable as e ->
            let isAllItemsUnique x =
                let y = Seq.distinct x
                Seq.length x = Seq.length y

            e |> Seq.cast |> isAllItemsUnique
        | _ -> false

    CustomMatcher<obj>("All items unique", Func<_, _> matches)

let sameAs expected =
    Is.SameAs<obj>(expected)

let greaterThan(expected: obj) =
    let matches(actual: obj) =
        let comparable = unbox actual :> IComparable
        comparable.CompareTo(unbox expected) > 0

    CustomMatcher<obj>($"Greater than %A{expected}", Func<_, _> matches)

let greaterThanOrEqualTo(expected: obj) =
    let matches(actual: obj) =
        let comparable = unbox actual :> IComparable
        comparable.CompareTo(unbox expected) >= 0

    CustomMatcher<obj>($"Greater than or equal to %A{expected}", Func<_, _> matches)

let lessThan(expected: obj) =
    let matches(actual: obj) =
        let comparable = unbox actual :> IComparable
        comparable.CompareTo(unbox expected) < 0

    CustomMatcher<obj>($"Less than %A{expected}", Func<_, _> matches)

let lessThanOrEqualTo(expected: obj) =
    let matches(actual: obj) =
        let comparable = unbox actual :> IComparable
        comparable.CompareTo(unbox expected) <= 0

    CustomMatcher<obj>($"Less than or equal to %A{expected}", Func<_, _> matches)

let endWith(expected: string) =
    CustomMatcher<obj>(string expected, (fun s -> (string s).EndsWith expected))

let startWith(expected: string) =
    CustomMatcher<obj>(string expected, (fun s -> (string s).StartsWith expected))

let haveSubstring(expected: string) =
    CustomMatcher<obj>(string expected, (fun s -> (string s).Contains expected))

let ofExactType<'a> =
    CustomMatcher<obj>(typeof<'a>.ToString(), (fun x -> (unbox x).GetType() = typeof<'a>))

let instanceOfType<'a> =
    CustomMatcher<obj>(typeof<'a>.ToString(), (fun x -> typeof<'a>.IsInstanceOfType(x)))

let contain expected =
    let matches(actual: obj) =
        match actual with
        | :? list<_> as l -> l |> List.exists((=) expected)
        | :? array<_> as a -> a |> Array.exists((=) expected)
        | :? seq<_> as s -> s |> Seq.exists((=) expected)
        | :? IEnumerable as e -> e |> Seq.cast |> Seq.exists((=) expected)
        | _ -> false

    CustomMatcher<obj>($"Contains %A{expected}", Func<_, _> matches)

let private (?) (this: 'Source) (name: string) : 'Result =
    let bindingFlags =
        BindingFlags.Public
        ||| BindingFlags.NonPublic
        ||| BindingFlags.Instance
        ||| BindingFlags.GetProperty

    let property = this.GetType().GetProperty(name, bindingFlags)

    if isNull property then
        raise(ArgumentException($"Property {name} was not found", "name"))

    property.GetValue(this, null) :?> 'Result

let haveLength expected =
    CustomMatcher<obj>($"Have Length %d{expected}", (fun x -> x?Length = expected))

let haveCount expected =
    CustomMatcher<obj>($"Have Count %d{expected}", (fun x -> x?Count = expected))

let supersetOf expected =
    CustomMatcher<obj>($"Is superset of %A{expected}", (fun c -> Set.isSuperset (Set(unbox c)) (Set expected)))

let subsetOf expected =
    CustomMatcher<obj>($"Is subset of %A{expected}", (fun c -> Set.isSubset (Set(unbox c)) (Set expected)))

let matchList xs =
    let matches(ys: obj) =
        match ys with
        | :? list<_> as ys' -> List.sort xs = List.sort ys'
        | :? IEnumerable as e -> e |> Seq.cast |> Seq.isEmpty && xs |> Seq.isEmpty
        | _ -> false

    CustomMatcher<obj>($"All elements from list %A{xs}", Func<_, _> matches)

let private makeOrderedMatcher description comparer =
    let matches(actual: obj) =
        match actual with
        | :? list<IComparable> as l -> l = List.sortWith comparer l
        | :? array<IComparable> as a -> a = Array.sortWith comparer a
        | :? seq<IComparable> as s ->
            let a = s |> Seq.toArray
            a = (a |> Array.sortWith comparer)
        | :? IEnumerable as e ->
            let a = e |> Seq.cast |> Seq.toArray
            a = (a |> Array.sortWith comparer)
        | _ -> false

    CustomMatcher<obj>(description, Func<_, _> matches)

let ascending = makeOrderedMatcher "Ascending" compare

let descending = makeOrderedMatcher "Descending" (fun a b -> -(compare a b))

type ChoiceDiscriminator(n: int) =

    member this.check(c: Choice<'a, 'b>) : bool =
        match c with
        | Choice1Of2 _ -> n = 1
        | Choice2Of2 _ -> n = 2

    member this.check(c: Choice<'a, 'b, 'c>) : bool =
        match c with
        | Choice1Of3 _ -> n = 1
        | Choice2Of3 _ -> n = 2
        | Choice3Of3 _ -> n = 3

    member this.check(c: Choice<'a, 'b, 'c, 'd>) : bool =
        match c with
        | Choice1Of4 _ -> n = 1
        | Choice2Of4 _ -> n = 2
        | Choice3Of4 _ -> n = 3
        | Choice4Of4 _ -> n = 4

    member this.check(c: Choice<'a, 'b, 'c, 'd, 'e>) : bool =
        match c with
        | Choice1Of5 _ -> n = 1
        | Choice2Of5 _ -> n = 2
        | Choice3Of5 _ -> n = 3
        | Choice4Of5 _ -> n = 4
        | Choice5Of5 _ -> n = 5

    member this.check(c: Choice<'a, 'b, 'c, 'd, 'e, 'f>) : bool =
        match c with
        | Choice1Of6 _ -> n = 1
        | Choice2Of6 _ -> n = 2
        | Choice3Of6 _ -> n = 3
        | Choice4Of6 _ -> n = 4
        | Choice5Of6 _ -> n = 5
        | Choice6Of6 _ -> n = 6

    member this.check(c: Choice<'a, 'b, 'c, 'd, 'e, 'f, 'g>) : bool =
        match c with
        | Choice1Of7 _ -> n = 1
        | Choice2Of7 _ -> n = 2
        | Choice3Of7 _ -> n = 3
        | Choice4Of7 _ -> n = 4
        | Choice5Of7 _ -> n = 5
        | Choice6Of7 _ -> n = 6
        | Choice7Of7 _ -> n = 7

    member this.check(c: obj) : bool =
        let cArgs = c.GetType().GetGenericArguments()
        let cArgCount = Seq.length cArgs

        try
            this.GetType().GetMethods()
            |> Seq.filter(fun m -> m.Name = "check" && Seq.length(m.GetGenericArguments()) = cArgCount)
            |> Seq.exists(fun m -> m.MakeGenericMethod(cArgs).Invoke(this, [| c |]) :?> bool)
        with _ ->
            false

let choice n =
    CustomMatcher<obj>($"The choice %d{n}", (fun x -> ChoiceDiscriminator(n).check(x)))

let inRange min max =
    let matches(actual: obj) =
        let unboxed = (unbox actual :> IComparable)
        unboxed.CompareTo(unbox min) >= 0 && unboxed.CompareTo(unbox max) <= 0

    CustomMatcher<obj>($"In range from %A{min} to %A{max}", Func<_, _> matches)

let ofCase(case: Quotations.Expr) =
    let expected =
        defaultArg (Common.caseName case) "<The given type is not a union case and the matcher won't work.>"

    let matcher = CustomMatcher(expected, (fun x -> x |> Common.isOfCase case))

    matcher
