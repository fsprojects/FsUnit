namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``have unique items list tests`` ()=
    [<Fact>] member test.
     ``empty list should be considered as unique`` ()=
        [] |> should be unique

    [<Fact>] member test.
     ``empty list should fail to be considered as not unique`` ()=
        shouldFail(fun () -> [] |> should not' (be unique))

    [<Fact>] member test.
     ``one-item list should be considered as unique`` ()=
        [1] |> should be unique

    [<Fact>] member test.
     ``one-item list should not fail to be considered as unique`` ()=
        shouldFail(fun () -> [1] |> should not' (be unique))

    [<Fact>] member test.
     ``unique list should be considered as unique`` ()=
        [1;2;3] |> should be unique

    [<Fact>] member test.
     ``unique list should fail to be considered unique`` ()=
        shouldFail(fun () -> [1;2;3] |> should not' (be unique))

    [<Fact>] member test.
     ``non-unique list should not be considered unique`` ()=
        [1;1;1] |> should not' (be unique)

    [<Fact>] member test.
      ``non-unique list should fail to be considered unique`` ()=
        shouldFail(fun () -> [1;1;1] |> should be unique)

    [<Fact>] member test.
     ``non-unique sequence should not be considered unique`` ()=
        [1;1] |> List.toSeq |> should not' (be unique)

    [<Fact>] member test.
     ``unique sequence should be considered unique`` ()=
        [1;2] |> List.toSeq |> should be unique

    [<Fact>] member test.
     ``non-unique array should not be considered as unique`` ()=
        [|1;1|] |> should not' (be unique)

    [<Fact>] member test.
     ``unique array should be considered unique`` ()=
        [|1;2|] |> should be unique

    [<Fact>] member test.
     ``string null should be unique`` ()=
        string null |> should be unique
