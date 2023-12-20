namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be inRange tests``() =

    [<Fact>]
    member _.``25 should be in range from 5 to 30``() =
        25 |> should be (inRange 5 30)

    [<Fact>]
    member _.``-13 should not be in range from 0 to 43``() =
        -13 |> should not' (be inRange 0 43)
