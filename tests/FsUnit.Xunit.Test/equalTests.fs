namespace FsUnit.Test

open System
open System.Collections.Immutable

open Xunit
open FsUnit.Xunit

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1

type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

type ``equal Tests``() =
    let anObj = obj()
    let otherObj = obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Fact>]
    member _.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<Fact>]
    member _.``value type should fail to equal nonequivalent value``() =
        'f' |> should not' (equal 'F')

    [<Fact>]
    member _.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<Fact>]
    member _.``value type should fail to not equal equivalent value``() =
        1 |> should equal 1

    [<Fact>]
    member _.``collection type should equal collection``() =
        [ 1..10 ] |> should equal [ 1..10 ]

    [<Fact>]
    member _.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<Fact>]
    member _.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<Fact>]
    member _.``reference type should fail to equal other``() =
        anObj |> should not' (equal otherObj)

    [<Fact>]
    member _.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<Fact>]
    member _.``reference type should fail to not equal itself``() =
        anObj |> should equal anObj

    [<Fact>]
    member _.``should pass when Equals returns true``() =
        anObj |> should equal (box(AlwaysEqual()))

    [<Fact>]
    member _.``should fail when Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<Fact>]
    member _.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<Fact>]
    member _.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> should not' (equal(box(AlwaysEqual()))))

    [<Fact>]
    member _.``should pass when comparing two lists that have the same values``() =
        [ 1 ] |> should equal [ 1 ]

    [<Fact>]
    member _.``should pass when comparing two arrays that have the same values``() =
        [| 1 |] |> should equal [| 1 |]

    [<Fact>]
    member _.``should pass when comparing two lists that do not have the same values``() =
        [ 1 ] |> should not' (equal [ 2 ])

    [<Fact>]
    member _.``should pass when comparing two arrays that do not have the same values``() =
        [| 1 |] |> should not' (equal [| 2 |])

    [<Fact>]
    member _.``None should equal None``() =
        None |> should equal None

    [<Fact>]
    member _.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<Fact>]
    member _.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)

    [<Fact>]
    member _.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> should equal array2)
