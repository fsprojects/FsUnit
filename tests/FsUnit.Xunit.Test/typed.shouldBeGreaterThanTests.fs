namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldBeGreaterThan tests``() =

    [<Fact>]
    member _.``11 should be greater than 10``() =
        11 |> shouldBeGreaterThan 10

    [<Fact>]
    member _.``11[dot]1 should be greater than 11[dot]0``() =
        11.1 |> shouldBeGreaterThan 11.0
