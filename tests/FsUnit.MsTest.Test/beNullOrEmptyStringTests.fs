namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beNullOrEmptyStringTests``() =

    [<TestMethod>]
    member _.``empty string should be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member _.``null should be NullOrEmptyString``() =
        null |> should be NullOrEmptyString

    [<TestMethod>]
    member _.``non-empty string should fail to be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<TestMethod>]
    member _.``non-empty string should not be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<TestMethod>]
    member _.``empty string should fail to not be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member _.``null should fail to not be NullOrEmptyString``() =
        null |> should be NullOrEmptyString
