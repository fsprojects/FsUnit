namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``should haveSubstring tests``() =
    [<TestMethod>]
    member __.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<TestMethod>]
    member __.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<TestMethod>]
    member __.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
