namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``shouldFail tests`` ()=
    [<Test>] member test.
     ``empty List should fail to contain item`` ()=
        shouldFail (fun () -> [] |> should contain 1)

    [<Test>] member test.
     ``non-null should fail to be  Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)
