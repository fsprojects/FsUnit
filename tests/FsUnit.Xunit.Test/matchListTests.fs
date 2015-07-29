namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``match List tests`` ()=
    [<Fact>] member test.
     ``Empty list should match itself`` () =
        ([] : List<int>) |> should matchList ([] : List<int>)

    [<Fact>] member test.
     ``Single element list should match itself`` () =
        [1] |> should matchList [1]

    [<Fact>] member test.
     ``Three element list should match itself`` () =
        [10; 12; 25] |> should matchList [10; 12; 25]

    [<Fact>] member test.
     ``Three element list should match it's permutation`` () =
        [25; 12; 18] |> should matchList [18; 12; 25]

    [<Fact>] member test.
     ``Lists with different lengths doesn't match`` () =
        ["something","is","missed"] |> should not' (matchList ["something", "is", "missed", "here"])
