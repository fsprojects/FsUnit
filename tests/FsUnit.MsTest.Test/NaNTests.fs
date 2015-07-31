namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open System

[<TestClass>]
type ``Not a Number tests`` ()=
    [<TestMethod>] member test.
     ``Number 1 should be a number`` ()=
        1 |> should not' (be NaN)

    [<TestMethod>] member test.
     ``NaN should not be a number`` ()=
        Double.NaN |> should be NaN

    [<TestMethod>] member test.
     ``float number 2.0 should be a number`` ()=
        2.0 |> should not' (be NaN)

    [<TestMethod>] member test.
     ``float number 2.0 should fail to not be a number`` ()=
        shouldFail(fun () -> 2.0 |> should be NaN)


