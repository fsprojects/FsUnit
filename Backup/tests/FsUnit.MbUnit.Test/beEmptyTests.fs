namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
open FsUnitDepricated

[<TestFixture>]
type ``be Empty tests`` ()=
    [<Test>] member test.
     ``empty List should be Empty`` ()=
        [].IsEmpty |> should be True

    [<Test>] member test.
     ``non-empty List should not be Empty`` ()=
        [1].IsEmpty |> should not (be True)
        
    [<Test>] member test.
     ``empty Array should be Empty`` ()=
        [||] |> Array.isEmpty |> should be True

    [<Test>] member test.
     ``non-empty Array should not be Empty`` ()=
        [|1|] |> Array.isEmpty |> should not (be True)

    [<Test>] member test.
     ``empty Seq should be Empty`` ()=
        Seq.empty |> Seq.isEmpty |> should be True

    [<Test>] member test.
     ``non-empty Seq should not be Empty`` ()=
        seq { yield 1 } |> Seq.isEmpty |> should not (be True)

