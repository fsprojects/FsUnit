namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be unique tests``() =

    [<Test>]
    member _.``empty list should be considered as unique``() =
        [] |> should be unique

    [<Test>]
    member _.``empty list should fail to be considered as not unique``() =
        shouldFail(fun () -> [] |> should not' (be unique))

    [<Test>]
    member _.``one-item list should be considered as unique``() =
        [ 1 ] |> should be unique

    [<Test>]
    member _.``one-item list should not fail to be considered as unique``() =
        shouldFail(fun () -> [ 1 ] |> should not' (be unique))

    [<Test>]
    member _.``unique list should be considered as unique``() =
        [ 1; 2; 3 ] |> should be unique

    [<Test>]
    member _.``unique list should fail to be considered unique``() =
        shouldFail(fun () -> [ 1; 2; 3 ] |> should not' (be unique))

    [<Test>]
    member _.``non-unique list should not be considered unique``() =
        [ 1; 1; 1 ] |> should not' (be unique)

    [<Test>]
    member _.``non-unique list should fail to be considered unique``() =
        shouldFail(fun () -> [ 1; 1; 1 ] |> should be unique)

    [<Test>]
    member _.``non-unique sequence should not be considered unique``() =
        [ 1; 1 ] |> List.toSeq |> should not' (be unique)

    [<Test>]
    member _.``unique sequence should be considered unique``() =
        [ 1; 2 ] |> List.toSeq |> should be unique

    [<Test>]
    member _.``non-unique array should not be considered as unique``() =
        [| 1; 1 |] |> should not' (be unique)

    [<Test>]
    member _.``unique array should be considered unique``() =
        [| 1; 2 |] |> should be unique

    [<Test>]
    member _.``string null should be unique``() =
        string null |> should be unique
