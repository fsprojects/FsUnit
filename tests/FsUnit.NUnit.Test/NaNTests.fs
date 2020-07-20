namespace FsUnit.Test

open NUnit.Framework
open FsUnit
open System

[<TestFixture>]
type ``Not a Number tests``() =
    [<Test>]
    member __.``Number 1 should be a number``() =
        1 |> should not' (be NaN)

    [<Test>]
    member __.``NaN should not be a number``() =
        Double.NaN |> should be NaN

    [<Test>]
    member __.``float number 2[dot]0 should be a number``() =
        2.0 |> should not' (be NaN)

    [<Test>]
    member __.``float number 2[dot]0 should fail to not be a number``() =
        shouldFail(fun () -> 2.0 |> should be NaN)
