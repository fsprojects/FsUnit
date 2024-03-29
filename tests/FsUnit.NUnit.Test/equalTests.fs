namespace FsUnit.Test

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

    let anObj = obj()
    let otherObj = obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Test>]
    member _.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<Test>]
    member _.``collection type should equal collection``() =
        [ 1..10 ] |> should equal [ 1..10 ]

    [<Test>]
    member _.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<Test>]
    member _.``list type should equivalent collection ``() =
        [ 1..10 ] |> should equivalent [ 1..10 ]

    [<Test>]
    member _.``list type should equal equivalent independent of order``() =
        [ 1; 2; 3 ] |> should equivalent [ 3; 2; 1 ]

    [<Test>]
    member _.``sequence should equal equivalent independent of order``() =
        { 1..10 } |> should equivalent { 10..-1..1 }

    [<Test>]
    member _.``collection should fail on '1 to 10 should not equivalent of 1 to 10'``() =
        shouldFail(fun () -> [ 1..10 ] |> should not' (equivalent [ 1..10 ]))

    [<Test>]
    member _.``array should equal equivalent independent of order``() =
        [| 1; 4; 8 |] |> should equivalent [| 4; 8; 1 |]

    [<Test>]
    member _.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> 1 |> should equal 2)

    [<Test>]
    member _.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<Test>]
    member _.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> 1 |> should not' (equal 1))

    [<Test>]
    member _.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<Test>]
    member _.``reference type should fail to equal other``() =
        shouldFail(fun () -> anObj |> should equal otherObj)

    [<Test>]
    member _.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<Test>]
    member _.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> anObj |> should not' (equal anObj))

    [<Test>]
    member _.``should pass when Equals returns true``() =
        anObj |> should equal (AlwaysEqual())

    [<Test>]
    member _.``should fail when Equals returns false``() =
        shouldFail(fun () -> anObj |> should equal (NeverEqual()))

    [<Test>]
    member _.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<Test>]
    member _.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> anObj |> should not' (equal(AlwaysEqual())))

    [<Test>]
    member _.``None should equal None``() =
        None |> should equal None

    [<Test>]
    member _.``None should equal null``() =
        None |> should equal null

    [<Test>]
    member _.``Ok "ok" should equal Ok "no" should fail but message should be equal``() =
        (fun () -> [ Ok "ok" ] |> should equal [ Ok "no" ])
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should
                equal
                (String.Format("  Assert.That(, ){0}  Expected: [Ok \"no\"] or [Ok \"no\"]{0}  But was:  [Ok \"ok\"]{0}", Environment.NewLine))

    [<Test>]
    member _.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<Test>]
    member _.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)

    [<Test>]
    member _.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> should equal array2)
