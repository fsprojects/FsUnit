namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``contain tests`` ()=
    [<Fact>] member test.
     ``List with item should contain item`` ()=
        [1] |> should contain 1

    [<Fact>] member test.
     ``List with multiple items should contain item`` ()=
        [1;2;3] |> should contain 2

    [<Fact>] member test.
     ``populated List should not contain item`` ()=
        [2;4;5] |> should not' (contain 3)

    [<Fact>] member test.
     ``empty List should not contain item`` ()=
        [] |> should not' (contain 1)

    [<Fact>] member test.
     ``Array with multiple items should contain item`` ()=
        [|1;2;3|] |> should contain 2

    [<Fact>] member test.
     ``empty Array should not contain item`` ()=
        [||] |> should not' (contain 1)

    [<Fact>] member test.
     ``Array with different items should not contain item`` ()=
        [|2;3;4|] |> should not' (contain 1)

    [<Fact>] member test.
     ``Seq with item should contain item`` ()=
        seq { yield 1 } |> should contain 1

    [<Fact>] member test.
     ``empty Seq should not contain item`` ()=
        Seq.empty |> should not' (contain 1)

    [<Fact>] member test.
     ``Seq with items should contain item`` ()=
        { 2..3 } |> should contain 2

    [<Fact>] member test.
     ``Seq with different items should contain item`` ()=
        { 2..3 } |> should not' (contain 1)

    [<Fact>] member test.
     ``Enumerable with item should contain item`` ()=
        System.Collections.ArrayList([|1|]) |> should contain 1

    [<Fact>] member test.
     ``empty Enumerable should not contain item`` ()=
        System.Collections.ArrayList() |> should not' (contain 1)

    [<Fact>] member test.
     ``Enumerable with items should contain item`` ()=
        System.Collections.ArrayList([|2; 3|]) |> should contain 2

    [<Fact>] member test.
     ``Enumerable with different items should not contain item`` ()=
        System.Collections.ArrayList([|2; 3|]) |> should not' (contain 1)
