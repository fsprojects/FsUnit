namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be EmptyString tests``() =
    [<TestMethod>]
    member __.``empty string should be EmptyString``() =
        "" |> should be NullOrEmptyString

    [<TestMethod>]
    member __.``non-empty string should fail to be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<TestMethod>]
    member __.``non-empty string should not be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<TestMethod>]
    member __.``empty string should fail to not be EmptyString``() =
        "" |> should be EmptyString
