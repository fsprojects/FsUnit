namespace FsUnit.Test

open System
open System.Collections.Immutable
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1

type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

[<TestClass>]
type ``equalTests``() =

    let anObj = obj()
    let otherObj = obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<TestMethod>]
    member _.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<TestMethod>]
    member _.``value type should fail to equal nonequivalent value``() =
        'f' |> should not' (equal 'F')

    [<TestMethod>]
    member _.``collection type should equal collection``() =
        [ 1..10 ] |> should equal [ 1..10 ]

    [<TestMethod>]
    member _.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<TestMethod>]
    member _.``list should equivalent collection``() =
        [ 1..10 ] |> should equivalent [ 1..10 ]

    [<TestMethod>]
    member _.``list should equal equivalent independent of order``() =
        [ 1; 2; 3 ] |> should equivalent [ 3; 2; 1 ]

    [<TestMethod>]
    member _.``sequence should equal equivalent independent of order``() =
        { 1..10 } |> should equivalent { 10..-1..1 }

    [<TestMethod>]
    member _.``collectionshouldfailon1to10shouldnotequivalentof1to10``() =
        shouldFail(fun () -> [ 1..10 ] |> should not' (equivalent [ 1..10 ]))

    [<TestMethod>]
    member _.``array should equal equivalent independent of order``() =
        [| 1; 4; 8 |] |> should equivalent [| 4; 8; 1 |]

    [<TestMethod>]
    member _.``equivalent should fail on [1..10] |> should equivalent []``() =
        shouldFail(fun () -> [ 1..10 ] |> should equivalent [])

    [<TestMethod>]
    member _.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<TestMethod>]
    member _.``value type should fail to not equal equivalent value``() =
        1 |> should equal 1

    [<TestMethod>]
    member _.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<TestMethod>]
    member _.``reference type should fail to equal other``() =
        anObj |> should not' (equal otherObj)

    [<TestMethod>]
    member _.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<TestMethod>]
    member _.``reference type should fail to not equal itself``() =
        anObj |> should equal anObj

    [<TestMethod>]
    member _.``should fail when Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<TestMethod>]
    member _.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(NeverEqual()))

    [<TestMethod>]
    member _.``None should equal None``() =
        None |> should equal None

    [<TestMethod>]
    member _.``Ok "foo" should fail on equal Ok "bar" but message should be equal``() =
        (fun () -> Ok "foo" |> should equal (Ok "bar"))
        |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
        |> fun e -> e.Message
        |> should equal ("Equals Ok \"bar\" was Ok \"foo\"")

    [<TestMethod>]
    member _.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<TestMethod>]
    member _.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)

    [<TestMethod>]
    member _.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 = ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 = ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> should equal array2)
