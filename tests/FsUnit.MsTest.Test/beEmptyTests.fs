namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core


type ``be Empty tests`` ()=
    [<TestMethod>] member test.
     ``empty List should be Empty`` ()=
        [].IsEmpty |> should be True

    [<TestMethod>] member test.
     ``non-empty List should not be Empty`` ()=
        [1].IsEmpty |> should not (be True)

    [<TestMethod>] member test.
     ``empty Array should be Empty`` ()=
        [||] |> Array.isEmpty |> should be True

    [<TestMethod>] member test.
     ``non-empty Array should not be Empty`` ()=
        [|1|] |> Array.isEmpty |> should not (be True)

    [<TestMethod>] member test.
     ``empty Seq should be Empty`` ()=
        Seq.empty |> Seq.isEmpty |> should be True
        
    [<TestMethod>] member test.
     ``non-empty Seq should not be Empty`` ()=
        seq { yield 1 }  |> Seq.isEmpty |> should not (be True)

