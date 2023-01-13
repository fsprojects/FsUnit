namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open System

[<TestClass>]
type ``shouldFail tests``() =
    [<TestMethod>]
    member _.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> should contain 1)

    [<TestMethod>]
    member _.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<TestMethod>]
    member _.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<TestMethod>]
    member _.``shouldFail should throw an exception``() =
        (fun () -> shouldFail id)
        |> should throw typeof<AssertFailedException>

    [<TestMethod>]
    member _.``shouldFail should not throw an exception when fail``() =
        (fun () -> shouldFail(fun () -> [] |> should contain 1))
        |> should not' (throw typeof<AssertFailedException>)

    [<TestMethod>]
    member _.``test raising exception``() =
        fun () -> raise(ArgumentException "help")
        |> should (throwWithMessage "help") typeof<ArgumentException>

    [<TestMethod>]
    member _.``Null source should fail``() =
        shouldFail(fun () -> Seq.empty |> Seq.append null |> ignore)
