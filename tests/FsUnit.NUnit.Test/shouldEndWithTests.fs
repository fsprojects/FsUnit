namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``should endWith tests``() =
    [<Test>]
    member _.``empty string should end with ""``() =
        "" |> should endWith ""

    [<Test>]
    member _.``ships should end with ps``() =
        "ships" |> should endWith "ps"

    [<Test>]
    member _.``ships should not end with ss``() =
        "ships" |> should not' (endWith "ss")
