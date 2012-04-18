namespace FsUnit.Test
open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

exception TestException
[<TestClass>]
type ``raise tests`` ()=
    [<TestMethod>] member test.
     ``should pass when exception of expected type is thrown`` ()=
        (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<TestMethod>] member test.
     ``should fail when exception is not thrown`` ()=
        (fun () -> ()) |> should not (throw typeof<Exception>)
        
    [<TestMethod>] member test.
     ``should pass when negated and exception is not thrown`` ()=
        (fun () ->()) |> should not (throw typeof<Exception>)

    [<TestMethod>] member test.
     ``should fail when negated and exception is thrown`` ()=
            (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<TestMethod>] member test.
     ``should fail when exception thrown is not the type expected`` ()=
            (fun () -> raise TestException |> ignore) |> should not (throw typeof<ApplicationException>)