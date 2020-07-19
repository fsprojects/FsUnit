namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should endWith tests``() =
    [<Fact>]
    member __.``empty string should end with ""``() =
        "" |> should endWith ""

    [<Fact>]
    member __.``ships should end with ps``() =
        "ships" |> should endWith "ps"

    [<Fact>]
    member __.``ships should not end with ss``() =
        "ships" |> should not' (endWith "ss")
