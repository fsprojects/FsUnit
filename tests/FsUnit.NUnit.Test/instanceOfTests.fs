namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``Instance Of tests`` ()=
    [<Test>] member test.
     ``int should be instance of type Object`` ()=
        1 |> should be (instanceOf typeof<obj>)

    [<Test>] member test.
     ``int should be instance of type int`` ()=
        1 |> should be (instanceOf typeof<int>)

    [<Test>] member test.
     ``string should be instance of type string`` ()=
        "teste" |> should be (instanceOf typeof<string>)

    [<Test>] member test.
     ``list should be instance of type fsharplist`` ()=
        [] |> should be (instanceOf typeof<list<_>>)

    [<Test>] member test.
     ``array should be instance of type array`` ()=
        [||] |> should be (instanceOf typeof<array<_>>)

