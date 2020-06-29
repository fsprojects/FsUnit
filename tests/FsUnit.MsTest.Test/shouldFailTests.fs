namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``shouldFail tests`` ()=
    [<TestMethod>] member test.
     ``empty List should fail to contain item`` ()=
        shouldFail (fun () -> [] |> should contain 1)

    [<TestMethod>] member test.
     ``non-null should fail to be  Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)

    [<TestMethod>] member test.
     ``shouldFail should fail when everything is OK`` ()=
        shouldFail (fun () -> shouldFail id)

    [<TestMethod>] member test.
     ``shouldFaild should throw an exception`` ()=
        (fun () -> shouldFail id)
        |> should throw typeof<AssertFailedException>

    [<TestMethod>] member test.
     ``shouldFaild should not throw an exception when fail`` ()=
        (fun () -> shouldFail (fun () -> [] |> should contain 1))
        |> should not' (throw typeof<AssertFailedException>)
