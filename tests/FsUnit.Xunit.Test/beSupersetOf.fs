namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``be supersetOf tests`` ()= 

    [<Fact>] member test.
     ``list values should be superset of other values`` ()=
        [1..10] |> should be (supersetOf [5;3;8])

    [<Fact>] member test.
     ``values should be superset of one value`` ()=
        [1..10] |> should be (supersetOf [5])

    [<Fact>] member test.
     ``sequence values should be superset of other values`` ()=
        {1..10} |> should be (supersetOf {4..8})
        
    [<Fact>] member test.
     ``array values should be superset of other values`` ()=
        [|1..10|] |> should be (supersetOf [|4;1;7|])

    [<Fact>] member test.
     ``values should not be superset of other values`` ()=
        [1..10] |> should not' (be supersetOf [5;1;11])

    [<Fact>] member test.
     ``value should not be superset of values`` ()=
        [5] |> should not' (be supersetOf [1..10])