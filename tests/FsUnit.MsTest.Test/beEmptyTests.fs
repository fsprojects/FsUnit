namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be Empty tests`` ()=
    [<TestMethod>] member test.
     ``empty List should be Empty`` ()=
        [] |> should be Empty

    [<TestMethod>] member test.
     ``non-empty List should fail to be Empty`` ()=
        shouldFail (fun () -> [1] |> should be Empty)

    [<TestMethod>] member test.
     ``non-empty List should not be Empty`` ()=
        [1] |> should not' (be Empty)

    [<TestMethod>] member test.
     ``empty List should fail to not be Empty`` ()=
        shouldFail (fun () -> [] |> should not' (be Empty))

    [<TestMethod>] member test.
     ``empty Array should be Empty`` ()=
        [||] |> should be Empty

    [<TestMethod>] member test.
     ``non-empty Array should fail to be Empty`` ()=
        shouldFail (fun () -> [|1|] |> should be Empty)

    [<TestMethod>] member test.
     ``non-empty Array should not be Empty`` ()=
        [|1|] |> should not' (be Empty)

    [<TestMethod>] member test.
     ``empty Array should fail to not be Empty`` ()=
        shouldFail (fun () -> [||] |> should not' (be Empty))

    [<TestMethod>] member test.
     ``empty Seq should be Empty`` ()=
        Seq.empty |> should be Empty

    [<TestMethod>] member test.
     ``non-empty Seq should fail to be Empty`` ()=
        shouldFail (fun () -> seq { 1 } |> should be Empty)

    [<TestMethod>] member test.
     ``non-empty Seq should not be Empty`` ()=
        seq { 1 } |> should not' (be Empty)

    [<TestMethod>] member test.
     ``empty Seq should fail to not be Empty`` ()=
        shouldFail (fun () -> Seq.empty |> should not' (be Empty))

    [<TestMethod>] member test.
     ``string null should be Empty`` ()=
        string null |> should be Empty