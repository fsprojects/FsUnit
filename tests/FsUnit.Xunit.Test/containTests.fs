namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``contain tests``() =
    [<Fact>]
    member __.``List with item should contain item``() =
        [ 1 ] |> should contain 1

    [<Fact>]
    member __.``List with multiple items should contain item``() =
        [ 1; 2; 3 ] |> should contain 2

    [<Fact>]
    member __.``populated List should not contain item``() =
        [ 2; 4; 5 ] |> should not' (contain 3)

    [<Fact>]
    member __.``empty List should not contain item``() =
        [] |> should not' (contain 1)

    [<Fact>]
    member __.``Array with multiple items should contain item``() =
        [| 1; 2; 3 |] |> should contain 2

    [<Fact>]
    member __.``empty Array should not contain item``() =
        [||] |> should not' (contain 1)

    [<Fact>]
    member __.``Array with different items should not contain item``() =
        [| 2; 3; 4 |] |> should not' (contain 1)

    [<Fact>]
    member __.``Seq with item should contain item``() =
        seq { 1 } |> should contain 1

    [<Fact>]
    member __.``empty Seq should not contain item``() =
        Seq.empty |> should not' (contain 1)

    [<Fact>]
    member __.``Seq with items should contain item``() =
        { 2..3 } |> should contain 2

    [<Fact>]
    member __.``Seq with different items should contain item``() =
        { 2..3 } |> should not' (contain 1)

    [<Fact>]
    member __.``Enumerable with item should contain item``() =
        System.Collections.ArrayList([| 1 |]) |> should contain 1

    [<Fact>]
    member __.``empty Enumerable should not contain item``() =
        System.Collections.ArrayList() |> should not' (contain 1)

    [<Fact>]
    member __.``Enumerable with items should contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should contain 2

    [<Fact>]
    member __.``Enumerable with different items should not contain item``() =
        System.Collections.ArrayList([| 2; 3 |]) |> should not' (contain 1)
