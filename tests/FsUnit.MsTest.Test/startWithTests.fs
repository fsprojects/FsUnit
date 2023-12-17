namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``startWithTests``() =

    [<TestMethod>]
    member _.``empty string should start with ""``() =
        "" |> should startWith ""

    [<TestMethod>]
    member _.``ships should start with ps``() =
        "ships" |> should startWith "sh"

    [<TestMethod>]
    member _.``ships should not start with ss``() =
        "ships" |> should not' (startWith "ss")

    [<TestMethod>]
    member _.``ships should not start with ss but message should be equal``() =
        (fun () -> "ships" |> should startWith "ss")
        |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
        |> fun e -> e.Message
        |> should equal ("ss was \"ships\"")
