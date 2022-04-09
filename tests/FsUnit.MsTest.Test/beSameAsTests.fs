namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be SameAs tests``() =
    let anObj = obj()
    let otherObj = obj()

    [<TestMethod>]
    member _.``an object should be the same as itself``() =
        anObj |> should be (sameAs anObj)

    [<TestMethod>]
    member _.``an object should fail to be same as different object``() =
        anObj |> should not' (be(sameAs otherObj))

    [<TestMethod>]
    member _.``an object should not be same as different object``() =
        anObj |> should not' (be sameAs otherObj)

    [<TestMethod>]
    member _.``an object should fail to not be same as itself``() =
        anObj |> should be (sameAs anObj)
