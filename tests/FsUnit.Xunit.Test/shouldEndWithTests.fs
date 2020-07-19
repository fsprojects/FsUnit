namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``should endWith tests`` ()=
    [<Fact>] member test.
     ``empty string should end with ""`` ()=
        "" |> should endWith ""

    [<Fact>] member test.
     ``ships should end with ps`` ()=
        "ships" |> should endWith "ps"

    [<Fact>] member test.
     ``ships should not end with ss`` ()=
        "ships" |> should not' (endWith "ss")

