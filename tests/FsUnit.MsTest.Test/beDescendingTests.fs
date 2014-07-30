namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDepricated

[<TestClass>]
type ``be descending tests`` ()=
    [<TestMethod>] member test.
     ``Empty list should be descending`` ()=
        [] |> should be descending

    [<TestMethod>] member test.
     ``List with one element should be descending`` ()=
        [1] |> should be descending

    [<TestMethod>] member test.
     ``List that only has identical elements should be descending`` ()=
        [1; 1; 1] |> should be descending

    [<TestMethod>] member test.
     ``List that is descending should be descending`` ()=
        [2; 1] |> should be descending

    [<TestMethod>] member test.
     ``List that is not descending should not be descending`` ()=
        [1; 2] |> should not' (be descending)