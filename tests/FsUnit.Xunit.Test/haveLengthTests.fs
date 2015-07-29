namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDeprecated

type ``haveLength tests`` ()=
    // F# List
    [<Fact>] member test.
     ``List with 1 item should have Length 1`` ()=
        [1].Length |> should equal 1

    [<Fact>] member test.
     ``empty List should fail to have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<Fact>] member test.
     ``empty List should not have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<Fact>] member test.
     ``List with 1 item should fail to not have Length 1`` ()=
        [1].Length |> should equal 1
        
    // Array
    [<Fact>] member test.
     ``Array with 1 item should have Length 1`` ()=
        [|1|].Length |> should equal 1

    [<Fact>] member test.
     ``empty Array should fail to have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<Fact>] member test.
     ``empty Array should not have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<Fact>] member test.
     ``Array with 1 item should fail to not have Length 1`` ()=
        [|1|].Length |> should equal 1

