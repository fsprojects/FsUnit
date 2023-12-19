namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``haveLength tests``() =

    // F# List
    [<Test>]
    member _.``List with 1 item should have Length 1``() =
        [ 1 ] |> shouldHaveLength 1

    [<Test>]
    member _.``empty List should fail to have Length 1``() =
        shouldFail(fun () -> [] |> shouldHaveLength 1)

    // Array
    [<Test>]
    member _.``Array with 1 item should have Length 1``() =
        [| 1 |] |> shouldHaveLength 1

    [<Test>]
    member _.``empty Array should fail to have Length 1``() =
        shouldFail(fun () -> [||] |> shouldHaveLength 1)
