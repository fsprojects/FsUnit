namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``should endWith tests``() =
    [<TestMethod>]
    member __.``empty string should end with ""``() =
        "" |> should endWith ""

    [<TestMethod>]
    member __.``ships should end with ps``() =
        "ships" |> should endWith "ps"

    [<TestMethod>]
    member __.``ships should not end with ss``() =
        "ships" |> should not' (endWith "ss")
