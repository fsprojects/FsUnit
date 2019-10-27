namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be supersetOf tests`` ()= 

    [<Test>] member test.
     ``list values should be superset of other values`` ()=
        [1..10] |> should be (supersetOf [5;3;8])

    [<Test>] member test.
     ``values should be superset of one value`` ()=
        [1..10] |> should be (supersetOf [5])

    [<Test>] member test.
     ``sequence values should be superset of other values`` ()=
        {1..10} |> should be (supersetOf {4..8})
        
    [<Test>] member test.
     ``array values should be superset of other values`` ()=
        [|1..10|] |> should be (supersetOf [|4;1;7|])

    [<Test>] member test.
     ``values should not be superset of other values`` ()=
        [1..10] |> should not' (be supersetOf [5;1;11])

    [<Test>] member test.
     ``value should not be superset of values`` ()=
        [5] |> should not' (be supersetOf [1..10])
