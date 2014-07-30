namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDepricated

type ``be descending tests`` ()=
    [<Fact>] member test.
     ``Empty list should be descending`` ()=
        [] |> should be descending

    [<Fact>] member test.
     ``List with one element should be descending`` ()=
        [1] |> should be descending

    [<Fact>] member test.
     ``List that only has identical elements should be descending`` ()=
        [1; 1; 1] |> should be descending

    [<Fact>] member test.
     ``List that is descending should be descending`` ()=
        [2; 1] |> should be descending

    [<Fact>] member test.
     ``List that is not descending should not be descending`` ()=
        [1; 2] |> should not' (be descending)