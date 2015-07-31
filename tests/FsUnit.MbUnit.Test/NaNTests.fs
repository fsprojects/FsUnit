namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open System

[<TestFixture>]
type ``Not a Number tests`` ()=
    [<Test>] member test.
     ``Number 1 should be a number`` ()=
        1 |> should not' (be NaN)

    [<Test>] member test.
     ``NaN should not be a number`` ()=
        Double.NaN |> should be NaN

    [<Test>] member test.
     ``float number 2.0 should be a number`` ()=
        2.0 |> should not' (be NaN)

    [<Test>] member test.
     ``float number 2.0 should fail to not be a number`` ()=
        shouldFail(fun () -> 2.0 |> should be NaN)


