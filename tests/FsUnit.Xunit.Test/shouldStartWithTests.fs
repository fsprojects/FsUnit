namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should startWith tests``() =
    [<Fact>]
    member _.``empty string should start with ""``() =
        "" |> should startWith ""

    [<Fact>]
    member _.``ships should start with ps``() =
        "ships" |> should startWith "sh"

    [<Fact>]
    member _.``ships should not start with ss``() =
        "ships" |> should not' (startWith "ss")
