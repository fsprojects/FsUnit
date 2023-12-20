namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open System

[<TestClass>]
type ``beNaNTests``() =

    [<TestMethod>]
    member _.``Number 1 should be a number``() =
        1 |> should not' (be NaN)

    [<TestMethod>]
    member _.``NaN should not be a number``() =
        Double.NaN |> should be NaN

    [<TestMethod>]
    member _.``float number 2.0 should be a number``() =
        2.0 |> should not' (be NaN)

    [<TestMethod>]
    member _.``float number 2.0 should fail to not be a number``() =
        shouldFail(fun () -> 2.0 |> should be NaN)
