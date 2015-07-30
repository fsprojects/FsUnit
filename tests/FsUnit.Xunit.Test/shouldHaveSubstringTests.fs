namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``should haveSubstring tests`` ()=
    [<Fact>] member test.
     ``empty string should contain ""`` ()=
        "" |> should haveSubstring ""

    [<Fact>] member test.
     ``ships should contain hip`` ()=
        "ships" |> should haveSubstring "hip"

    [<Fact>] member test.
     ``ships should not contain haps`` ()=
        "ships" |> should not' (haveSubstring "haps")

