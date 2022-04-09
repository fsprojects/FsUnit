namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be supersetOf tests``() =

    [<Test>]
    member _.``1 to 10 should be superset of 5, 3 and 8``() =
        [ 1..10 ] |> should be (supersetOf [ 5; 3; 8 ])

    [<Test>]
    member _.``1 to 10 should be superset of 5``() =
        [ 1..10 ] |> should be (supersetOf [ 5 ])

    [<Test>]
    member _.``1 to 10 should be superset of 4 to 8``() =
        { 1..10 } |> should be (supersetOf { 4..8 })

    [<Test>]
    member _.``1 to 10 should be superset of 4, 1 and 7``() =
        [| 1..10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<Test>]
    member _.``1 to 10 should not be superset of 5, 1 and 11``() =
        [ 1..10 ] |> should not' (be supersetOf [ 5; 1; 11 ])

    [<Test>]
    member _.``5 should not be superset of 1 to 10``() =
        [ 5 ] |> should not' (be supersetOf [ 1..10 ])

    [<Test>]
    member _.``1 to 10 should be superset of 1 to 10``() =
        [ 1..10 ] |> should be (supersetOf [ 1..10 ])

    [<Test>]
    member _.``should fail on '1 to 10 should be superset of 1 to 11'``() =
        shouldFail(fun () -> [ 1..10 ] |> should be (supersetOf [ 1..11 ]))
