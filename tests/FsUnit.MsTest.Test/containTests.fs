namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``contain tests``() =
    [<TestMethod>]
    member _.``List with item should contain item``() =
        [ 1 ] |> should contain 1

    [<TestMethod>]
    member _.``List with multiple items should contain item``() =
        [ 1; 2; 3 ] |> should contain 2

    [<TestMethod>]
    member _.``populated List should not contain item``() =
        [ 2; 4; 5 ] |> should not' (contain 3)

    [<TestMethod>]
    member _.``empty List should not contain item``() =
        [] |> should not' (contain 1)

    [<TestMethod>]
    member _.``Array with multiple items should contain item``() =
        [| 1; 2; 3 |] |> should contain 2

    [<TestMethod>]
    member _.``empty Array should not contain item``() =
        [||] |> should not' (contain 1)

    [<TestMethod>]
    member _.``Array with different items should not contain item``() =
        [| 2; 3; 4 |] |> should not' (contain 1)

    [<TestMethod>]
    member _.``Seq with item should contain item``() =
        seq { 1 } |> should contain 1

    [<TestMethod>]
    member _.``empty Seq should not contain item``() =
        Seq.empty |> should not' (contain 1)

    [<TestMethod>]
    member _.``Seq with items should contain item``() =
        { 2..3 } |> should contain 2

    [<TestMethod>]
    member _.``Seq with different items should contain item``() =
        { 2..3 } |> should not' (contain 1)

    [<TestMethod>]
    member _.``Enumerable with item should contain item``() =
        System.Collections.ArrayList([| 1 |]) |> should contain 1

    [<TestMethod>]
    member _.``empty Enumerable should not contain item``() =
        System.Collections.ArrayList() |> should not' (contain 1)

    [<TestMethod>]
    member _.``Enumerable with items should contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should contain 2

    [<TestMethod>]
    member _.``Enumerable with different items should not contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should not' (contain 1)
