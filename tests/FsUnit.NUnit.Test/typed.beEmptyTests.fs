namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeEmpty tests``() =

    [<Test>]
    member _.``empty List should be Empty``() =
        [] |> shouldBeEmpty

    [<Test>]
    member _.``non-empty List should fail to be Empty``() =
        shouldFail(fun () -> [ 1 ] |> shouldBeEmpty)

    [<Test>]
    member _.``empty Array should be Empty``() =
        [||] |> shouldBeEmpty

    [<Test>]
    member _.``non-empty Array should fail to be Empty``() =
        shouldFail(fun () -> [| 1 |] |> shouldBeEmpty)

    [<Test>]
    member _.``empty Seq should be Empty``() =
        Seq.empty |> shouldBeEmpty

    [<Test>]
    member _.``non-empty Seq should fail to be Empty``() =
        shouldFail(fun () -> seq { 1 } |> shouldBeEmpty)
