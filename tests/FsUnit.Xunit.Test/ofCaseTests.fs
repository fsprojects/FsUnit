namespace FsUnit.Test

open Xunit
open FsUnit.Xunit
open FsUnit.CustomMatchers

type TestUnion =
    | First
    | Second of int
    | Third of string

type ``ofCase tests``() =
    [<Fact>]
    let ``Given a (parameterless) union case of matching case returns true``() =
        First |> should be (ofCase <@ First @>)

    [<Fact>]
    let ``Given a (parameterized) union case of matching case returns true``() =
        Second 10 |> should be (ofCase <@ Second 5 @>)

    [<Fact>]
    let ``Given a union case and a tuple of union cases including a matching case returns true``() =
        First |> should be (ofCase <@ First, Second, Third @>)

    [<Fact>]
    let ``Given a (parameterized) union case (without parameter) of matching case returns true``() =
        Second 10 |> should be (ofCase <@ Second @>)

    [<Fact>]
    let ``Given a union case of non-matching case fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First @>)

    [<Fact>]
    let ``Given a union case and tuple of non-matching cases fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First, Third @>)

    [<Fact>]
    let ``Given a non-union case as expression throws an exception``() =
        let value = Third

        (fun () -> value |> should be (ofCase <@ int @>) |> ignore)
        |> should (throwWithMessage "Expression (not value) is not a union case.") typeof<System.Exception>

    [<Fact>]
    let ``Given a non-union case as value argument throws an exception``() =
        (fun () -> 5 |> should not' (be ofCase <@ Second 5 @>) |> ignore)
        |> should (throwWithMessage "Value (not expression) is not a union case.") typeof<System.Exception>

    [<Fact>]
    member _.``None should be ofCase None``() =
        None |> should be (ofCase <@ None @>)

    [<Fact>]
    member _.``Some 42 should be ofCase Some 42``() =
        Some 42 |> should be (ofCase <@ Some 42 @>)

    [<Fact>]
    member _.``Some 1 should not be ofCase None``() =
        Some 1 |> should not' (be ofCase <@ None @>)
