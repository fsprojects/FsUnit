namespace FsUnit.Test
open System
open NUnit.Framework
open FsUnit
open FsUnitDepricated

exception TestException

[<TestFixture>]
type ``raise tests`` ()=
    [<Test>] member test.
     ``should pass when exception of expected type is thrown`` ()=
        (fun () -> raise TestException |> ignore) |> should throw typeof<TestException>

    [<Test>] member test.
     ``should fail when exception is not thrown`` ()=
        shouldFail (fun () -> 
            (fun () -> ()) |> should throw typeof<Exception>)
        
    [<Test>] member test.
     ``should pass when negated and exception is not thrown`` ()=
        (fun () ->()) |> should not (throw typeof<Exception>)

    [<Test>] member test.
     ``should fail when negated and exception is thrown`` ()=
        shouldFail (fun () -> 
            (fun () -> raise TestException |> ignore) |> should not (throw typeof<TestException>))

    [<Test>] member test.
     ``should fail when exception thrown is not the type expected`` ()=
        shouldFail (fun () -> 
            (fun () -> raise TestException |> ignore) |> should throw typeof<ApplicationException>)