namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be Null tests``() =

    [<Test>]
    member _.``null should be Null``() =
        null |> should be Null

    [<Test>]
    member _.``null should fail to not be Null``() =
        shouldFail(fun () -> null |> should not' (be Null))

    [<Test>]
    member _.``non-null should fail to be Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<Test>]
    member _.``non-null should not be Null``() =
        "something" |> should not' (be Null)

    [<Test>]
    member _.``null should be null``() =
        null |> should be null

    [<Test>]
    member _.``null should fail to not be null``() =
        shouldFail(fun () -> null |> should not' (be null))

    [<Test>]
    member _.``non-null should fail to be null``() =
        shouldFail(fun () -> "something" |> should be null)

    [<Test>]
    member _.``non-null should not be null``() =
        "something" |> should not' (be null)
