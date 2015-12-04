namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be Null tests`` ()=
    [<Fact>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<Fact>] member test.
     ``null should fail to not be Null`` ()=
        shouldFail (fun () -> null |> should not' (be Null))

    [<Fact>] member test.
     ``non-null should fail to be Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)

    [<Fact>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not' (be Null)

    [<Fact>] member test.
     ``null should be null`` ()=
        null |> should be null

    [<Fact>] member test.
     ``null should fail to not be null`` ()=
        shouldFail (fun () -> null |> should not' (be null))

    [<Fact>] member test.
     ``non-null should fail to be null`` ()=
        shouldFail (fun () -> "something" |> should be null)

    [<Fact>] member test.
     ``non-null should not be null`` ()=
        "something" |> should not' (be null)
