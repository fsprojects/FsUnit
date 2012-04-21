namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDepricated

type ``have Count tests`` ()=
    let emptyList = new System.Collections.Generic.List<int>()
    let singleItemList = new System.Collections.Generic.List<int>()
    do singleItemList.Add(1)

    // Collection   
    [<Fact>] member test.
     ``Collection with 1 item should have Count 1`` ()=
        singleItemList.Count |> should equal 1

    [<Fact>] member test.
     ``empty Collection should fail to have Count 1`` ()=
        emptyList.Count |> should not (equal 1)

    [<Fact>] member test.
     ``empty Collection should not have Count 1`` ()=
        emptyList.Count |> should not (equal 1)

    [<Fact>] member test.
     ``Collection with 1 item should fail to not have Count 1`` ()=
        singleItemList.Count |> should equal 1
        