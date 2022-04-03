namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be subsetOf tests``() =

    [<TestMethod>]
    member __.``5, 3 and 8 should be subset of 1 to 10``() =
        [ 5; 3; 8 ] |> should be (subsetOf [ 1..10 ])

    [<TestMethod>]
    member __.``5 should be subset of 1 to 10``() =
        [ 5 ] |> should be (subsetOf [ 1..10 ])

    [<TestMethod>]
    member __.``4 to 8 should be subset of 1 to 10``() =
        { 4..8 } |> should be (subsetOf { 1..10 })

    [<TestMethod>]
    member __.``1 to 10 should be subset of 4, 1 and 7``() =
        [| 1..10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<TestMethod>]
    member __.``5, 1 and 11 should not be subset of 1 to 10``() =
        [ 5; 1; 11 ] |> should not' (be subsetOf [| 1..10 |])

    [<TestMethod>]
    member __.``1 to 10 should not be subset of 5``() =
        [ 1..10 ] |> should not' (be subsetOf [ 5 ])

    [<TestMethod>]
    member __.``1 to 10 should be subset of 1 to 10``() =
        [ 1..10 ] |> should be (subsetOf [ 1..10 ])

    [<TestMethod>]
    member __.``should fail on '1 to 11 should be subset of 1 to 10'``() =
        shouldFail(fun () -> [ 1..11 ] |> should be (subsetOf [ 1..10 ]))

    [<TestMethod>]
    member __.``11 should not be subset of 1 to 10 but message should be equal``() =
        (fun () -> [ 11 ] |> should be (subsetOf [ 1..10 ]))
        |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
        |> fun e -> e.Message
        |> should equal ("Is subset of [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] was [11]")
