namespace $rootnamespace$.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

type LightBulb(state) =
   member x.On = state
   override x.ToString() =
       match x.On with
       | true  -> "On"
       | false -> "Off"

[<TestClass>] 
type ``Given a LightBulb that has had its state set to true`` ()=
   let lightBulb = new LightBulb(true)

   [<TestMethod>] member test.
    ``when I ask whether it is On it answers true.`` ()=
           lightBulb.On |> should be True

   [<TestMethod>] member test.
    ``when I convert it to a string it becomes "On".`` ()=
           string lightBulb |> should equal "On"
