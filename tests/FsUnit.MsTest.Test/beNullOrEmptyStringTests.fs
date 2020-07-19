namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be NullOrEmptyString tests``() =
    [<TestMethod>]
    member __.``empty string should be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member __.``null should be NullOrEmptyString``() =
        null |> should be NullOrEmptyString

    [<TestMethod>]
    member __.``non-empty string should fail to be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<TestMethod>]
    member __.``non-empty string should not be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<TestMethod>]
    member __.``empty string should fail to not be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member __.``null should fail to not be NullOrEmptyString``() =
        null |> should be NullOrEmptyString
