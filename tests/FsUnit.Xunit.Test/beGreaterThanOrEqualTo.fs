namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be greaterThanOrEqualTo tests`` ()=
    [<Fact>] member test.
     ``11 should be greater than 10`` ()=
        11 |> should be (greaterThanOrEqualTo 10)

    [<Fact>] member test.
     ``11.1 should be greater than 11.0`` ()=
        11.1 |> should be (greaterThanOrEqualTo 11.0)

    [<Fact>] member test.
     ``9 should not be greater than 10`` ()=
        9 |> should not (be greaterThanOrEqualTo 10)

    [<Fact>] member test.
     ``9.1 should not be greater than 9.2`` ()=
        9.1 |> should not (be greaterThanOrEqualTo 9.2)

    [<Fact>] member test.
     ``9.2 should be equal to 9.2`` ()=
        9.2 |> should be (greaterThanOrEqualTo 9.2)

    [<Fact>] member test.
     ``9 should be equal to 9`` ()=
        9 |> should be (greaterThanOrEqualTo 9)
