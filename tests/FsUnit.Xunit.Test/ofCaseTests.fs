namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open FsUnit.CustomMatchers

type TestUnion
    = First
    | Second of int
    | Third of string

type ``ofCase tests`` ()=
    [<Fact>]
    let ``Given a (parameterless) union type of matching case returns true`` () =
        First |> should be (ofCase <@ First @>)

    [<Fact>]
    let ``Given a (parameterized) union type of matching case returns true`` () =
        Second 10 |> should be (ofCase<@ Second 5 @>)

    [<Fact>]
    let ``Given a union type of non-matching case fails the assertion`` () =
        Second 5 |> should not' (be ofCase<@ First @>)

    [<Fact>]
    let ``Given a non-union type as expression throws an exception`` () =
        let value = Third
        (fun () -> value |> should be (ofCase<@ int @>) |> ignore) |> should (throwWithMessage "Expression is not a union case.") typeof<System.Exception>

    [<Fact>]
    let ``Given a non-union type as value argument fails the assertion`` () =
        5 |> should not' (be ofCase<@ Second 5 @>)
