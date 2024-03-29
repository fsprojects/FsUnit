namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``beInRangeTests``() =

    [<TestMethod>]
    member _.``25 should be in range from 5 to 30``() =
        25 |> should be (inRange 5 30)

    [<TestMethod>]
    member _.``-13 should not be in range from 0 to 43``() =
        -13 |> should not' (be inRange 0 43)
