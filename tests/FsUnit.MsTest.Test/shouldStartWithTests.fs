namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``should startWith tests`` ()=
    [<TestMethod>] member test.
     ``empty string should start with ""`` ()=
        "" |> should startWith ""

    [<TestMethod>] member test.
     ``ships should start with ps`` ()=
        "ships" |> should startWith "sh"

    [<TestMethod>] member test.
     ``ships should not start with ss`` ()=
        "ships" |> should not' (startWith "ss")

