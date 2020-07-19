namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be SameAs tests``() =
    let anObj = new obj()
    let otherObj = new obj()

    [<Fact>]
    member __.``an object should be the same as itself``() =
        anObj |> should be (sameAs anObj)

    [<Fact>]
    member __.``an object should fail to be same as different object``() =
        anObj |> should not' (be(sameAs otherObj))

    [<Fact>]
    member __.``an object should not be same as different object``() =
        anObj |> should not' (be sameAs otherObj)

    [<Fact>]
    member __.``an object should fail to not be same as itself``() =
        anObj |> should be (sameAs anObj)
