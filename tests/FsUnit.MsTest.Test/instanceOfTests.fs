namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``Instance Of tests`` ()=
    [<TestMethod>] member test.
     ``int should be instance of type Object`` ()=
        1 |> should be instanceOfType<obj>

    [<TestMethod>] member test.
     ``int should be instance of type int`` ()=
        1 |> should be instanceOfType<int>

    [<TestMethod>] member test.
     ``string should be instance of type string`` ()=
        "test" |> should be instanceOfType<string>

    [<TestMethod>] member test.
     ``list should be instance of type fsharplist`` ()=
        [] |> should be instanceOfType<list<_>>

    [<TestMethod>] member test.
     ``array should be instance of type array`` ()=
        [||] |> should be instanceOfType<array<_>>

    [<TestMethod>] member test.
     ``string should not be instance of type int`` ()=
        "test" |> should not' (be instanceOfType<int>)
