namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``haveLength tests``() =
    // F# List
    [<Test>]
    member __.``List with 1 item should have Length 1``() =
        [ 1 ] |> should haveLength 1

    [<Test>]
    member __.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> should haveLength 1)

    [<Test>]
    member __.``empty List should not have Length 1``() =
        [] |> should not' (haveLength 1)

    [<Test>]
    member __.``List with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [ 1 ] |> should not' (haveLength 1))

    // Array
    [<Test>]
    member __.``Array with 1 item should have Length 1``() =
        [| 1 |] |> should haveLength 1

    [<Test>]
    member __.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> should haveLength 1)

    [<Test>]
    member __.``empty Array should not have Length 1``() =
        [||] |> should not' (haveLength 1)

    [<Test>]
    member __.``Array with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [| 1 |] |> should not' (haveLength 1))

    // Seq
    [<Test>]
    member __.``Seq with 1 item should fail to have Length 1``() =
        (fun () -> seq { 1 } |> should haveLength 1)
        |> should throw typeof<System.ArgumentException>
