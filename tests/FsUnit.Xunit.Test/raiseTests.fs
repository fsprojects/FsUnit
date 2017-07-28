namespace FsUnit.Test
open System
open Xunit
open FsUnit.Xunit
open NHamcrest.Core

exception TestException

type ApplicationException(msg : string) =
    inherit Exception(msg)

type ``raise tests`` ()=
    [<Fact>] member test.
     ``should pass when exception of expected type is thrown`` ()=
        (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<Fact>] member test.
     ``should fail when exception is not thrown`` ()=
        (fun () -> ()) |> should not' (throw typeof<Exception>)

    [<Fact>] member test.
     ``should pass when negated and exception is not thrown`` ()=
        (fun () ->()) |> should not' (throw typeof<Exception>)

    [<Fact>] member test.
     ``should fail when negated and exception is thrown`` ()=
            (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<Fact>] member test.
     ``should fail when exception thrown is not the type expected`` ()=
            (fun () -> raise TestException |> ignore) |> should not' (throw typeof<ApplicationException>)

    [<Fact>] member test.
     ``should pass when exception of expected type with expected message is thrown`` ()=
            let msg = "BOOM!" in
            (fun () -> raise (ApplicationException msg) |> ignore) |> should (throwWithMessage msg) typeof<ApplicationException>

    [<Fact>] member test.
     ``should fail when exception of expected type with unexpected message is thrown`` ()=
        shouldFail (fun () ->
            (fun () -> raise (ApplicationException "BOOM!") |> ignore) |> should (throwWithMessage "CRASH!") typeof<ApplicationException>)

    [<Fact>] member test.
     ``should fail when exception of unexpected type with expected message is thrown`` ()=
        shouldFail (fun () ->
            let msg = "BOOM!" in
            (fun () -> raise (ApplicationException msg) |> ignore) |> should (throwWithMessage msg) typeof<ArgumentException>)

    [<Fact>] member test.
     ``should fail when negated and exception of expected type with expected message is thrown`` ()=
        shouldFail (fun () ->
            let msg = "BOOM!" in
            (fun () -> raise (ApplicationException msg) |> ignore) |> should not' ((throwWithMessage msg) typeof<ApplicationException>))

    [<Fact>] member test.
     ``should pass when negated and exception of expected type with unexpected message is thrown`` ()=
            (fun () -> raise (ApplicationException "BOOM!") |> ignore) |> should not' ((throwWithMessage "CRASH!") typeof<ApplicationException>)

    [<Fact>] member test.
     ``should pass when negated and exception of unexpected type with expected message is thrown`` ()=
            let msg = "BOOM!" in
            (fun () -> raise (ApplicationException msg) |> ignore) |> should not' ((throwWithMessage msg) typeof<ArgumentException>)