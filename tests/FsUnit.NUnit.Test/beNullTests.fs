namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be Null tests``() =
    [<Test>]
    member __.``null should be Null``() =
        null |> should be Null

    [<Test>]
    member __.``null should fail to not be Null``() =
        shouldFail(fun () -> null |> should not' (be Null))

    [<Test>]
    member __.``non-null should fail to be Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<Test>]
    member __.``non-null should not be Null``() =
        "something" |> should not' (be Null)

    [<Test>]
    member __.``null should be null``() =
        null |> should be null

    [<Test>]
    member __.``null should fail to not be null``() =
        shouldFail(fun () -> null |> should not' (be null))

    [<Test>]
    member __.``non-null should fail to be null``() =
        shouldFail(fun () -> "something" |> should be null)

    [<Test>]
    member __.``non-null should not be null``() =
        "something" |> should not' (be null)
