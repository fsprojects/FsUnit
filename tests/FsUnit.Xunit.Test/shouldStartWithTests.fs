namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDeprecated

type ``should startWith tests`` ()=
    [<Fact>] member test.
     ``empty string should start with ""`` ()=
        "" |> should startWith ""

    [<Fact>] member test.
     ``ships should start with ps`` ()=
        "ships" |> should startWith "sh"
        
    [<Fact>] member test.
     ``ships should not start with ss`` ()=
        "ships" |> should not (startWith "ss")

