namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDepricated

type ``be ascending tests`` ()=
    [<Fact>] member test.
     ``Empty list should be ascending`` ()=
        [] |> should be ascending

    [<Fact>] member test.
     ``List with one element should be ascending`` ()=
        [1] |> should be ascending

    [<Fact>] member test.
     ``List that only has identical elements should be ascending`` ()=
        [1; 1; 1] |> should be ascending

    [<Fact>] member test.
     ``List that is ascending should be ascending`` ()=
        [1; 2] |> should be ascending

    [<Fact>] member test.
     ``List that is not ascending should not be ascending`` ()=
        [2; 1] |> should not' (be ascending)
