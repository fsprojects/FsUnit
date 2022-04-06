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
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Fact>]
    member __.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<Fact>]
    member __.``value type should fail to equal nonequivalent value``() =
        'f' |> should not' (equal 'F')

    [<Fact>]
    member __.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<Fact>]
    member __.``value type should fail to not equal equivalent value``() =
        1 |> should equal 1

    [<Fact>]
    member __.``collection type should equal collection``() =
        [ 1..10 ] |> should equal [ 1..10 ]

    [<Fact>]
    member __.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<Fact>]
    member __.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<Fact>]
    member __.``reference type should fail to equal other``() =
        anObj |> should not' (equal otherObj)

    [<Fact>]
    member __.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<Fact>]
    member __.``reference type should fail to not equal itself``() =
        anObj |> should equal anObj

    [<Fact>]
    member __.``should pass when Equals returns true``() =
        anObj |> should equal (box(new AlwaysEqual()))

    [<Fact>]
    member __.``should fail when Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<Fact>]
    member __.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<Fact>]
    member __.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> should not' (equal(box(AlwaysEqual()))))

    [<Fact>]
    member __.``should pass when comparing two lists that have the same values``() =
        [ 1 ] |> should equal [ 1 ]

    [<Fact>]
    member __.``should pass when comparing two arrays that have the same values``() =
        [| 1 |] |> should equal [| 1 |]

    [<Fact>]
    member __.``should pass when comparing two lists that do not have the same values``() =
        [ 1 ] |> should not' (equal [ 2 ])

    [<Fact>]
    member __.``should pass when comparing two arrays that do not have the same values``() =
        [| 1 |] |> should not' (equal [| 2 |])

    [<Fact>]
    member __.``None should equal None``() =
        None |> should equal None

    [<Fact>]
    member __.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<Fact>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)

    [<Fact>]
    member __.``Ok "foo" should fail on equal Ok "bar" but message should be equal``() =
        (fun () -> Ok "foo" |> should equal (Ok "bar"))
        |> fun f -> Assert.Throws<MatchException>(f)
        |> fun e -> (e.Expected, e.Actual)
        |> should equal ("Equals Ok \"bar\"", "Ok \"foo\"")

    [<Fact>]
    member __.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> should equal array2)
