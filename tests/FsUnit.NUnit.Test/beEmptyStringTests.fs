namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be EmptyString tests``() =
    [<Test>]
    member __.``empty string should be EmptyString``() =
        "" |> should be EmptyString

    [<Test>]
    member __.``non-empty string should fail to be EmptyString``() =
        shouldFail(fun () -> "a string" |> should be EmptyString)

    [<Test>]
    member __.``non-empty string should not be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<Test>]
    member __.``empty string should fail to not be EmptyString``() =
        shouldFail(fun () -> "" |> should not' (be EmptyString))
