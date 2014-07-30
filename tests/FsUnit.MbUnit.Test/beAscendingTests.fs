namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
open FsUnitDepricated

type ``be ascending tests`` ()=
    [<Test>] member test.
     ``Empty list should be ascending`` ()=
        [] |> should be ascending

    [<Test>] member test.
     ``List with 1 element should be ascending`` ()=
        [1] |> should be ascending

    [<Test>] member test.
     ``List that only has identical elements should be ascending`` ()=
        [1; 1; 1] |> should be ascending

    [<Test>] member test.
     ``List that is ascending should be ascending`` ()=
        [1; 2] |> should be ascending

    [<Test>] member test.
     ``List that is not ascending should not be ascending`` ()=
        [2; 1] |> should not' (be ascending)
