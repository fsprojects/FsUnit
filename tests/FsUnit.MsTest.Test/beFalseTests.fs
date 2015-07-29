namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``be False tests`` ()=
    [<TestMethod>] member test.
     ``false should be False`` ()=
        false |> should be False

    [<TestMethod>] member test.
     ``true should fail to be False`` ()=
        true |> should not' (be False)

    [<TestMethod>] member test.
     ``true should not be False`` ()=
        true |> should not' (be False)

    [<TestMethod>] member test.
     ``false should fail to not be False`` ()=
        false |> should be False
