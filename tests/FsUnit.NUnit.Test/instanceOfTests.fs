namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``Instance Of tests`` ()=
    [<Test>] member test.
     ``int should be instance of type Object`` ()=
        1 |> should be instanceOfType<obj>

    [<Test>] member test.
     ``int should be instance of type int`` ()=
        1 |> should be instanceOfType<int>

    [<Test>] member test.
     ``string should be instance of type string`` ()=
        "test" |> should be instanceOfType<string>

    [<Test>] member test.
     ``list should be instance of type fsharplist`` ()=
        [] |> should be instanceOfType<list<_>>

    [<Test>] member test.
     ``array should be instance of type array`` ()=
        [||] |> should be instanceOfType<array<_>>

    [<Test>] member test.
     ``string should not be instance of type int`` ()=
        "test" |> should not (be instanceOfType<int>)
