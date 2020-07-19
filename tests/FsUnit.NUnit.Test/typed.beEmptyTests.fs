namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldBeEmpty tests``() =
    [<Test>]
    member __.``empty List should be Empty``() =
        [] |> shouldBeEmpty

    [<Test>]
    member __.``non-empty List should fail to be Empty``() =
        shouldFail(fun () -> [ 1 ] |> shouldBeEmpty)

    [<Test>]
    member __.``empty Array should be Empty``() =
        [||] |> shouldBeEmpty

    [<Test>]
    member __.``non-empty Array should fail to be Empty``() =
        shouldFail(fun () -> [| 1 |] |> shouldBeEmpty)

    [<Test>]
    member __.``empty Seq should be Empty``() =
        Seq.empty |> shouldBeEmpty

    [<Test>]
    member __.``non-empty Seq should fail to be Empty``() =
        shouldFail(fun () -> seq { 1 } |> shouldBeEmpty)
