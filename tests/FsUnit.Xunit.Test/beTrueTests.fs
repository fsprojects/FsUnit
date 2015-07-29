namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be True tests`` ()=
    [<Fact>] member test.
     ``true should be True`` ()=
        true |> should be True

    [<Fact>] member test.
     ``false should fail to be True`` ()=
        false |> should not' (be True)

    [<Fact>] member test.
     ``false should not be True`` ()=
        false |> should not' (be True)

    [<Fact>] member test.
     ``true should fail to not be True`` ()=
        true |> should be True
