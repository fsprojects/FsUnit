namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``equalWithin tests``() =

    [<Test>]
    member _.``should equal within tolerance``() =
        10.1 |> should (equalWithin 0.1) 10.11

    [<Test>]
    member _.``should equal within tolerance with different types``() =
        10 |> should (equalWithin 0.1) 10

    [<Test>]
    member _.``should equal within tolerance with same types``() =
        10 |> should (equalWithin 1) 11

    [<Test>]
    member _.``should equal within tolerance when exactly equal``() =
        10.11 |> should (equalWithin 0.0001) 10.11

    [<Test>]
    member _.``should equal within tolerance when less than``() =
        10.09 |> should (equalWithin 0.1) 10.11

    [<Test>]
    member _.``should not equal within tolerance``() =
        10.1 |> should not' ((equalWithin 0.001) 10.11)

    [<Test>]
    member _.``should fail outside tolerance``() =
        10.1 |> should not' ((equalWithin 0.01) 10.4)
