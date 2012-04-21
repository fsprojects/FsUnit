namespace FsUnit.Test
open NUnit.Framework
open FsUnit
open FsUnitDepricated

[<TestFixture>]
type ``be Empty tests`` ()=
    [<Test>] member test.
     ``empty List should be Empty`` ()=
        [] |> should be Empty

    [<Test>] member test.
     ``non-empty List should fail to be Empty`` ()=
        shouldFail (fun () -> [1] |> should be Empty)

    [<Test>] member test.
     ``non-empty List should not be Empty`` ()=
        [1] |> should not (be Empty)

    [<Test>] member test.
     ``empty List should fail to not be Empty`` ()=
        shouldFail (fun () -> [] |> should not (be Empty))
        
    [<Test>] member test.
     ``empty Array should be Empty`` ()=
        [||] |> should be Empty

    [<Test>] member test.
     ``non-empty Array should fail to be Empty`` ()=
        shouldFail (fun () -> [|1|] |> should be Empty)
        
    [<Test>] member test.
     ``non-empty Array should not be Empty`` ()=
        [|1|] |> should not (be Empty)

    [<Test>] member test.
     ``empty Array should fail to not be Empty`` ()=
        shouldFail (fun () -> [||] |> should not (be Empty))
    
    [<Test>] member test.
     ``empty Seq should be Empty`` ()=
        Seq.empty |> should be Empty

    [<Test>] member test.
     ``non-empty Seq should fail to be Empty`` ()=
        shouldFail (fun () -> seq { yield 1 } |> should be Empty)
        
    [<Test>] member test.
     ``non-empty Seq should not be Empty`` ()=
        seq { yield 1 } |> should not (be Empty)

    [<Test>] member test.
     ``empty Seq should fail to not be Empty`` ()=
        shouldFail (fun () -> Seq.empty |> should not (be Empty))
