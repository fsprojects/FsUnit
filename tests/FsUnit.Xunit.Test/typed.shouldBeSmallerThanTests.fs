namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldBeSmallerThan tests``() =
    [<Fact>]
    member __.``10 should be less than 11``() =
        10 |> shouldBeSmallerThan 11

    [<Fact>]
    member __.``10 should not be less than 10``() =
        (fun () -> 10 |> shouldBeSmallerThan 10)
        |> shouldFail<AssertionException>

    [<Fact>]
    member __.``10[dot]0 should be less than 10[dot]1``() =
        10.0 |> shouldBeSmallerThan 10.1

    [<Fact>]
    member __.``10[dot]0 should not be less than 10[dot]0``() =
        (fun () -> 10.0 |> shouldBeSmallerThan 10.0)
        |> shouldFail<AssertionException>
