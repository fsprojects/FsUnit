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
type ``equal Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<TestMethod>]
    member __.``value type should equal equivalent value``() =
        1 |> should equal 1

    [<TestMethod>]
    member __.``value type should fail to equal nonequivalent value``() =
        'f' |> should not' (equal 'F')

    [<TestMethod>]
    member __.``collection type should equal collection``() =
        [ 1 .. 10 ] |> should equal [ 1 .. 10 ]

    [<TestMethod>]
    member __.``collection type should not equal equivalent if is not in same order``() =
        [ 1; 2; 3 ] |> should not' (equal [ 3; 2; 1 ])

    [<TestMethod>]
    member __.``list should equivalent collection``() =
        [ 1 .. 10 ] |> should equivalent [ 1 .. 10 ]

    [<TestMethod>]
    member __.``list should equal equivalent independent of order``() =
        [ 1; 2; 3 ] |> should equivalent [ 3; 2; 1 ]

    [<TestMethod>]
    member __.``sequence should equal equivalent independent of order``() =
        { 1 .. 10 } |> should equivalent { 10 .. -1 .. 1 }

    [<TestMethod>]
    member __.``collection should fail on '1 to 10 should not equivalent of 1 to 10'``() =
        shouldFail(fun () -> [ 1 .. 10 ] |> should not' (equivalent [ 1 .. 10 ]))

    [<TestMethod>]
    member __.``array should equal equivalent independent of order``() =
        [| 1; 4; 8 |] |> should equivalent [| 4; 8; 1 |]

    [<TestMethod>]
    member __.``equivalent should fail on '[1..10] |> should equivalent []'``() =
        shouldFail(fun () -> [ 1 .. 10 ] |> should equivalent [])

    [<TestMethod>]
    member __.``value type should not equal nonequivalent value``() =
        1 |> should not' (equal 2)

    [<TestMethod>]
    member __.``value type should fail to not equal equivalent value``() =
        1 |> should equal 1

    [<TestMethod>]
    member __.``reference type should equal itself``() =
        anObj |> should equal anObj

    [<TestMethod>]
    member __.``reference type should fail to equal other``() =
        anObj |> should not' (equal otherObj)

    [<TestMethod>]
    member __.``reference type should not equal other``() =
        anObj |> should not' (equal otherObj)

    [<TestMethod>]
    member __.``reference type should fail to not equal itself``() =
        anObj |> should equal anObj

    [<TestMethod>]
    member __.``should fail when Equals returns false``() =
        anObj |> should not' (equal(new NeverEqual()))

    [<TestMethod>]
    member __.``should pass when negated and Equals returns false``() =
        anObj |> should not' (equal(new NeverEqual()))

    [<TestMethod>]
    member __.``None should equal None``() =
        None |> should equal None

    [<TestMethod>]
    member __.``Ok "foo" should fail on equal Ok "bar" but message should be equal``() =
        (fun () -> Ok "foo" |> should equal (Ok "bar"))
        |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
        |> fun e -> e.Message
        |> should equal ("Equals Ok \"bar\" was Ok \"foo\"")

    [<TestMethod>]
    member __.``structural value type should equal equivalent value``() =
        anImmutableArray |> should equal equivalentImmutableArray

    [<TestMethod>]
    member __.``structural value type should not equal non-equivalent value``() =
        anImmutableArray |> should not' (equal otherImmutableArray)

    [<TestMethod>]
    member __.``structural comparable type containing non-equivalent structural equatable type fails with correct exception``() =
        let array1 =
            ImmutableArray.Create(Uri("https://example.com/1"))

        let array2 =
            ImmutableArray.Create(Uri("https://example.com/2"))

        shouldFail(fun () -> array1 |> should equal array2)
