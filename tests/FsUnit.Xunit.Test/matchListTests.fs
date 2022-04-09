namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``match List tests``() =
    [<Fact>]
    member _.``Empty list should match itself``() =
        ([]: List<int>) |> should matchList ([]: List<int>)

    [<Fact>]
    member _.``Empty obj list should match itself``() =
        [] |> should matchList []

    [<Fact>]
    member _.``List with elements should not match empty list``() =
        [ 1 ] |> should not' (matchList [])

    [<Fact>]
    member _.``Empty list should not match list with elements``() =
        [] |> should not' (matchList [ "abc" ])

    [<Fact>]
    member _.``Single element list should match itself``() =
        [ 1 ] |> should matchList [ 1 ]

    [<Fact>]
    member _.``Three element list should match itself``() =
        [ 10; 12; 25 ] |> should matchList [ 10; 12; 25 ]

    [<Fact>]
    member _.``Three element list should match it's permutation``() =
        [ 25; 12; 18 ] |> should matchList [ 18; 12; 25 ]

    [<Fact>]
    member _.``Lists with different lengths doesn't match``() =
        [ "something", "is", "missed" ]
        |> should not' (matchList [ "something", "is", "missed", "here" ])

    [<Fact>]
    member _.``Comparing scalar to list should not match``() =
        47 |> should not' (matchList [ 47 ])
