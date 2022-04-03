namespace FsUnit.Test

open System
open NUnit.Framework
open FsUnit

exception TestException

type ApplicationException(msg: string) =
    inherit Exception(msg)

[<TestFixture>]
type ``raise tests``() =
    [<Test>]
    member __.``should pass when exception of expected type is thrown``() =
        (fun () -> raise TestException |> ignore)
        |> should throw typeof<TestException>

    [<Test>]
    member __.``should fail when exception is not thrown``() =
        shouldFail(fun () -> (fun () -> ()) |> should throw typeof<Exception>)

    [<Test>]
    member __.``should pass when negated and exception is not thrown``() =
        (fun () -> ()) |> should not' (throw typeof<Exception>)

    [<Test>]
    member __.``should fail when negated and exception is thrown``() =
        shouldFail (fun () ->
            (fun () -> raise TestException |> ignore)
            |> should not' (throw typeof<TestException>))

    [<Test>]
    member __.``should fail when exception thrown is not the type expected``() =
        shouldFail (fun () ->
            (fun () -> raise TestException |> ignore)
            |> should throw typeof<ApplicationException>)

    [<Test>]
    member __.``should pass when exception of expected type with expected message is thrown``() =
        let msg = "BOOM!"

        (fun () -> raise(ApplicationException msg) |> ignore)
        |> should (throwWithMessage msg) typeof<ApplicationException>

    [<Test>]
    member __.``should fail when exception of expected type with unexpected message is thrown``() =
        shouldFail (fun () ->
            (fun () -> raise(ApplicationException "BOOM!") |> ignore)
            |> should (throwWithMessage "CRASH!") typeof<ApplicationException>)

    [<Test>]
    member __.``should fail when exception of unexpected type with expected message is thrown``() =
        shouldFail (fun () ->
            let msg = "BOOM!"

            (fun () -> raise(ApplicationException msg) |> ignore)
            |> should (throwWithMessage msg) typeof<ArgumentException>)

    [<Test>]
    member __.``should fail when negated and exception of expected type with expected message is thrown``() =
        shouldFail (fun () ->
            let msg = "BOOM!"

            (fun () -> raise(ApplicationException msg) |> ignore)
            |> should not' ((throwWithMessage msg) typeof<ApplicationException>))

    [<Test>]
    member __.``should pass when negated and exception of expected type with unexpected message is thrown``() =
        (fun () -> raise(ApplicationException "BOOM!") |> ignore)
        |> should not' ((throwWithMessage "CRASH!") typeof<ApplicationException>)

    [<Test>]
    member __.``should pass when negated and exception of unexpected type with expected message is thrown``() =
        let msg = "BOOM!"

        (fun () -> raise(ApplicationException msg) |> ignore)
        |> should not' ((throwWithMessage msg) typeof<ArgumentException>)
