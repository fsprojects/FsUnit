namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be False tests``() =
    [<Test>]
    member __.``false should be False``() =
        false |> should be False

    [<Test>]
    member __.``true should fail to be False``() =
        shouldFail(fun () -> true |> should be False)

    [<Test>]
    member __.``true should not be False``() =
        true |> should not' (be False)

    [<Test>]
    member __.``false should fail to not be False``() =
        shouldFail(fun () -> false |> should not' (be False))
