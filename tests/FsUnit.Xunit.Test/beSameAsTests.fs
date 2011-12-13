namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be SameAs tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()

    [<Fact>] member test.
     ``an object should be the same as itself`` ()=
        anObj |> should be (sameAs anObj)

    [<Fact>] member test.
     ``an object should fail to be same as different object`` ()=
        anObj |> should not (be (sameAs otherObj))
        
    [<Fact>] member test.
     ``an object should not be same as different object`` ()=
        anObj |> should not (be sameAs otherObj)

    [<Fact>] member test.
     ``an object should fail to not be same as itself`` ()=
        anObj |> should be (sameAs anObj)
