namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be EmptyString tests`` ()=
    [<TestMethod>] member test.
     ``empty string should be EmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<TestMethod>] member test.
     ``non-empty string should fail to be EmptyString`` ()=
        "a string" |> should not' (be EmptyString)

    [<TestMethod>] member test.
     ``non-empty string should not be EmptyString`` ()=
        "a string" |> should not' (be EmptyString)

    [<TestMethod>] member test.
     ``empty string should fail to not be EmptyString`` ()=
        "" |> should be EmptyString