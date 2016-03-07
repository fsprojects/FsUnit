namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeGreaterThan tests`` ()=
    [<Test>] member test.
     ``11 should be greater than 10`` ()=
        11 |> shouldBeGreaterThan 10

    [<Test>] member test.
     ``11.1 should be greater than 11.0`` ()=
        11.1 |> shouldBeGreaterThan 11.0