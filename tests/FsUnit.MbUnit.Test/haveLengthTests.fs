namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``haveLength tests`` ()=
    // F# List
    [<Test>] member test.
     ``List with 1 item should have Length 1`` ()=
        [1] |> should haveLength 1

    [<Test>] member test.
     ``empty List should fail to have Length 1`` ()=
        shouldFail (fun () -> [] |> should haveLength 1)

    [<Test>] member test.
     ``empty List should not have Length 1`` ()=
        [] |> should not' (haveLength 1)

    [<Test>] member test.
     ``List with 1 item should fail to not have Length 1`` ()=
        shouldFail (fun () -> [1] |> should not' (haveLength 1))

    // Array
    [<Test>] member test.
     ``Array with 1 item should have Length 1`` ()=
        [|1|] |> should haveLength 1

    [<Test>] member test.
     ``empty Array should fail to have Length 1`` ()=
        shouldFail (fun () -> [||] |> should haveLength 1)

    [<Test>] member test.
     ``empty Array should not have Length 1`` ()=
        [||] |> should not' (haveLength 1)

    [<Test>] member test.
     ``Array with 1 item should fail to not have Length 1`` ()=
        shouldFail (fun () -> [|1|] |> should not' (haveLength 1))

    // Seq
    [<Test>] member test.
     ``Seq with 1 item should fail to have Length 1`` ()=
        (fun () -> seq {yield 1;} |> should haveLength 1)
        |> should throw typeof<System.ArgumentException>
