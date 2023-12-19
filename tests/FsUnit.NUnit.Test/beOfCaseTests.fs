namespace FsUnit.Test

open NUnit.Framework
open FsUnit

type TestUnion =
    | First
    | Second of int
    | Third of string

[<TestFixture>]
type ``be ofCase tests``() =

    [<Test>]
    member _.``Given a (parameterless) union case of matching case returns true``() =
        First |> should be (ofCase <@ First @>)

    [<Test>]
    member _.``Given a (parameterized) union case of matching case returns true``() =
        Second 5 |> should be (ofCase <@ Second 1 @>)

    [<Test>]
    member _.``Given a union case of non-matching case fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First @>)

    [<Test>]
    member _.``Given a (parameterized) union case (without parameter) of matching case returns true``() =
        Second 10 |> should be (ofCase <@ Second @>)

    [<Test>]
    member _.``Given a union case and a tuple of union cases including a matching case returns true``() =
        First |> should be (ofCase <@ First, Second, Third @>)

    [<Test>]
    member _.``Given a union case and tuple of non-matching cases fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First, Third @>)

    [<Test>]
    member _.``Given a non-union case as expression throws an exception``() =
        (fun () -> Third "Some String" |> should be (ofCase <@ string @>) |> ignore)
        |> should (throwWithMessage "Expression (not value) is not a union case.") typeof<System.Exception>

    [<Test>]
    member _.``Given a non-union case as value argument throws an exception``() =
        (fun () -> 5 |> should not' (be ofCase <@ Second 5 @>) |> ignore)
        |> should (throwWithMessage "Value (not expression) is not a union case.") typeof<System.Exception>

    [<Test>]
    member _.``None should be ofCase None``() =
        None |> should be (ofCase <@ None @>)

    [<Test>]
    member _.``Some 42 should be ofCase Some 42``() =
        Some 42 |> should be (ofCase <@ Some 42 @>)

    [<Test>]
    member _.``Some 1 should not be ofCase None``() =
        Some 1 |> should not' (be ofCase <@ None @>)
