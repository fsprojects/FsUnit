namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

[<TestClass>]
type ``should endWith tests`` ()=
    [<TestMethod>] member test.
     ``empty string should end with ""`` ()=
        "" |> should endWith ""

    [<TestMethod>] member test.
     ``ships should end with ps`` ()=
        "ships" |> should endWith "ps"
        
    [<TestMethod>] member test.
     ``ships should not end with ss`` ()=
        "ships" |> should not (endWith "ss")

