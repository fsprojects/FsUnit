namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be False tests``() =
    [<TestMethod>]
    member __.``false should be False``() =
        false |> should be False

    [<TestMethod>]
    member __.``true should fail to be False``() =
        true |> should not' (be False)

    [<TestMethod>]
    member __.``true should not be False``() =
        true |> should not' (be False)

    [<TestMethod>]
    member __.``false should fail to not be False``() =
        false |> should be False
