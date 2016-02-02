namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnit.Typed

[<TestFixture>]
type ``shouldBeSmallerThan tests`` ()=
    [<Test>] member test.
     ``10 should be less than 11`` ()=
        10 |> shouldBeSmallerThan 11

    [<Test>] member test.
     ``10.0 should be less than 10.1`` ()=
        10.0 |> shouldBeSmallerThan 10.1
