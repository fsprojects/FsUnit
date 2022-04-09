namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

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
    member _.``shouldFaild should throw an exception``() =
        (fun () -> shouldFail id)
        |> should throw typeof<AssertFailedException>

    [<TestMethod>]
    member _.``shouldFaild should not throw an exception when fail``() =
        (fun () -> shouldFail(fun () -> [] |> should contain 1))
        |> should not' (throw typeof<AssertFailedException>)
