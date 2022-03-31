namespace FsUnit.Typed.Test

open System.Collections.Immutable

open Xunit
open FsUnitTyped
open FsUnit
open System

type AlwaysEqual() =
    override __.Equals(other) = true
    override __.GetHashCode() = 1

type NeverEqual() =
    override __.Equals(other) = false
    override __.GetHashCode() = 1

type ``shouldEqual Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Fact>]
    member __.``value type should equal equivalent value``() =
        1 |> shouldEqual 1

    [<Fact>]
    member __.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> shouldEqual 2)

    [<Fact>]
    member __.``value type should not equal nonequivalent value``() =
        1 |> shouldNotEqual 2

    [<Fact>]
    member __.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> shouldNotEqual 1)

    [<Fact>]
    member __.``reference type should equal itself``() =
        anObj |> shouldEqual anObj

    [<Fact>]
    member __.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> shouldEqual otherObj)

    [<Fact>]
    member __.``reference type should not equal other``() =
        anObj |> shouldNotEqual otherObj

    [<Fact>]
    member __.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> shouldNotEqual anObj)

    [<Fact>]
    member __.``should pass when Equals returns true``() =
        anObj |> shouldEqual(box(new AlwaysEqual()))

    [<Fact>]
    member __.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> shouldEqual(box(new NeverEqual())))

    [<Fact>]
    member __.``should pass when negated and Equals returns false``() =
        anObj |> shouldNotEqual(box(new NeverEqual()))

    [<Fact>]
    member __.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> shouldNotEqual(box(new AlwaysEqual())))

    [<Fact>]
    member __.``None should equal None``() =
        None |> shouldEqual None

    [<Fact>]
    member __.``Error "Foo" should equal Error "Foo"``() =
        Error "Foo" |> shouldEqual(Error "Foo")

    [<Fact>]
    member __.``Error "Foo" should equal fails and have same message``() =
        (fun () -> Error "Foo" |> shouldEqual(Error "Bar"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                   (sprintf "  Expected: Error \"Bar\" or Error \"Bar\"%s  But was:  Error \"Foo\"%s" Environment.NewLine Environment.NewLine)

    [<Fact>]
    member __.``Error "Foo" should not equal Error "Bar"``() =
        Error "Foo" |> shouldNotEqual(Error "Bar")

    [<Fact>]
    member __.``Error "Foo" should not equal Error "Bar" fails and have same message``() =
        (fun () -> Error "Foo" |> shouldNotEqual(Error "Foo"))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                   (sprintf "  Expected: not Error \"Foo\" or Error \"Foo\"%s  But was:  Error \"Foo\"%s" Environment.NewLine Environment.NewLine)

    [<Fact>]
    member this.``structural equality``() =
        let actualList: char list = []
        [ (actualList, "") ] |> shouldEqual [ ([], "") ]

    [<Fact>]
    member __.``Empty obj list should match itself``() =
        [] |> shouldEqual []

    [<Fact>]
    member __.``List with elements should not match empty list``() =
        [ 1 ] |> shouldNotEqual []

    [<Fact>]
    member __.``structural value type should equal equivalent value``() =
        anImmutableArray |> shouldEqual equivalentImmutableArray

    [<Fact>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> shouldNotEqual otherImmutableArray

    [<Fact>]
    member __.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 =
            ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 =
            ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> shouldEqual array2)
