namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``Instance Of tests``() =
    [<Test>]
    member __.``int should be instance of type Object``() =
        1 |> should be instanceOfType<obj>

    [<Test>]
    member __.``int should be instance of type int``() =
        1 |> should be instanceOfType<int>

    [<Test>]
    member __.``string should be instance of type string``() =
        "test" |> should be instanceOfType<string>

    [<Test>]
    member __.``list should be instance of type fsharplist``() =
        [] |> should be instanceOfType<list<_>>

    [<Test>]
    member __.``array should be instance of type array``() =
        [||] |> should be instanceOfType<array<_>>

    [<Test>]
    member __.``string should not be instance of type int``() =
        "test" |> should not' (be instanceOfType<int>)
