namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``equalWithinTests``() =

    [<TestMethod>]
    member _.``should equal within tolerance``() =
        10.1 |> should (equalWithin 0.1) 10.11

    [<TestMethod>]
    member _.``should equal within tolerance with different types``() =
        10 |> should (equalWithin 0.1) 10

    [<TestMethod>]
    member _.``should equal within tolerance with same types``() =
        10 |> should (equalWithin 1) 11

    [<TestMethod>]
    member _.``should equal within tolerance when exactly equal``() =
        10.11 |> should (equalWithin 0.1) 10.11

    [<TestMethod>]
    member _.``should equal within tolerance when less than``() =
        10.09 |> should (equalWithin 0.1) 10.11

    [<TestMethod>]
    member _.``should not equal within tolerance``() =
        10.1 |> should not' ((equalWithin 0.001) 10.11)
