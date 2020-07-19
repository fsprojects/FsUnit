namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be True tests``() =
    [<Test>]
    member __.``true should be True``() =
        true |> should be True

    [<Test>]
    member __.``false should fail to be True``() =
        shouldFail(fun () -> false |> should be True)

    [<Test>]
    member __.``false should not be True``() =
        false |> should not' (be True)

    [<Test>]
    member __.``true should fail to not be True``() =
        shouldFail(fun () -> true |> should not' (be True))
