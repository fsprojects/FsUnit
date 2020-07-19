namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``should haveSubstring tests``() =
    [<Test>]
    member __.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<Test>]
    member __.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<Test>]
    member __.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
