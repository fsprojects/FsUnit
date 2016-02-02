namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnit.Typed

[<TestFixture>]
type ``Typed: shouldEqual null tests`` ()=
    [<Test>] member test.
     ``null should be null`` ()=
        null |> shouldEqual null

    [<Test>] member test.
     ``null should fail to not be null`` ()=
        shouldFail (fun () -> null |> shouldNotEqual null)
