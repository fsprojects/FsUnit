namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``matchListTests``() =

    [<TestMethod>]
    member _.``Empty list should match itself``() =
        ([]: List<int>) |> should matchList ([]: List<int>)

    [<TestMethod>]
    member _.``Empty obj list should match itself``() =
        [] |> should matchList []

    [<TestMethod>]
    member _.``List with elements should not match empty list``() =
        [ 1 ] |> should not' (matchList [])

    [<TestMethod>]
    member _.``Empty list should not match list with elements``() =
        [] |> should not' (matchList [ "abc" ])

    [<TestMethod>]
    member _.``Single element list should match itself``() =
        [ 1 ] |> should matchList [ 1 ]

    [<TestMethod>]
    member _.``Three element list should match itself``() =
        [ 10; 12; 25 ] |> should matchList [ 10; 12; 25 ]

    [<TestMethod>]
    member _.``Three element list should match its permutation``() =
        [ 25; 12; 18 ] |> should matchList [ 18; 12; 25 ]

    [<TestMethod>]
    member _.``Lists with different lengths doesnt match``() =
        [ "something", "is", "missed" ]
        |> should not' (matchList [ "something", "is", "missed", "here" ])

    [<TestMethod>]
    member _.``Comparing scalar to list should not match``() =
        47 |> should not' (matchList [ 47 ])
