namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldContainText tests``() =
    [<Test>]
    member __.``empty string should contain ""``() =
        "" |> shouldContainText ""

    [<Test>]
    member __.``ships should contain hip``() =
        "ships" |> shouldContainText "hip"
