namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``be supersetOf tests`` ()= 

    [<Fact>] member test.
     ``1 to 10 should be superset of 5, 3 and 8`` ()=
        [1..10] |> should be (supersetOf [5;3;8])

    [<Fact>] member test.
     ``1 to 10 should be superset of 5`` ()=
        [1..10] |> should be (supersetOf [5])

    [<Fact>] member test.
     ``1 to 10 values should be superset of 4 to 8`` ()=
        {1..10} |> should be (supersetOf {4..8})
        
    [<Fact>] member test.
     ``1 to 10 should be superset of 4, 1 and 7`` ()=
        [|1..10|] |> should be (supersetOf [|4;1;7|])

    [<Fact>] member test.
     ``1 to 10 should not be superset of 5, 1 and 11`` ()=
        [1..10] |> should not' (be supersetOf [5;1;11])

    [<Fact>] member test.
     ``5 should not be superset of 1 to 10`` ()=
        [5] |> should not' (be supersetOf [1..10])

    [<Fact>] member test.
     ``1 to 10 should be superset of 1 to 10`` ()=
        [1..10] |> should be (supersetOf [1..10])