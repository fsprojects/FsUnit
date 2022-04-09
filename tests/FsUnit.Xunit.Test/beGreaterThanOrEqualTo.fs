namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be greaterThanOrEqualTo tests``() =
    [<Fact>]
    member _.``11 should be greater than 10``() =
        11 |> should be (greaterThanOrEqualTo 10)

    [<Fact>]
    member _.``11[dot]1 should be greater than 11[dot]0``() =
        11.1 |> should be (greaterThanOrEqualTo 11.0)

    [<Fact>]
    member _.``9 should not be greater than 10``() =
        9 |> should not' (be greaterThanOrEqualTo 10)

    [<Fact>]
    member _.``9[dot]1 should not be greater than 9[dot]2``() =
        9.1 |> should not' (be greaterThanOrEqualTo 9.2)

    [<Fact>]
    member _.``9[dot]2 should be equal to 9[dot]2``() =
        9.2 |> should be (greaterThanOrEqualTo 9.2)

    [<Fact>]
    member _.``9 should be equal to 9``() =
        9 |> should be (greaterThanOrEqualTo 9)
