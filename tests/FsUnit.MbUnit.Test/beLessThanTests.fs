namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``be lessThan tests`` ()=
    [<Test>] member test.
     ``10 should be less than 11`` ()=
        10 |> should be (lessThan 11)

    [<Test>] member test.
     ``10.0 should be less than 10.1`` ()=
        10.0 |> should be (lessThan 10.1)

    [<Test>] member test.
     ``10 should not be less than 9`` ()=
        10 |> should not (be lessThan 9)

    [<Test>] member test.
     ``9.2 should not be less than 9.1`` ()=
        9.2 |> should not (be lessThan 9.1)

    [<Test>] member test.
     ``9.1 should not be less than 9.1`` ()=
        9.1 |> should not (be lessThan 9.1)
