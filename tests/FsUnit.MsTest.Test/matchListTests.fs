namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDeprecated

[<TestClass>]
type ``match List tests`` ()=
    [<TestMethod>] member test.
     ``Empty list should match itself`` () =
        ([] : List<int>) |> should matchList ([] : List<int>)

    [<TestMethod>] member test.
     ``Single element list should match itself`` () =
        [1] |> should matchList [1]

    [<TestMethod>] member test.
     ``Three element list should match itself`` () =
        [10; 12; 25] |> should matchList [10; 12; 25]

    [<TestMethod>] member test.
     ``Three element list should match it's permutation`` () =
        [25; 12; 18] |> should matchList [18; 12; 25]

    [<TestMethod>] member test.
     ``Lists with different lengths doesn't match`` () =
        ["something","is","missed"] |> should not (matchList ["something", "is", "missed", "here"])
        