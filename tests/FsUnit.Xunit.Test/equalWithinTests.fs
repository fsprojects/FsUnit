namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

(* Thanks to erdoll for this suggestion: https://fsunit.codeplex.com/discussions/269320 *)

type ``equalWithin tests``() =
    [<Fact>]
    member __.``should equal within tolerance``() =
        10.1 |> should (equalWithin 0.1) 10.11

    [<Fact>]
    member __.``should equal within tolerance with different types``() =
        10 |> should (equalWithin 0.1) 10

    [<Fact>]
    member __.``should equal within tolerance with same types``() =
        10 |> should (equalWithin 1) 11

    [<Fact>]
    member __.``should equal within tolerance when exactly equal``() =
        10.11 |> should (equalWithin 0.1) 10.11

    [<Fact>]
    member __.``should equal within tolerance when less than``() =
        10.09 |> should (equalWithin 0.1) 10.11

    [<Fact>]
    member __.``should not equal within tolerance``() =
        10.1 |> should not' ((equalWithin 0.001) 10.11)
