namespace FsUnit.Typed.Test

open System.Collections.Immutable

open NUnit.Framework
open FsUnitTyped
open FsUnit
open System

type AlwaysEqual() =
    override __.Equals(other) = true
    override __.GetHashCode() = 1

type NeverEqual() =
    override __.Equals(other) = false
    override __.GetHashCode() = 1

[<TestFixture>]
type ``shouldEqual Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Test>]
    member __.``value type should equal equivalent value``() =
        1 |> shouldEqual 1

    [<Test>]
    member __.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> shouldEqual 2)

    [<Test>]
    member __.``value type should not equal nonequivalent value``() =
        1 |> shouldNotEqual 2

    [<Test>]
    member __.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> shouldNotEqual 1)

    [<Test>]
    member __.``reference type should equal itself``() =
        anObj |> shouldEqual anObj

    [<Test>]
    member __.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> shouldEqual otherObj)

    [<Test>]
    member __.``reference type should not equal other``() =
        anObj |> shouldNotEqual otherObj

    [<Test>]
    member __.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> shouldNotEqual anObj)

    [<Test>]
    member __.``should pass when Equals returns true``() =
        anObj |> shouldEqual(box(new AlwaysEqual()))

    [<Test>]
    member __.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> shouldEqual(box(new NeverEqual())))

    [<Test>]
    member __.``should pass when negated and Equals returns false``() =
        anObj |> shouldNotEqual(box(new NeverEqual()))

    [<Test>]
    member __.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> shouldNotEqual(box(new AlwaysEqual())))

    [<Test>]
    member __.``None should equal None``() =
        None |> shouldEqual None

    [<Test>]
    member __.``Error "Foo" should equal Error "Foo"``() =
        Error "Foo" |> shouldEqual(Error "Foo")

    [<Test>]
    member __.``Error "Foo" should equal fails and have same message``() =
        (fun () -> Error "Foo" |> shouldEqual(Error "Bar"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                   (sprintf "  Expected: Error \"Bar\" or Error \"Bar\"%s  But was:  Error \"Foo\"%s" Environment.NewLine Environment.NewLine)

    [<Test>]
    member __.``Error "Foo" should not equal Error "Bar"``() =
        Error "Foo" |> shouldNotEqual(Error "Bar")

    [<Test>]
    member __.``Error "Foo" should not equal Error "Bar" fails and have same message``() =
        (fun () -> Error "Foo" |> shouldNotEqual(Error "Foo"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                   (sprintf "  Expected: not Error \"Foo\" or Error \"Foo\"%s  But was:  Error \"Foo\"%s" Environment.NewLine Environment.NewLine)

    [<Test>]
    member this.``structural equality``() =
        let actualList: char list = []
        [ (actualList, "") ] |> shouldEqual [ ([], "") ]

    [<Test>]
    member __.``Empty obj list should match itself``() =
        [] |> shouldEqual []

    [<Test>]
    member __.``List with elements should not match empty list``() =
        [ 1 ] |> shouldNotEqual []

    [<Test>]
    member __.``structural value type should equal equivalent value``() =
        anImmutableArray |> shouldEqual equivalentImmutableArray

    [<Test>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> shouldNotEqual otherImmutableArray

    [<Test>]
    member __.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("http://example.com/1"))
        let array2 = ImmutableArray.Create(Uri("http://example.com/2"))

        shouldFail(fun () -> array1 |> shouldEqual array2)
