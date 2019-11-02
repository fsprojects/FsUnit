// TODO : Add license header

namespace FsUnit

open System
open System.Diagnostics
open NUnit.Framework
open NUnit.Framework.Constraints
open CustomConstraints

//
[<AutoOpen>]
module TopLevelOperators =

    [<SetUpFixture>]
    type FSharpCustomMessageFormatter() =
      do TestContext.AddFormatter(
           ValueFormatterFactory(fun _ -> ValueFormatter(sprintf "%A")))

    let Null = NullConstraint()

    let Empty = EmptyConstraint()

    let EmptyString = EmptyStringConstraint()

    let NullOrEmptyString = OrConstraint(NullConstraint(), EmptyConstraint())

    let True = TrueConstraint()

    let False = FalseConstraint()

    let NaN = NaNConstraint()

    let unique = UniqueItemsConstraint()

    [<DebuggerNonUserCode>]
    let should (f : 'a -> #Constraint) x (y : obj) =
        let c = f x
        let y =
            match y with
            | :? (unit -> unit) -> box (TestDelegate(y :?> unit -> unit))
            | _ -> y
        if box c = null then
            Assert.That(y, Is.Null)
        else
            Assert.That(y, c)

    let equal x = EqualConstraint(x)

    let equalWithin tolerance x = equal(x).Within tolerance

    let contain x = ContainsConstraint(x)

    let haveLength n = Has.Length.EqualTo(n)

    let haveCount n = Has.Count.EqualTo(n)

    let be = id

    let sameAs x = SameAsConstraint(x)

    let throw = Throws.TypeOf

    let throwWithMessage (m:string) (t:System.Type) = Throws.TypeOf(t).And.Message.EqualTo(m)

    let greaterThan x = GreaterThanConstraint(x)

    let greaterThanOrEqualTo x = GreaterThanOrEqualConstraint(x)

    let lessThan x = LessThanConstraint(x)

    let lessThanOrEqualTo x = LessThanOrEqualConstraint(x)

    let shouldFail (f : unit -> unit) =
        TestDelegate(f) |> should throw typeof<AssertionException>

    let endWith (s:string) = EndsWithConstraint s

    let startWith (s:string) = StartsWithConstraint s

    let haveSubstring (s:string) = SubstringConstraint s

    let ofExactType<'a> = ExactTypeConstraint(typeof<'a>)

    let instanceOfType<'a> = InstanceOfTypeConstraint(typeof<'a>)

    let ascending = Is.Ordered

    let descending = Is.Ordered.Descending

    let not' x =
        if box x = null then NotConstraint(Null) else NotConstraint(x)

    let inRange min max = RangeConstraint(min, max)

    let ofCase case = OfSameCaseConstraint(case)

    let supersetOf x = CollectionSupersetConstraint(x)

    let subsetOf x = CollectionSubsetConstraint(x)