namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldContain tests`` ()=
    [<Test>] member test.
     ``List with item should contain item`` ()=
        [1] |> shouldContain 1

    [<Test>] member test.
     ``empty List should fail to contain item`` ()=
        shouldFail (fun () -> [] |> shouldContain 1)

    [<Test>] member test.
     ``empty List should not contain item`` ()=
        [] |> shouldNotContain 1

    [<Test>] member test.
     ``List with item should fail to not contain item`` ()=
        shouldFail (fun () -> [1] |> shouldNotContain 1)

    [<Test>] member test.
     ``Array with item should contain item`` ()=
        [|1|] |> shouldContain 1

    [<Test>] member test.
     ``empty Array should fail to contain item`` ()=
        shouldFail (fun () -> [||] |> shouldContain 1)

    [<Test>] member test.
     ``empty Array should not contain item`` ()=
        [||] |> shouldNotContain 1

    [<Test>] member test.
     ``Array with item should fail to not contain item`` ()=
        shouldFail (fun () -> [|1|] |> shouldNotContain 1)

    [<Test>] member test.
     ``Seq with item should contain item`` ()=
        seq { yield 1 } |> shouldContain 1

    [<Test>] member test.
     ``empty Seq should fail to contain item`` ()=
        shouldFail (fun () -> Seq.empty |> shouldContain 1)

    [<Test>] member test.
     ``empty Seq should not contain item`` ()=
        Seq.empty |> shouldNotContain 1

    [<Test>] member test.
     ``Seq with item should fail to not contain item`` ()=
        shouldFail (fun () -> seq { yield 1 } |> shouldNotContain 1)