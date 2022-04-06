namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldBeEmpty tests``() =
    [<Fact>]
    member __.``empty List should be Empty``() =
        [] |> shouldBeEmpty

    [<Fact>]
    member __.``non-empty List should fail to be Empty``() =
        shouldFail(fun () -> [ 1 ] |> shouldBeEmpty)

    [<Fact>]
    member __.``empty Array should be Empty``() =
        [||] |> shouldBeEmpty

    [<Fact>]
    member __.``non-empty Array should fail to be Empty``() =
        shouldFail(fun () -> [| 1 |] |> shouldBeEmpty)

    [<Fact>]
    member __.``empty Seq should be Empty``() =
        Seq.empty |> shouldBeEmpty

    [<Fact>]
    member __.``non-empty Seq should fail to be Empty``() =
        shouldFail(fun () -> seq { 1 } |> shouldBeEmpty)
