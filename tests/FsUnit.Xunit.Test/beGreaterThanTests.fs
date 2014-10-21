namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDeprecated

type ``be greaterThan tests`` ()=
    [<Fact>] member test.
     ``11 should be greater than 10`` ()=
        11 |> should be (greaterThan 10)

    [<Fact>] member test.
     ``11.1 should be greater than 11.0`` ()=
        11.1 |> should be (greaterThan 11.0)

    [<Fact>] member test.
     ``9 should not be greater than 10`` ()=
        9 |> should not (be greaterThan 10)

    [<Fact>] member test.
     ``9.1 should not be greater than 9.2`` ()=
        9.1 |> should not (be greaterThan 9.2)

    [<Fact>] member test.
     ``9.2 should not be greater than 9.2`` ()=
        9.2 |> should not (be greaterThan 9.2)
