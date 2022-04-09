namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be True tests``() =
    [<Test>]
    member _.``true should be True``() =
        true |> should be True

    [<Test>]
    member _.``false should fail to be True``() =
        shouldFail(fun () -> false |> should be True)

    [<Test>]
    member _.``false should not be True``() =
        false |> should not' (be True)

    [<Test>]
    member _.``true should fail to not be True``() =
        shouldFail(fun () -> true |> should not' (be True))
