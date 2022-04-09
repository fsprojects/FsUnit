namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should endWith tests``() =
    [<Fact>]
    member _.``empty string should end with ""``() =
        "" |> should endWith ""

    [<Fact>]
    member _.``ships should end with ps``() =
        "ships" |> should endWith "ps"

    [<Fact>]
    member _.``ships should not end with ss``() =
        "ships" |> should not' (endWith "ss")
