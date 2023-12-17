namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beSupersetOfTests``() =

    [<TestMethod>]
    member _.``[ 1..10 ] should be superset of [ 5; 3; 8 ]``() =
        [ 1..10 ] |> should be (supersetOf [ 5; 3; 8 ])

    [<TestMethod>]
    member _.``[ 1..10 ] should be superset of 5``() =
        [ 1..10 ] |> should be (supersetOf [ 5 ])

    [<TestMethod>]
    member _.``[ 1..10 ] should be superset of { 4..8 }``() =
        { 1..10 } |> should be (supersetOf { 4..8 })

    [<TestMethod>]
    member _.``[ 1..10 ] should be superset of [| 4; 1; 7 |]``() =
        [| 1..10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<TestMethod>]
    member _.``[ 1..10 ] should not be superset of [ 5; 1; 11 ]``() =
        [ 1..10 ] |> should not' (be supersetOf [ 5; 1; 11 ])

    [<TestMethod>]
    member _.``5 should not be superset of [ 1..10 ]``() =
        [ 5 ] |> should not' (be supersetOf [ 1..10 ])

    [<TestMethod>]
    member _.``1 to 10 should be superset of [ 1..10 ]``() =
        [ 1..10 ] |> should be (supersetOf [ 1..10 ])

    [<TestMethod>]
    member _.``should fail on "[ 1..10 ] should be superset of [ 1..11 ]"``() =
        shouldFail(fun () -> [ 1..10 ] |> should be (supersetOf [ 1..11 ]))
