namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``have Count tests`` ()=
    let emptyList = new System.Collections.Generic.List<int>()
    let singleItemList = new System.Collections.Generic.List<int>()
    do singleItemList.Add(1)

    // Collection
    [<Test>] member test.
     ``Collection with 1 item should have Count 1`` ()=
        singleItemList |> should haveCount 1

    [<Test>] member test.
     ``empty Collection should fail to have Count 1`` ()=
        shouldFail (fun () -> emptyList |> should haveCount 1)

    [<Test>] member test.
     ``empty Collection should not have Count 1`` ()=
        emptyList |> should not' (haveCount 1)

    [<Test>] member test.
     ``Collection with 1 item should fail to not have Count 1`` ()=
        shouldFail (fun () -> singleItemList |> should not' (haveCount 1))

    // Seq
    [<Test>] member test.
     ``Seq with 1 item should fail to have Count 1`` ()=
        (fun () -> seq {yield 1;} |> should haveCount 1)
        |> should throw typeof<System.ArgumentException>