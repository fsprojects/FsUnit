namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeEmpty tests`` ()=
    [<Test>] member test.
     ``empty List should be Empty`` ()=
        [] |> shouldBeEmpty

    [<Test>] member test.
     ``non-empty List should fail to be Empty`` ()=
        shouldFail (fun () -> [1] |> shouldBeEmpty)

    [<Test>] member test.
     ``empty Array should be Empty`` ()=
        [||] |> shouldBeEmpty

    [<Test>] member test.
     ``non-empty Array should fail to be Empty`` ()=
        shouldFail (fun () -> [|1|] |> shouldBeEmpty)

    [<Test>] member test.
     ``empty Seq should be Empty`` ()=
        Seq.empty |> shouldBeEmpty

    [<Test>] member test.
     ``non-empty Seq should fail to be Empty`` ()=
        shouldFail (fun () -> seq { 1 } |> shouldBeEmpty)