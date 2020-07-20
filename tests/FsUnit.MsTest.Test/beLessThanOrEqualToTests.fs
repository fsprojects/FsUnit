namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be lessThanOrEqualTo tests``() =
    [<TestMethod>]
    member __.``10 should be less than 11``() =
        10 |> should be (lessThanOrEqualTo 11)

    [<TestMethod>]
    member __.``10[dot]0 should be less than 10[dot]1``() =
        10.0 |> should be (lessThanOrEqualTo 10.1)

    [<TestMethod>]
    member __.``10 should not be less than 9``() =
        10 |> should not' (be lessThanOrEqualTo 9)

    [<TestMethod>]
    member __.``9[dot]2 should not be less than 9[dot]1``() =
        9.2 |> should not' (be lessThanOrEqualTo 9.1)

    [<TestMethod>]
    member __.``9[dot]1 should be less than or equal to 9[dot]1``() =
        9.1 |> should be (lessThanOrEqualTo 9.1)
