namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be NullOrEmptyString tests`` ()=
    [<Test>] member test.
     ``empty string should be NullOrEmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<Test>] member test.
     ``null should be NullOrEmptyString`` ()=
        null |> should be NullOrEmptyString
        
    [<Test>] member test.
     ``non-empty string should fail to be NullOrEmptyString`` ()=
        shouldFail (fun () -> "a string" |> should be NullOrEmptyString)
        
    [<Test>] member test.
     ``non-empty string should not be NullOrEmptyString`` ()=
        "a string" |> should not (be NullOrEmptyString)

    [<Test>] member test.
     ``empty string should fail to not be NullOrEmptyString`` ()=
        shouldFail (fun () -> "" |> should not (be NullOrEmptyString))
        
    [<Test>] member test.
     ``null should fail to not be NullOrEmptyString`` ()=
        shouldFail (fun () -> null |> should not (be NullOrEmptyString))
