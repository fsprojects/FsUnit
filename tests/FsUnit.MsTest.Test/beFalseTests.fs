namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beFalseTests``() =

    [<TestMethod>]
    member _.``false should be False``() =
        false |> should be False

    [<TestMethod>]
    member _.``true should fail to be False``() =
        true |> should not' (be False)

    [<TestMethod>]
    member _.``true should not be False``() =
        true |> should not' (be False)

    [<TestMethod>]
    member _.``false should fail to not be False``() =
        false |> should be False
