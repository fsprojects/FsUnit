namespace FsUnit.Test

open System.Collections
open System.Collections.Immutable

open NUnit.Framework
open FsUnit
open System

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1


type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1


[<TestFixture>]
type ``equal Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Test>]
    member __.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<Test>]
    member __.``collection type should equal collection``() =
        [ 1 .. 10 ] |> should equal [ 1 .. 10 ]

    [<Test>]
    member __.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<Test>]
    member __.``list type should equivalent collection ``() =
        [ 1 .. 10 ] |> should equivalent [ 1 .. 10 ]

    [<Test>]
    member __.``list type should equal equivalent independent of order``() =
        [ 1; 2; 3 ] |> should equivalent [ 3; 2; 1 ]

    [<Test>]
    member __.``sequence should equal equivalent independent of order``() =
        { 1 .. 10 } |> should equivalent { 10 .. -1 .. 1 }

    [<Test>]
    member __.``collection should fail on '1 to 10 should not equivalent of 1 to 10'``() =
        shouldFail(fun () -> [ 1 .. 10 ] |> should not' (equivalent [ 1 .. 10 ]))

    [<Test>]
    member __.``array should equal equivalent independent of order``() =
        [| 1; 4; 8 |] |> should equivalent [| 4; 8; 1 |]

    [<Test>]
    member __.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> should equal 2)

    [<Test>]
    member __.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<Test>]
    member __.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> should not' (equal 1))

    [<Test>]
    member __.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<Test>]
    member __.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> should equal otherObj)

    [<Test>]
    member __.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<Test>]
    member __.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> should not' (equal anObj))

    [<Test>]
    member __.``should pass when Equals returns true``() =
        anObj |> should equal (new AlwaysEqual())

    [<Test>]
    member __.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> should equal (new NeverEqual()))

    [<Test>]
    member __.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(new NeverEqual()))

    [<Test>]
    member __.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> should not' (equal(new AlwaysEqual())))

    [<Test>]
    member __.``None should equal None``() =
        None |> should equal None

    [<Test>]
    member __.``Ok "ok" should equal Ok "no" should fail but message should be equal``() =
        (fun () -> [ Ok "ok" ] |> should equal [ Ok "no" ])
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should equal (sprintf "  Expected: [Ok \"no\"] or [Ok \"no\"]%s  But was:  [Ok \"ok\"]%s" Environment.NewLine Environment.NewLine)

    [<Test>]
    member __.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<Test>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)
