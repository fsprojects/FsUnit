namespace FsUnit.Test
open NUnit.Framework
open FsUnit
open FsUnitDepricated

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
        emptyList |> should not (haveCount 1)

    [<Test>] member test.
     ``Collection with 1 item should fail to not have Count 1`` ()=
        shouldFail (fun () -> singleItemList |> should not (haveCount 1))
        