namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``should endWith tests``() =
    [<TestMethod>]
    member _.``empty string should end with ""``() =
        "" |> should endWith ""

    [<TestMethod>]
    member _.``ships should end with ps``() =
        "ships" |> should endWith "ps"

    [<TestMethod>]
    member _.``ships should not end with ss``() =
        "ships" |> should not' (endWith "ss")
