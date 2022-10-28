namespace FsUnit

open System.Diagnostics
open NUnit.Framework
open NUnit.Framework.Constraints
open CustomConstraints

[<AutoOpen>]
module TopLevelOperators =

    [<SetUpFixture>]
    type FSharpCustomMessageFormatter() =
        do TestContext.AddFormatter(ValueFormatterFactory(fun _ -> ValueFormatter(sprintf "%A")))

    let Null = NullConstraint()

    let Empty = EmptyConstraint()

    let EmptyString = EmptyStringConstraint()

    let NullOrEmptyString = OrConstraint(NullConstraint(), EmptyConstraint())

    let True = TrueConstraint()

    let False = FalseConstraint()

    let NaN = NaNConstraint()

    let unique = UniqueItemsConstraint()

    [<DebuggerNonUserCode>]
    let should (f: 'a -> #Constraint) x (actual: obj) =
        let expression = f x

        let y =
            match actual with
            | :? (unit -> unit) as testFunc -> box(TestDelegate(testFunc))
            | :? (unit -> obj) as testFunc -> box(TestDelegate(testFunc >> ignore))
            | _ -> actual

        if isNull(box expression) then
            Assert.That(y, Is.Null)
        else
            Assert.That(y, expression)

    let equal expected =
        Equality.IsEqualTo(expected)

    let equalSeq(expected: seq<'a>) =
        EqualConstraint(expected)

    let equivalent expected =
        CollectionEquivalentConstraint(expected)

    let equalWithin tolerance expected =
        equal(expected).Within tolerance

    let contain expected =
        ContainsConstraint(expected)

    let haveLength expected =
        Has.Length.EqualTo(expected)

    let haveCount expected =
        Has.Count.EqualTo(expected)

    let be = id

    let sameAs expected =
        SameAsConstraint(expected)

    let throw = Throws.TypeOf

    let throwWithMessage (expected: string) (t: System.Type) =
        Throws.TypeOf(t).And.Message.EqualTo(expected)

    let greaterThan expected =
        GreaterThanConstraint(expected)

    let greaterThanOrEqualTo expected =
        GreaterThanOrEqualConstraint(expected)

    let lessThan expected =
        LessThanConstraint(expected)

    let lessThanOrEqualTo expected =
        LessThanOrEqualConstraint(expected)

    let shouldFail(f: unit -> unit) =
        TestDelegate(f) |> should throw typeof<AssertionException>

    let endWith(expected: string) =
        EndsWithConstraint expected

    let startWith(expected: string) =
        StartsWithConstraint expected

    let haveSubstring(expected: string) =
        SubstringConstraint expected

    let ofExactType<'a> = ExactTypeConstraint(typeof<'a>)

    let instanceOfType<'a> = InstanceOfTypeConstraint(typeof<'a>)

    let ascending = Is.Ordered

    let descending = Is.Ordered.Descending

    let not' baseConstraint =
        if isNull(box baseConstraint) then
            NotConstraint(Null)
        else
            NotConstraint(baseConstraint)

    let inRange min max =
        RangeConstraint(min, max)

    let ofCase case =
        OfSameCaseConstraint(case)

    let supersetOf expected =
        CollectionSupersetConstraint(expected)

    let subsetOf expected =
        CollectionSubsetConstraint(expected)
