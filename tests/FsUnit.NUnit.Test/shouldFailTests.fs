namespace FsUnit.Test

open System
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``shouldFail tests``() =
    [<Test>]
    member _.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> should contain 1)

    [<Test>]
    member _.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<Test>]
    member _.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<Test>]
    member _.``shouldFail should throw an exception``() =
        (fun () -> shouldFail id) |> should throw typeof<AssertionException>

    [<Test>]
    member _.``shouldFail should not throw an exception when fail``() =
        (fun () -> shouldFail(fun () -> [] |> should contain 1))
        |> should not' (throw typeof<AssertionException>)

    [<Test>]
    member _.``test raising exception``() =
        fun () -> raise(ArgumentException "help")
        |> should (throwWithMessage "help") typeof<ArgumentException>
