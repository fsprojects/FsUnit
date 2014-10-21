namespace FsUnit.Test
open NUnit.Framework
open FsUnit
open FsUnitDeprecated

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
        [] |> should not (haveLength 1)

    [<Test>] member test.
     ``List with 1 item should fail to not have Length 1`` ()=
        shouldFail (fun () -> [1] |> should not (haveLength 1))
        
    // Array
    [<Test>] member test.
     ``Array with 1 item should have Length 1`` ()=
        [|1|] |> should haveLength 1

    [<Test>] member test.
     ``empty Array should fail to have Length 1`` ()=
        shouldFail (fun () -> [||] |> should haveLength 1)

    [<Test>] member test.
     ``empty Array should not have Length 1`` ()=
        [||] |> should not (haveLength 1)

    [<Test>] member test.
     ``Array with 1 item should fail to not have Length 1`` ()=
        shouldFail (fun () -> [|1|] |> should not (haveLength 1))

