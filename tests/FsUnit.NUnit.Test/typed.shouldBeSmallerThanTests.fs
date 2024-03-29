namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeSmallerThan tests``() =

    [<Test>]
    member _.``10 should be less than 11``() =
        10 |> shouldBeSmallerThan 11

    [<Test>]
    member _.``10 should not be less than 10``() =
        (fun () -> 10 |> shouldBeSmallerThan 10)
        |> shouldFail<AssertionException>

    [<Test>]
    member _.``10[dot]0 should be less than 10[dot]1``() =
        10.0 |> shouldBeSmallerThan 10.1

    [<Test>]
    member _.``10[dot]0 should not be less than 10[dot]0``() =
        (fun () -> 10.0 |> shouldBeSmallerThan 10.0)
        |> shouldFail<AssertionException>
