namespace FsUnit.Test

open Xunit
open Xunit.Sdk
open FsUnit.Xunit
open FsUnitTyped

type ``be subsetOf tests``() =

    [<Fact>]
    member _.``5, 3 and 8 should be subset of 1 to 10``() =
        [ 5; 3; 8 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member _.``5 should be subset of 1 to 10``() =
        [ 5 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member _.``4 to 8 should be subset of 1 to 10``() =
        { 4..8 } |> should be (subsetOf { 1..10 })

    [<Fact>]
    member _.``1 to 10 should be subset of 4, 1 and 7``() =
        [| 1..10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<Fact>]
    member _.``5, 1 and 11 should not be subset of 1 to 10``() =
        [ 5; 1; 11 ] |> should not' (be subsetOf [| 1..10 |])

    [<Fact>]
    member _.``1 to 10 should not be subset of 5``() =
        [ 1..10 ] |> should not' (be subsetOf [ 5 ])

    [<Fact>]
    member _.``1 to 10 should be subset of 1 to 10``() =
        [ 1..10 ] |> should be (subsetOf [ 1..10 ])

    [<Fact>]
    member _.``should fail on '1 to 11 should be subset of 1 to 10' and check if it's EqualException``() =
        shouldFail<EqualException>(fun () -> [ 1..11 ] |> should be (subsetOf [ 1..10 ]))
