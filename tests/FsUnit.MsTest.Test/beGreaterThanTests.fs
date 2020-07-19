namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be greaterThan tests`` ()=

    [<TestMethod>] member test.
     ``11 should be greater than 10`` ()=
        11 |> should be (greaterThan 10)

    [<TestMethod>] member test.
     ``11.1 should be greater than 11.0`` ()=
        11.1 |> should be (greaterThan 11.0)

    [<TestMethod>] member test.
     ``9 should not be greater than 10`` ()=
        9 |> should not' (be greaterThan 10)

    [<TestMethod>] member test.
     ``9.1 should not be greater than 9.2`` ()=
        9.1 |> should not' (be greaterThan 9.2)

    [<TestMethod>] member test.
     ``9.2 should not be greater than 9.2`` ()=
        9.2 |> should not' (be greaterThan 9.2)

    [<TestMethod>] member test.
     ``9.2 should not be greater than 9.2 but message should be equal`` ()=
         (fun () -> 9.2 |> should be (greaterThan 9.2))
         |> fun f -> Assert.ThrowsException<AssertFailedException>(f)
         |> fun e -> e.Message
         |> should equal ("Greater than 9.2 was 9.2")
