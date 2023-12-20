namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``haveSubstring tests``() =

    [<Test>]
    member _.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<Test>]
    member _.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<Test>]
    member _.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
