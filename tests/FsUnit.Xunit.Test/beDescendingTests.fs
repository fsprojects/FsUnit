namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be descending tests``() =

    [<Fact>]
    member _.``Empty list should be descending``() =
        [] |> should be descending

    [<Fact>]
    member _.``List with one element should be descending``() =
        [ 1 ] |> should be descending

    [<Fact>]
    member _.``List that only has identical elements should be descending``() =
        [ 1; 1; 1 ] |> should be descending

    [<Fact>]
    member _.``List that is descending should be descending``() =
        [ 2; 1 ] |> should be descending

    [<Fact>]
    member _.``List that is not descending should not be descending``() =
        [ 1; 2 ] |> should not' (be descending)
