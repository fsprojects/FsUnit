namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be lessThan tests`` ()=
    [<TestMethod>] member test.
     ``10 should be less than 11`` ()=
        10 |> should be (lessThan 11)

    [<TestMethod>] member test.
     ``10.0 should be less than 10.1`` ()=
        10.0 |> should be (lessThan 10.1)

    [<TestMethod>] member test.
     ``10 should not be less than 9`` ()=
        10 |> should not' (be lessThan 9)

    [<TestMethod>] member test.
     ``9.2 should not be less than 9.1`` ()=
        9.2 |> should not' (be lessThan 9.1)

    [<TestMethod>] member test.
     ``9.1 should not be less than 9.1`` ()=
        9.1 |> should not' (be lessThan 9.1)
