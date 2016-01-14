// TODO : Add license header

namespace FsUnit

open System
open NUnit.Framework
open NUnit.Framework.Constraints

/// F#-friendly formatting for otherwise the same equals behavior (%A instead of .ToString())
type EqualsConstraint(x:obj) =
  inherit EqualConstraint(x) with
    override this.WriteActualValueTo(writer: MessageWriter): unit =
      writer.WriteActualValue(sprintf "%A" this.actual)
    override this.WriteDescriptionTo(writer: MessageWriter): unit =
      writer.WritePredicate("equals")
      writer.WriteExpectedValue(sprintf "%A" x)
    override this.WriteMessage(writer: MessageWriter): unit =
      writer.WriteMessageLine(sprintf "Expected: %A, but was %A" x this.actual)

//
[<AutoOpen>]
module TopLevelOperators =
    let Null = NullConstraint()

    let Empty = EmptyConstraint()

    let EmptyString = EmptyStringConstraint()

    let NullOrEmptyString = OrConstraint(NullConstraint(), EmptyConstraint())

    let True = TrueConstraint()

    let False = FalseConstraint()

    let NaN = NaNConstraint()

    let unique = UniqueItemsConstraint()

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

    let equal x = EqualsConstraint(x)

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

    /// Deprecated operators. These will be removed in a future version of FsUnit.
    module FsUnitDeprecated =
        [<System.Obsolete>]
        let not x = not' x
