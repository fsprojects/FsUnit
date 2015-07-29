namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be Null tests`` ()=
    [<TestMethod>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<TestMethod>] member test.
     ``null should fail to not be Null`` ()=
        null |> should be Null

    [<TestMethod>] member test.
     ``non-null should fail to be  Null`` ()=
        "something" |> should not' (be Null)

    [<TestMethod>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not' (be Null)
