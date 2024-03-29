namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``contain tests``() =

    [<Test>]
    member _.``List with item should contain item``() =
        [ 1 ] |> should contain 1

    [<Test>]
    member _.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> should contain 1)

    [<Test>]
    member _.``empty List should not contain item``() =
        [] |> should not' (contain 1)

    [<Test>]
    member _.``List with item should fail to not contain item``() =
        shouldFail(fun () -> [ 1 ] |> should not' (contain 1))

    [<Test>]
    member _.``Array with item should contain item``() =
        [| 1 |] |> should contain 1

    [<Test>]
    member _.``empty Array should fail to contain item``() =
        shouldFail(fun () -> [||] |> should contain 1)

    [<Test>]
    member _.``empty Array should not contain item``() =
        [||] |> should not' (contain 1)

    [<Test>]
    member _.``Array with item should fail to not contain item``() =
        shouldFail(fun () -> [| 1 |] |> should not' (contain 1))

    [<Test>]
    member _.``Seq with item should contain item``() =
        seq { 1 } |> should contain 1

    [<Test>]
    member _.``empty Seq should fail to contain item``() =
        shouldFail(fun () -> Seq.empty |> should contain 1)

    [<Test>]
    member _.``empty Seq should not contain item``() =
        Seq.empty |> should not' (contain 1)

    [<Test>]
    member _.``Seq with item should fail to not contain item``() =
        shouldFail(fun () -> seq { 1 } |> should not' (contain 1))

    [<Test>]
    member _.``Enumerable with item should contain item``() =
        System.Collections.ArrayList([| 1 |]) |> should contain 1

    [<Test>]
    member _.``empty Enumerable should not contain item``() =
        System.Collections.ArrayList() |> should not' (contain 1)

    [<Test>]
    member _.``Enumerable with items should contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should contain 2

    [<Test>]
    member _.``Enumerable with different items should not contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should not' (contain 1)
