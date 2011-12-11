namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be Null tests`` ()=
    [<Test>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<Test>] member test.
     ``null should fail to not be Null`` ()=
        shouldFail (fun () -> null |> should not (be Null))
        
    [<Test>] member test.
     ``non-null should fail to be  Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)
        
    [<Test>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not (be Null)
