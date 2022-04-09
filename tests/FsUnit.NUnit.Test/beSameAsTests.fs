namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be SameAs tests``() =
    let anObj = obj()
    let otherObj = obj()

    [<Test>]
    member _.``an object should be the same as itself``() =
        anObj |> should be (sameAs anObj)

    [<Test>]
    member _.``an object should fail to be same as different object``() =
        shouldFail(fun () -> anObj |> should be (sameAs otherObj))

    [<Test>]
    member _.``an object should not be same as different object``() =
        anObj |> should not' (be sameAs otherObj)

    [<Test>]
    member _.``an object should fail to not be same as itself``() =
        shouldFail(fun () -> anObj |> should not' (be sameAs anObj))
