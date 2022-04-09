namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeGreaterThan tests``() =
    [<Test>]
    member _.``11 should be greater than 10``() =
        11 |> shouldBeGreaterThan 10

    [<Test>]
    member _.``11[dot]1 should be greater than 11[dot]0``() =
        11.1 |> shouldBeGreaterThan 11.0
