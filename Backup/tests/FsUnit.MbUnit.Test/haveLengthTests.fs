namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
open FsUnitDepricated

[<TestFixture>]
type ``haveLength tests`` ()=
    // F# List
    [<Test>] member test.
     ``List with 2 items should have Length 2`` ()=
        [1;2].Length |> should equal 2

    [<Test>] member test.
     ``empty List should fail to have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<Test>] member test.
     ``empty List should not have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<Test>] member test.
     ``List with 1 item should fail to not have Length 1`` ()=
        [1].Length |> should equal 1
        
    // Array
    [<Test>] member test.
     ``Array with 1 item should have Length 1`` ()=
        [|1|].Length |> should equal 1

    [<Test>] member test.
     ``empty Array should fail to have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<Test>] member test.
     ``empty Array should not have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<Test>] member test.
     ``Array with 1 item should fail to not have Length 1`` ()=
        [|1|].Length |> should equal 1

