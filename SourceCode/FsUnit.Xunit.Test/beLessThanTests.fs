namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be lessThan tests`` ()=
    [<Fact>] member test.
     ``10 should be less than 11`` ()=
        10 |> should be (lessThan 11)

    [<Fact>] member test.
     ``10.0 should be less than 10.1`` ()=
        10.0 |> should be (lessThan 10.1)

    [<Fact>] member test.
     ``10 should not be less than 9`` ()=
        10 |> should not (be lessThan 9)

    [<Fact>] member test.
     ``9.2 should not be less than 9.1`` ()=
        9.2 |> should not (be lessThan 9.1)

    [<Fact>] member test.
     ``9.1 should not be less than 9.1`` ()=
        9.1 |> should not (be lessThan 9.1)
