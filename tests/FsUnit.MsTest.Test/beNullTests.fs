namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be Null tests``() =
    [<TestMethod>]
    member __.``null should be Null``() =
        null |> should be Null

    [<TestMethod>]
    member __.``null should fail to not be Null``() =
        shouldFail(fun () -> null |> should not' (be Null))

    [<TestMethod>]
    member __.``non-null should fail to be Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<TestMethod>]
    member __.``non-null should not be Null``() =
        "something" |> should not' (be Null)

    [<TestMethod>]
    member __.``null should be null``() =
        null |> should be null

    [<TestMethod>]
    member __.``null should fail to not be null``() =
        shouldFail(fun () -> null |> should not' (be null))

    [<TestMethod>]
    member __.``non-null should fail to be null``() =
        shouldFail(fun () -> "something" |> should be null)

    [<TestMethod>]
    member __.``non-null should not be null``() =
        "something" |> should not' (be null)
