namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be subsetOf tests``() =

    [<Fact>]
    member __.``5, 3 and 8 should be subset of 1 to 10``() =
        [ 5; 3; 8 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member __.``5 should be subset of 1 to 10``() =
        [ 5 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member __.``4 to 8 should be subset of 1 to 10``() =
        { 4..8 } |> should be (subsetOf { 1..10 })

    [<Fact>]
    member __.``1 to 10 should be subset of 4, 1 and 7``() =
        [| 1..10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<Fact>]
    member __.``5, 1 and 11 should not be subset of 1 to 10``() =
        [ 5; 1; 11 ] |> should not' (be subsetOf [| 1..10 |])

    [<Fact>]
    member __.``1 to 10 should not be subset of 5``() =
        [ 1..10 ] |> should not' (be subsetOf [ 5 ])

    [<Fact>]
    member __.``1 to 10 should be subset of 1 to 10``() =
        [ 1..10 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member __.``should fail on '1 to 11 should be subset of 1 to 10'``() =
        shouldFail(fun () -> [ 1..11 ] |> should be (subsetOf [ 1..10 ]))

    [<Fact>]
    member __.``11 should not be subset of 1 to 10 but messages should equal``() =
        (fun _ -> [ 11 ] |> should be (subsetOf [ 1..10 ]))
        |> fun f -> Assert.Throws<MatchException>(f)
        |> fun e -> (e.Expected, e.Actual)
        |> should equal ("Is subset of [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]", "[11]")
