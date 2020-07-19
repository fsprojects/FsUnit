namespace FsUnit.Test

open NUnit.Framework
open FsUnit
open FsUnit.CustomConstraints

type TestUnion =
    | First
    | Second of int
    | Third of string

[<TestFixture>]
type ``ofCase tests``() =

    [<Test>]
    member __.``Given a (parameterless) union case of matching case returns true``() =
        First |> should be (ofCase <@ First @>)

    [<Test>]
    member __.``Given a (parameterized) union case of matching case returns true``() =
        Second 5 |> should be (ofCase <@ Second 1 @>)

    [<Test>]
    member __.``Given a union case of non-matching case fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First @>)

    [<Test>]
    member __.``Given a (parameterized) union case (without parameter) of matching case returns true``() =
        Second 10 |> should be (ofCase <@ Second @>)

    [<Test>]
    member __.``Given a union case and a tuple of union cases including a matching case returns true``() =
        First |> should be (ofCase <@ First, Second, Third @>)

    [<Test>]
    member __.``Given a union case and tuple of non-matching cases fails the assertion``() =
        Second 5 |> should not' (be ofCase <@ First, Third @>)

    [<Test>]
    member __.``Given a non-union case as expression throws an exception``() =
        (fun () -> Third "Some String" |> should be (ofCase <@ string @>) |> ignore)
        |> should (throwWithMessage "Expression (not value) is not a union case.") typeof<System.Exception>

    [<Test>]
    member __.``Given a non-union case as value argument throws an exception``() =
        (fun () -> 5 |> should not' (be ofCase <@ Second 5 @>) |> ignore)
        |> should (throwWithMessage "Value (not expression) is not a union case.") typeof<System.Exception>
