namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be True tests`` ()=
    [<TestMethod>] member test.
     ``true should be True`` ()=
        true |> should be True

    [<TestMethod>] member test.
     ``false should fail to be True`` ()=
        false |> should not (be True)

    [<TestMethod>] member test.
     ``false should not be True`` ()=
        false |> should not (be True)

    [<TestMethod>] member test.
     ``true should fail to not be True`` ()=
        true |> should be True
