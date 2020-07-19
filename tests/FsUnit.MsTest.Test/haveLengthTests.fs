namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``haveLength tests``() =
    // F# List
    [<TestMethod>]
    member __.``List with 1 item should have Length 1``() =
        [ 1 ] |> should haveLength 1

    [<TestMethod>]
    member __.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> should haveLength 1)

    [<TestMethod>]
    member __.``empty List should not have Length 1``() =
        [] |> should not' (haveLength 1)

    [<TestMethod>]
    member __.``List with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [ 1 ] |> should not' (haveLength 1))

    // Array
    [<TestMethod>]
    member __.``Array with 1 item should have Length 1``() =
        [| 1 |] |> should haveLength 1

    [<TestMethod>]
    member __.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> should haveLength 1)

    [<TestMethod>]
    member __.``empty Array should not have Length 1``() =
        [||] |> should not' (haveLength 1)

    [<TestMethod>]
    member __.``Array with 1 item should fail to not have Length 1``() =
        shouldFail(fun () -> [| 1 |] |> should not' (haveLength 1))

    [<TestMethod>]
    member __.``Array with 1 item should fail to have Length 2 but message should be equal``() =
        (fun () -> [| 1 |] |> should haveLength 2)
        |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
        |> fun e -> e.Message
        |> should equal ("Have Length 2 was [|1|]")

    // Seq
    [<TestMethod>]
    member __.``Seq with 1 item should fail to have Length 1``() =
        (fun () -> seq { 1 } |> should haveLength 1)
        |> should throw typeof<System.ArgumentException>
