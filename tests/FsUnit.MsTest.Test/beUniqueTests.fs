namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``have unique items list tests``() =
    [<TestMethod>]
    member __.``empty list should be considered as unique``() =
        [] |> should be unique

    [<TestMethod>]
    member __.``empty list should fail to be considered as not unique``() =
        shouldFail(fun () -> [] |> should not' (be unique))

    [<TestMethod>]
    member __.``one-item list should be considered as unique``() =
        [ 1 ] |> should be unique

    [<TestMethod>]
    member __.``one-item list should not fail to be considered as unique``() =
        shouldFail(fun () -> [ 1 ] |> should not' (be unique))

    [<TestMethod>]
    member __.``unique list should be considered as unique``() =
        [ 1; 2; 3 ] |> should be unique

    [<TestMethod>]
    member __.``unique list should fail to be considered unique``() =
        shouldFail(fun () -> [ 1; 2; 3 ] |> should not' (be unique))

    [<TestMethod>]
    member __.``non-unique list should not be considered unique``() =
        [ 1; 1; 1 ] |> should not' (be unique)

    [<TestMethod>]
    member __.``non-unique list should fail to be considered unique``() =
        shouldFail(fun () -> [ 1; 1; 1 ] |> should be unique)

    [<TestMethod>]
    member __.``non-unique sequence should not be considered unique``() =
        [ 1; 1 ] |> List.toSeq |> should not' (be unique)

    [<TestMethod>]
    member __.``unique sequence should be considered unique``() =
        [ 1; 2 ] |> List.toSeq |> should be unique

    [<TestMethod>]
    member __.``non-unique array should not be considered as unique``() =
        [| 1; 1 |] |> should not' (be unique)

    [<TestMethod>]
    member __.``unique array should be considered unique``() =
        [| 1; 2 |] |> should be unique

    [<TestMethod>]
    member __.``string null should be unique``() =
        string null |> should be unique
