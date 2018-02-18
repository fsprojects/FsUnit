namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``match List tests`` ()=
    [<Test>] member test.
     ``Empty list should match itself`` () =
        ([] : List<int>) |> should matchList ([] : List<int>)

    [<Test>] member test.
     ``Empty obj list should match itself`` () =
        [] |> should matchList []

    [<Test>] member test.
     ``List with elements should not match empty list`` () =
        [1] |> should not' (matchList [])

    [<Test>] member test.
     ``Empty list should not match list with elements`` () =
        [] |> should not' (matchList ["abc"])

    [<Test>] member test.
     ``Single element list should match itself`` () =
        [1] |> should matchList [1]

    [<Test>] member test.
     ``Three element list should match itself`` () =
        [10; 12; 25] |> should matchList [10; 12; 25]

    [<Test>] member test.
     ``Three element list should match it's permutation`` () =
        [25; 12; 18] |> should matchList [18; 12; 25]

    [<Test>] member test.
     ``Lists with different lengths doesn't match`` () =
        ["something","is","missed"] |> should not' (matchList ["something", "is", "missed", "here"])

    [<Test>] member test.
     ``Comparing scalar to list should not match`` () =
        47 |> should not' (matchList [47])
