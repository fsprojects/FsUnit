namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``instanceOfTypeTests``() =

    [<TestMethod>]
    member _.``int should be instance of type Object``() =
        1 |> should be instanceOfType<obj>

    [<TestMethod>]
    member _.``int should be instance of type int``() =
        1 |> should be instanceOfType<int>

    [<TestMethod>]
    member _.``string should be instance of type string``() =
        "test" |> should be instanceOfType<string>

    [<TestMethod>]
    member _.``list should be instance of type fsharplist``() =
        [] |> should be instanceOfType<list<_>>

    [<TestMethod>]
    member _.``array should be instance of type array``() =
        [||] |> should be instanceOfType<array<_>>

    [<TestMethod>]
    member _.``string should not be instance of type int``() =
        "test" |> should not' (be instanceOfType<int>)
