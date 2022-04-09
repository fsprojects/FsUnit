namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``should startWith tests``() =
    [<Test>]
    member _.``empty string should start with ""``() =
        "" |> should startWith ""

    [<Test>]
    member _.``ships should start with ps``() =
        "ships" |> should startWith "sh"

    [<Test>]
    member _.``ships should not start with ss``() =
        "ships" |> should not' (startWith "ss")
