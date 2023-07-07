namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``haveLength tests``() =
    // F# List
    [<Fact>]
    member _.``List with 1 item should have Length 1``() =
        [ 1 ] |> should haveLength 1

    [<Fact>]
    member _.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> should haveLength 1)

    [<Fact>]
    member _.``empty List should not have Length 1``() =
        [] |> should not' (haveLength 1)

    [<Fact>]
    member _.``List with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [ 1 ] |> should not' (haveLength 1))

    // Array
    [<Fact>]
    member _.``Array with 1 item should have Length 1``() =
        [| 1 |] |> should haveLength 1

    [<Fact>]
    member _.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> should haveLength 1)

    [<Fact>]
    member _.``empty Array should not have Length 1``() =
        [||] |> should not' (haveLength 1)

    [<Fact>]
    member _.``Array with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [| 1 |] |> should not' (haveLength 1))

    // Seq
    [<Fact>]
    member _.``Seq with 1 item should fail to have Length 1``() =
        (fun () -> seq { 1 } |> should haveLength 1)
        |> should throw typeof<System.ArgumentException>
