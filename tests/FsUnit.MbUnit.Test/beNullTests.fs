namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``be Null tests`` ()=
    [<Test>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<Test>] member test.
     ``null should fail to not be Null`` ()=
        shouldFail (fun () -> null |> should not' (be Null))

    [<Test>] member test.
     ``non-null should fail to be Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)

    [<Test>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not' (be Null)

    [<Test>] member test.
     ``null should be null`` ()=
        null |> should be null

    [<Test>] member test.
     ``null should fail to not be null`` ()=
        shouldFail (fun () -> null |> should not' (be null))

    [<Test>] member test.
     ``non-null should fail to be null`` ()=
        shouldFail (fun () -> "something" |> should be null)

    [<Test>] member test.
     ``non-null should not be null`` ()=
        "something" |> should not' (be null)

