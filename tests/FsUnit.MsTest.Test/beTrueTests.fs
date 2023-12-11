namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beTrueTests``() =

    [<TestMethod>]
    member _.``true should be True``() =
        true |> should be True

    [<TestMethod>]
    member _.``false should fail to be True``() =
        false |> should not' (be True)

    [<TestMethod>]
    member _.``false should not be True``() =
        false |> should not' (be True)

    [<TestMethod>]
    member _.``false should fail to not be False``() =
        shouldFail(fun () -> true |> should not' (be True))
