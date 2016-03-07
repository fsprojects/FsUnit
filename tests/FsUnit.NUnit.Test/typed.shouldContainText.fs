namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldContainText tests`` ()=
    [<Test>] member test.
     ``empty string should contain ""`` ()=
        "" |> shouldContainText ""

    [<Test>] member test.
     ``ships should contain hip`` ()=
        "ships" |> shouldContainText "hip"

