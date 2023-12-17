namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beEmptyStringTests``() =

    [<TestMethod>]
    member _.``empty string should be EmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member _.``non-empty string should fail to be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<TestMethod>]
    member _.``non-empty string should not be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<TestMethod>]
    member _.``empty string should fail to not be EmptyString``() =
        "" |> should be EmptyString
