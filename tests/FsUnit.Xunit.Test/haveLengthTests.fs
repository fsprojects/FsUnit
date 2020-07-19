namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``haveLength tests``() =
    // F# List
    [<Fact>]
    member __.``List with 1 item should have Length 1``() =
        [ 1 ] |> should haveLength 1

    [<Fact>]
    member __.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> should haveLength 1)

    [<Fact>]
    member __.``empty List should not have Length 1``() =
        [] |> should not' (haveLength 1)

    [<Fact>]
    member __.``List with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [ 1 ] |> should not' (haveLength 1))

    // Array
    [<Fact>]
    member __.``Array with 1 item should have Length 1``() =
        [| 1 |] |> should haveLength 1

    [<Fact>]
    member __.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> should haveLength 1)

    [<Fact>]
    member __.``empty Array should not have Length 1``() =
        [||] |> should not' (haveLength 1)

    [<Fact>]
    member __.``Array with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [| 1 |] |> should not' (haveLength 1))

    [<Fact>]
    member __.``Array with 1 item should fail to have Length 2 but messages should equal``() =
        (fun () -> [| 1 |] |> should haveLength 2)
        |> fun f -> Assert.Throws<MatchException>(f)
        |> fun e -> (e.Expected, e.Actual)
        |> should equal ("Have Length 2", "[|1|]")

    // Seq
    [<Fact>]
    member __.``Seq with 1 item should fail to have Length 1``() =
        (fun () -> seq { 1 } |> should haveLength 1)
        |> should throw typeof<System.ArgumentException>
