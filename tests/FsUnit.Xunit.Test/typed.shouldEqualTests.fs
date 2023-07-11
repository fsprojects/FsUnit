namespace FsUnit.Typed.Test

open System.Collections.Immutable

open FsUnit.Xunit
open Xunit
open Xunit.Sdk
open FsUnitTyped
open System

type AlwaysEqual() =
    override _.Equals(other) = true
    override _.GetHashCode() = 1

type NeverEqual() =
    override _.Equals(other) = false
    override _.GetHashCode() = 1

type ``shouldEqual Tests``() =
    let anObj = obj()
    let otherObj = obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Fact>]
    member _.``value type should equal equivalent value``() =
        1 |> shouldEqual 1

    [<Fact>]
    member _.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> shouldEqual 2)

    [<Fact>]
    member _.``value type should not equal nonequivalent value``() =
        1 |> shouldNotEqual 2

    [<Fact>]
    member _.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> shouldNotEqual 1)

    [<Fact>]
    member _.``reference type should equal itself``() =
        anObj |> shouldEqual anObj

    [<Fact>]
    member _.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> shouldEqual otherObj)

    [<Fact>]
    member _.``reference type should not equal other``() =
        anObj |> shouldNotEqual otherObj

    [<Fact>]
    member _.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> shouldNotEqual anObj)

    [<Fact>]
    member _.``should pass when Equals returns true``() =
        anObj |> shouldEqual(box(AlwaysEqual()))

    [<Fact>]
    member _.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> shouldEqual(box(NeverEqual())))

    [<Fact>]
    member _.``should pass when negated and Equals returns false``() =
        anObj |> shouldNotEqual(box(NeverEqual()))

    [<Fact>]
    member _.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> shouldNotEqual(box(AlwaysEqual())))

    [<Fact>]
    member _.``None should equal None``() =
        None |> shouldEqual None

    [<Fact>]
    member _.``Error "Foo" should equal Error "Foo"``() =
        Error "Foo" |> shouldEqual(Error "Foo")

    [<Fact>]
    member _.``Error "Foo" should equal fails and have same message``() =
        (fun () -> Error "Foo" |> shouldEqual(Error "Bar"))
        |> Assert.Throws<EqualException>
        |> fun e ->
            e.Message
            |> shouldEqual(
                sprintf
                    "Assert.Equal() Failure: Values differ%sExpected: Equals Error \"Bar\"%sActual:   Error \"Foo\""
                    Environment.NewLine
                    Environment.NewLine
            )

    [<Fact>]
    member _.``Error "Foo" should not equal Error "Bar"``() =
        Error "Foo" |> shouldNotEqual(Error "Bar")

    [<Fact>]
    member _.``Error "Foo" should not equal Error "Bar" fails and have same message``() =
        (fun () -> Error "Foo" |> shouldNotEqual(Error "Foo"))
        |> Assert.Throws<EqualException>
        |> fun e ->
            e.Message
            |> shouldEqual(
                sprintf
                    "Assert.Equal() Failure: Values differ%sExpected: not Equals Error \"Foo\"%sActual:   Error \"Foo\""
                    Environment.NewLine
                    Environment.NewLine
            )

    [<Fact>]
    member this.``structural equality``() =
        let actualList: char list = []
        [ (actualList, "") ] |> shouldEqual [ ([], "") ]

    [<Fact>]
    member _.``Empty obj list should match itself``() =
        [] |> shouldEqual []

    [<Fact>]
    member _.``List with elements should not match empty list``() =
        [ 1 ] |> shouldNotEqual []

    [<Fact>]
    member _.``structural value type should equal equivalent value``() =
        anImmutableArray |> shouldEqual equivalentImmutableArray

    [<Fact>]
    member _.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> shouldNotEqual otherImmutableArray

    [<Fact>]
    member _.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> shouldEqual array2)
