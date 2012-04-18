namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be SameAs tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()

    [<TestMethod>] member test.
     ``an object should be the same as itself`` ()=
        anObj |> should be (sameAs anObj)

    [<TestMethod>] member test.
     ``an object should fail to be same as different object`` ()=
        anObj |> should not (be (sameAs otherObj))
        
    [<TestMethod>] member test.
     ``an object should not be same as different object`` ()=
        anObj |> should not (be sameAs otherObj)

    [<TestMethod>] member test.
     ``an object should fail to not be same as itself`` ()=
        anObj |> should be (sameAs anObj)
