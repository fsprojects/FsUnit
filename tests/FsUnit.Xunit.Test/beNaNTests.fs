namespace FsUnit.Test

open Xunit
open FsUnit.Xunit
open System

type ``be NaN tests``() =

    [<Fact>]
    member _.``Number 1 should be a number``() =
        1 |> should not' (be NaN)

    [<Fact>]
    member _.``NaN should not be a number``() =
        Double.NaN |> should be NaN

    [<Fact>]
    member _.``float number 2[dot]0 should be a number``() =
        2.0 |> should not' (be NaN)

    [<Fact>]
    member _.``float number 2[dot]0 should fail to not be a number``() =
        shouldFail(fun () -> 2.0 |> should be NaN)
