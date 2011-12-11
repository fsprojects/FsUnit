namespace LightBulb.Tests

open Xunit
open FsUnit.Xunit

type LightBulb(state) =
    member x.On = state
    override x.ToString() =
        match x.On with
        | true  -> "On"
        | false -> "Off"

type ``Given a LightBulb that has had its state set to true`` ()=
    let lightBulb = new LightBulb(true)

    [<Fact>] member x.
     ``when I ask whether it is On it answers true.`` ()=
            lightBulb.On |> should be True

    [<Fact>] member x.
     ``when I convert it to a string it becomes "On".`` ()=
            string lightBulb |> should equal "On"

type ``Given a LightBulb that has had its state set to false`` ()=
    let lightBulb = new LightBulb(false)
    
    [<Fact>] member x.
     ``when I ask whether it is On it answers false.`` ()=
            lightBulb.On |> should be False
    
    [<Fact>] member x.
     ``when I convert it to a string it becomes "Off".`` ()=
            string lightBulb |> should equal "Off"
