namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``should haveSubstring tests`` ()=
    [<Test>] member test.
     ``empty string should contain ""`` ()=
        "" |> should haveSubstring ""

    [<Test>] member test.
     ``ships should contain hip`` ()=
        "ships" |> should haveSubstring "hip"

    [<Test>] member test.
     ``ships should not contain haps`` ()=
        "ships" |> should not' (haveSubstring "haps")

