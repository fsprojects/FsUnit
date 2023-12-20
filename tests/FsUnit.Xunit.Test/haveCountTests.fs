namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``haveCount tests``() =

    let emptyList = System.Collections.Generic.List<int>()

    let singleItemList = System.Collections.Generic.List<int>()

    do singleItemList.Add(1)

    // Collection
    [<Fact>]
    member _.``Collection with 1 item should have Count 1``() =
        singleItemList |> should haveCount 1

    [<Fact>]
    member _.``empty Collection should fail to have Count 1``() =
        shouldFail(fun () -> emptyList |> should haveCount 1)

    [<Fact>]
    member _.``empty Collection should not have Count 1``() =
        emptyList |> should not' (haveCount 1)

    [<Fact>]
    member _.``Collection with 1 item should fail to not have Count 1``() =
        shouldFail(fun () -> singleItemList |> should not' (haveCount 1))

    // Seq
    [<Fact>]
    member _.``Seq with 1 item should fail to have Count 1``() =
        (fun () -> seq { 1 } |> should haveCount 1)
        |> should throw typeof<System.ArgumentException>
