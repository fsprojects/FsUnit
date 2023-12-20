namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldBeEmpty tests``() =

    [<Fact>]
    member _.``empty List should be Empty``() =
        [] |> shouldBeEmpty

    [<Fact>]
    member _.``non-empty List should fail to be Empty``() =
        shouldFail(fun () -> [ 1 ] |> shouldBeEmpty)

    [<Fact>]
    member _.``empty Array should be Empty``() =
        [||] |> shouldBeEmpty

    [<Fact>]
    member _.``non-empty Array should fail to be Empty``() =
        shouldFail(fun () -> [| 1 |] |> shouldBeEmpty)

    [<Fact>]
    member _.``empty Seq should be Empty``() =
        Seq.empty |> shouldBeEmpty

    [<Fact>]
    member _.``non-empty Seq should fail to be Empty``() =
        shouldFail(fun () -> seq { 1 } |> shouldBeEmpty)
