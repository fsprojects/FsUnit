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
        null |> should be Null

    [<Fact>] member test.
     ``non-null should fail to be  Null`` ()=
        "something" |> should not' (be Null)

    [<Fact>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not' (be Null)
