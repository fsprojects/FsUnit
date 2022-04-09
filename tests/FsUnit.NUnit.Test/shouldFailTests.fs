namespace FsUnit.Test

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
    member _.``shouldFaild should throw an exception``() =
        (fun () -> shouldFail id)
        |> should throw typeof<NUnit.Framework.AssertionException>

    [<Test>]
    member _.``shouldFaild should not throw an exception when fail``() =
        (fun () -> shouldFail(fun () -> [] |> should contain 1))
        |> should not' (throw typeof<NUnit.Framework.AssertionException>)
