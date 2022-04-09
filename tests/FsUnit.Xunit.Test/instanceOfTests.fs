namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``Instance Of tests``() =
    [<Fact>]
    member _.``int should be instance of type Object``() =
        1 |> should be instanceOfType<obj>

    [<Fact>]
    member _.``int should be instance of type int``() =
        1 |> should be instanceOfType<int>

    [<Fact>]
    member _.``string should be instance of type string``() =
        "test" |> should be instanceOfType<string>

    [<Fact>]
    member _.``list should be instance of type fsharplist``() =
        [] |> should be instanceOfType<list<_>>

    [<Fact>]
    member _.``array should be instance of type array``() =
        [||] |> should be instanceOfType<array<_>>

    [<Fact>]
    member _.``string should not be instance of type int``() =
        "test" |> should not' (be instanceOfType<int>)
