namespace FsUnit.Test
open System
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``shouldFail tests`` ()=
    [<Test>] member test.
     ``empty List should fail to contain item`` ()=
        shouldFail (fun () -> [] |> should contain 1)

    [<Test>] member test.
     ``non-null should fail to be  Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)

    [<Test>] member test.
     ``shouldFail should fail when everything is OK`` ()=
        shouldFail (fun () -> shouldFail id)

    [<Test>] member test.
     ``shouldFaild should throw an exception`` ()=
        (fun () -> shouldFail id)
        |> should throw typeof<Exception> // ???

    [<Test>] member test.
     ``shouldFaild should not throw an exception when fail`` ()=
        (fun () -> shouldFail (fun () -> [] |> should contain 1))
        |> should not' (throw typeof<Exception>) // ???