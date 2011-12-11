namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit

[<TestFixture>]
type ``contain tests`` ()=
    [<Test>] member test.
     ``List with item should contain item`` ()=
        [1] |> should contain 1

    [<Test>] member test.
     ``empty List should fail to contain item`` ()=
        [] |> should not (contain 1)

    [<Test>] member test.
     ``populated List should not contain item`` ()=
        [2] |> should not (contain 1)

    [<Test>] member test.
     ``empty List should not contain item`` ()=
        [] |> should not (contain 1)

    [<Test>] member test.
     ``List with item should fail to not contain item`` ()=
        [1] |> should contain 1

    [<Test>] member test.
     ``Array with item should contain item`` ()=
        [|1|] |> should contain 1

    [<Test>] member test.
     ``empty Array should fail to contain item`` ()=
        [||] |> should not (contain 1)

    [<Test>] member test.
     ``empty Array should not contain item`` ()=
        [||] |> should not (contain 1)

    [<Test>] member test.
     ``Array with item should fail to not contain item`` ()=
        [|1|] |> should contain 1

    [<Test>] member test.
     ``Seq with item should contain item`` ()=
        seq { yield 1 } |> should contain 1

    [<Test>] member test.
     ``empty Seq should fail to contain item`` ()=
        Seq.empty |> should not (contain 1)

    [<Test>] member test.
     ``empty Seq should not contain item`` ()=
        Seq.empty |> should not (contain 1)

    [<Test>] member test.
     ``Seq with item should fail to not contain item`` ()=
        seq { yield 1 } |> should contain 1
