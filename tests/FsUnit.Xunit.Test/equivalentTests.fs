namespace FsUnit.Test

open System
open Xunit
open FsUnit.Xunit

module EquivalentTests =

    [<Fact>]
    let ``two lists with same elements in different order are equivalent``() =
        [ 1; 2; 3 ] |> should equivalent [ 3; 2; 1 ]

    [<Fact>]
    let ``two lists with different elements are not equivalent``() =
        [ 1; 2; 3 ] |> should not' (equivalent [ 4; 5; 6 ])

    [<Fact>]
    let ``two lists with different lengths are not equivalent``() =
        [ 1; 2; 3 ] |> should not' (equivalent [ 1; 2 ])

    [<Fact>]
    let ``two arrays with same elements in different order are equivalent``() =
        [| 1; 2; 3 |] |> should equivalent [| 3; 2; 1 |]

    [<Fact>]
    let ``two arrays with different elements are not equivalent``() =
        [| 1; 2; 3 |] |> should not' (equivalent [| 4; 5; 6 |])

    [<Fact>]
    let ``empty collections are equivalent``() =
        [] |> should equivalent []
        [||] |> should equivalent [||]

    [<Fact>]
    let ``collections with same elements and duplicates are not equivalent if counts differ``() =
        [ 1; 1; 2 ] |> should not' (equivalent [ 1; 2; 2 ])

    [<Fact>]
    let ``collections with same elements and same counts are equivalent``() =
        [ 1; 1; 2 ] |> should equivalent [ 2; 1; 1 ]
