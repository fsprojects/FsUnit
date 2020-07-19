namespace FsUnit.Test

open Xunit
open FsUnit.Xunit
open System

type ``Not a Number tests``() =
    [<Fact>]
    member __.``Number 1 should be a number``() =
        1 |> should not' (be NaN)

    [<Fact>]
    member __.``NaN should not be a number``() =
        Double.NaN |> should be NaN

    [<Fact>]
    member __.``float number 2.0 should be a number``() =
        2.0 |> should not' (be NaN)

    [<Fact>]
    member __.``float number 2.0 should fail to not be a number``() =
        shouldFail(fun () -> 2.0 |> should be NaN)
