namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldContainText tests``() =
    [<Fact>]
    member __.``empty string should contain ""``() =
        "" |> shouldContainText ""

    [<Fact>]
    member __.``ships should contain hip``() =
        "ships" |> shouldContainText "hip"
