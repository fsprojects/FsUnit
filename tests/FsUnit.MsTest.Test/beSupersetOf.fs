namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be supersetOf tests`` ()= 

    [<TestMethod>] member test.
     ``list values should be superset of other values`` ()=
        [1..10] |> should be (supersetOf [5;3;8])

    [<TestMethod>] member test.
     ``values should be superset of one value`` ()=
        [1..10] |> should be (supersetOf [5])

    [<TestMethod>] member test.
     ``sequence values should be superset of other values`` ()=
        {1..10} |> should be (supersetOf {4..8})
        
    [<TestMethod>] member test.
     ``array values should be superset of other values`` ()=
        [|1..10|] |> should be (supersetOf [|4;1;7|])

    [<TestMethod>] member test.
     ``values should not be superset of other values`` ()=
        [1..10] |> should not' (be supersetOf [5;1;11])

    [<TestMethod>] member test.
     ``value should not be superset of values`` ()=
        [5] |> should not' (be supersetOf [1..10])