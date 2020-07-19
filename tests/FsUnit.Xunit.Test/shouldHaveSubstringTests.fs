namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should haveSubstring tests``() =
    [<Fact>]
    member __.``empty string should contain ""``() =
        "" |> should haveSubstring ""

    [<Fact>]
    member __.``ships should contain hip``() =
        "ships" |> should haveSubstring "hip"

    [<Fact>]
    member __.``ships should not contain haps``() =
        "ships" |> should not' (haveSubstring "haps")
