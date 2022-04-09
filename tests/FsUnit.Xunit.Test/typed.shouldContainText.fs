namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldContainText tests``() =
    [<Fact>]
    member _.``empty string should contain ""``() =
        "" |> shouldContainText ""

    [<Fact>]
    member _.``ships should contain hip``() =
        "ships" |> shouldContainText "hip"
