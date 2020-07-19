namespace FsUnit.Typed.Test

open System.Collections.Immutable

open NUnit.Framework
open FsUnitTyped

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1


type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1


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
        anImmutableArray
        |> shouldEqual equivalentImmutableArray

    [<Test>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray
        |> shouldNotEqual otherImmutableArray
