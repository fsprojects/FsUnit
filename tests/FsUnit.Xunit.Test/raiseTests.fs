namespace FsUnit.Test
open System
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

exception TestException

type ``raise tests`` ()=
    [<Fact>] member test.
     ``should pass when exception of expected type is thrown`` ()=
        (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<Fact>] member test.
     ``should fail when exception is not thrown`` ()=
        (fun () -> ()) |> should not (throw typeof<Exception>)
        
    [<Fact>] member test.
     ``should pass when negated and exception is not thrown`` ()=
        (fun () ->()) |> should not (throw typeof<Exception>)

    [<Fact>] member test.
     ``should fail when negated and exception is thrown`` ()=
            (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<Fact>] member test.
     ``should fail when exception thrown is not the type expected`` ()=
            (fun () -> raise TestException |> ignore) |> should not (throw typeof<ApplicationException>)