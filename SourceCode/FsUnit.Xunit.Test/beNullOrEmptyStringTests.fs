namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type ``be NullOrEmptyString tests`` ()=
    [<Fact>] member test.
     ``empty string should be NullOrEmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<Fact>] member test.
     ``null should be NullOrEmptyString`` ()=
        null |> should be NullOrEmptyString
        
    [<Fact>] member test.
     ``non-empty string should fail to be NullOrEmptyString`` ()=
        "a string" |> should not (be NullOrEmptyString)
        
    [<Fact>] member test.
     ``non-empty string should not be NullOrEmptyString`` ()=
        "a string" |> should not (be NullOrEmptyString)

    [<Fact>] member test.
     ``empty string should fail to not be NullOrEmptyString`` ()=
        "" |> should be NullOrEmptyString
        
    [<Fact>] member test.
     ``null should fail to not be NullOrEmptyString`` ()=
        null |> should not (be NullOrEmptyString)
