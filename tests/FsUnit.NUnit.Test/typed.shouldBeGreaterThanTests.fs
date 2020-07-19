namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeGreaterThan tests``() =
    [<Test>]
    member __.``11 should be greater than 10``() =
        11 |> shouldBeGreaterThan 10

    [<Test>]
    member __.``11.1 should be greater than 11.0``() =
        11.1 |> shouldBeGreaterThan 11.0
