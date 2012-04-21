namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDepricated

[<TestClass>]
type ``be NullOrEmptyString tests`` ()=
    [<TestMethod>] member test.
     ``empty string should be NullOrEmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<TestMethod>] member test.
     ``null should be NullOrEmptyString`` ()=
        null |> should be NullOrEmptyString
        
    [<TestMethod>] member test.
     ``non-empty string should fail to be NullOrEmptyString`` ()=
        "a string" |> should not (be NullOrEmptyString)
        
    [<TestMethod>] member test.
     ``non-empty string should not be NullOrEmptyString`` ()=
        "a string" |> should not (be NullOrEmptyString)

    [<TestMethod>] member test.
     ``empty string should fail to not be NullOrEmptyString`` ()=
        "" |> should be NullOrEmptyString
        
    [<TestMethod>] member test.
     ``null should fail to not be NullOrEmptyString`` ()=
        null |> should be NullOrEmptyString
