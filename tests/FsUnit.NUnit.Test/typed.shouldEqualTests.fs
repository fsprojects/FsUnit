namespace FsUnit.Typed.Test

open System.Collections.Immutable

open NUnit.Framework
open FsUnitTyped
open FsUnit
open System

type AlwaysEqual() =
    override _.Equals(other) = true
    override _.GetHashCode() = 1

type NeverEqual() =
    override _.Equals(other) = false
    override _.GetHashCode() = 1

type CommitMessage = { Type: string }

[<TestFixture>]
type ``shouldEqual Tests``() =

    let anObj = obj()
    let otherObj = obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    let sformat (formattableString: string) (argument: string) =
        String.Format(formattableString, argument)

    [<Test>]
    member _.``value type should equal equivalent value``() =
        1 |> shouldEqual 1

    [<Test>]
    member _.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> shouldEqual 2)

    [<Test>]
    member _.``value type should not equal nonequivalent value``() =
        1 |> shouldNotEqual 2

    [<Test>]
    member _.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> shouldNotEqual 1)

    [<Test>]
    member _.``reference type should equal itself``() =
        anObj |> shouldEqual anObj

    [<Test>]
    member _.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> shouldEqual otherObj)

    [<Test>]
    member _.``reference type should not equal other``() =
        anObj |> shouldNotEqual otherObj

    [<Test>]
    member _.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> shouldNotEqual anObj)

    [<Test>]
    member _.``should pass when Equals returns true``() =
        anObj |> shouldEqual(box(AlwaysEqual()))

    [<Test>]
    member _.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> shouldEqual(box(NeverEqual())))

    [<Test>]
    member _.``should pass when negated and Equals returns false``() =
        anObj |> shouldNotEqual(box(NeverEqual()))

    [<Test>]
    member _.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> shouldNotEqual(box(AlwaysEqual())))

    [<Test>]
    member _.``null should be null``() =
        null |> shouldEqual null

    [<Test>]
    member _.``null should fail to not be null``() =
        shouldFail(fun () -> null |> shouldNotEqual null)

    [<Test>]
    member _.``None should equal None``() =
        None |> shouldEqual None

    [<Test>]
    member _.``Error "Foo" should equal Error "Foo"``() =
        Error "Foo" |> shouldEqual(Error "Foo")

    [<Test>]
    member _.``Ok should infer the error type from the expected Result``() =
        let expected: Result<_, string> = Ok { Type = "feat" }
        Ok { Type = "feat" } |> shouldEqual expected

    [<Test>]
    member _.``Error should infer the success type from the expected Result``() =
        let expected: Result<CommitMessage, _> = Error "invalid"
        Error "invalid" |> shouldEqual expected

    [<Test>]
    member _.``Result with inferred error type should fail for a different payload``() =
        let expected: Result<_, string> = Ok { Type = "feat" }

        (fun () -> Ok { Type = "fix" } |> shouldEqual expected)
        |> Assert.Throws<AssertionException>
        |> ignore

    [<Test>]
    member _.``Result with inferred error type should fail for a different case``() =
        let expected: Result<_, string> = Ok { Type = "feat" }

        (fun () -> Error "invalid" |> shouldEqual expected)
        |> Assert.Throws<AssertionException>
        |> ignore

    [<Test>]
    member _.``Error "Foo" should equal fails and have same message``() =
        (fun () -> Error "Foo" |> shouldEqual(Error "Bar"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                (sformat "  Assert.That(, ){0}  Expected: Error \"Bar\" or Error \"Bar\"{0}  But was:  Error \"Foo\"{0}" Environment.NewLine)

    [<Test>]
    member _.``Error "Foo" should not equal Error "Bar"``() =
        Error "Foo" |> shouldNotEqual(Error "Bar")

    [<Test>]
    member _.``Error "Foo" should not equal Error "Bar" fails and have same message``() =
        (fun () -> Error "Foo" |> shouldNotEqual(Error "Foo"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                (sformat "  Assert.That(, ){0}  Expected: not Error \"Foo\" or Error \"Foo\"{0}  But was:  Error \"Foo\"{0}" Environment.NewLine)

    [<Test>]
    member this.``structural equality``() =
        let actualList: char list = []
        [ (actualList, "") ] |> shouldEqual [ ([], "") ]

    [<Test>]
    member _.``Empty obj list should match itself``() =
        [] |> shouldEqual []

    [<Test>]
    member _.``List with elements should not match empty list``() =
        [ 1 ] |> shouldNotEqual []

    [<Test>]
    member _.``structural value type should equal equivalent value``() =
        anImmutableArray |> shouldEqual equivalentImmutableArray

    [<Test>]
    member _.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> shouldNotEqual otherImmutableArray

    [<Test>]
    member _.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> shouldEqual array2)
