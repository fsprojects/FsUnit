namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``haveLength tests``() =
    // F# List
    [<Fact>]
    member _.``List with 1 item should have Length 1``() =
        [ 1 ] |> shouldHaveLength 1

    [<Fact>]
    member _.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> shouldHaveLength 1)

    // Array
    [<Fact>]
    member _.``Array with 1 item should have Length 1``() =
        [| 1 |] |> shouldHaveLength 1

    [<Fact>]
    member _.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> shouldHaveLength 1)
