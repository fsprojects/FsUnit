namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``should haveSubstring tests``() =
    [<TestMethod>]
    member _.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<TestMethod>]
    member _.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<TestMethod>]
    member _.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
