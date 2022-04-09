namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should haveSubstring tests``() =
    [<Fact>]
    member _.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<Fact>]
    member _.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<Fact>]
    member _.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
