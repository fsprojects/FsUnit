namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDeprecated

[<TestClass>]
type ``haveLength tests`` ()=
    // F# List
    [<TestMethod>] member test.
     ``List with 1 item should have Length 1`` ()=
        [1].Length |> should equal 1

    [<TestMethod>] member test.
     ``empty List should fail to have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<TestMethod>] member test.
     ``empty List should not have Length 1`` ()=
        [].Length |> should not (equal 1)

    [<TestMethod>] member test.
     ``List with 1 item should fail to not have Length 1`` ()=
        [1].Length |> should equal 1
        
    // Array
    [<TestMethod>] member test.
     ``Array with 1 item should have Length 1`` ()=
        [|1|].Length |> should equal 1

    [<TestMethod>] member test.
     ``empty Array should fail to have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<TestMethod>] member test.
     ``empty Array should not have Length 1`` ()=
        [||].Length |> should not (equal 1)

    [<TestMethod>] member test.
     ``Array with 1 item should fail to not have Length 1`` ()=
        [|1|].Length |> should equal 1

