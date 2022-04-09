namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldContainText tests``() =
    [<Test>]
    member _.``empty string should contain ""``() =
        "" |> shouldContainText ""

    [<Test>]
    member _.``ships should contain hip``() =
        "ships" |> shouldContainText "hip"
