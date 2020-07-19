namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``Instance Of tests``() =
    [<Fact>]
    member __.``int should be instance of type Object``() =
        1 |> should be instanceOfType<obj>

    [<Fact>]
    member __.``int should be instance of type int``() =
        1 |> should be instanceOfType<int>

    [<Fact>]
    member __.``string should be instance of type string``() =
        "test" |> should be instanceOfType<string>

    [<Fact>]
    member __.``list should be instance of type fsharplist``() =
        [] |> should be instanceOfType<list<_>>

    [<Fact>]
    member __.``array should be instance of type array``() =
        [||] |> should be instanceOfType<array<_>>

    [<Fact>]
    member __.``string should not be instance of type int``() =
        "test" |> should not' (be instanceOfType<int>)
