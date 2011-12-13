namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be EmptyString tests`` ()=
    [<Fact>] member test.
     ``empty string should be EmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<Fact>] member test.
     ``non-empty string should fail to be EmptyString`` ()=
        "a string" |> should not (be EmptyString)
        
    [<Fact>] member test.
     ``non-empty string should not be EmptyString`` ()=
        "a string" |> should not (be EmptyString)

    [<Fact>] member test.
     ``empty string should fail to not be EmptyString`` ()=
        "" |> should be EmptyString