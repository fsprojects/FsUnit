namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be inRange tests`` ()=
    [<Test>] member test.
     ``25 should be in range from 5 to 30`` ()=
        25 |> should be (inRange 5 30)

    [<Test>] member test.
     ``-13 should not be in range from 0 to 43`` ()=
        -13 |> should not' (be inRange 0 43)
