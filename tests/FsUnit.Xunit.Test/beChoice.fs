namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be choice tests``() =
    [<Fact>]
    member __.``Choice1Of2 should be the first choice``() =
        Choice<int, int>.Choice1Of2(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice1Of3 should be the first choice``() =
        Choice<int, int, int>.Choice1Of3(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice1Of4 should be the first choice``() =
        Choice<int, int, int, int>.Choice1Of4(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice1Of5 should be the first choice``() =
        Choice<int, int, int, int, int>.Choice1Of5(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice1Of6 should be the first choice``() =
        Choice<int, int, int, int, int, int>.Choice1Of6(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice1Of7 should be the first choice``() =
        Choice<int, int, int, int, int, int, int>.Choice1Of7(1)
        |> should be (choice 1)

    [<Fact>]
    member __.``Choice2Of2 should be the second choice``() =
        Choice<int, int>.Choice2Of2(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice2Of3 should be the second choice``() =
        Choice<int, int, int>.Choice2Of3(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice2Of4 should be the second choice``() =
        Choice<int, int, int, int>.Choice2Of4(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice2Of5 should be the second choice``() =
        Choice<int, int, int, int, int>.Choice2Of5(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice2Of6 should be the second choice``() =
        Choice<int, int, int, int, int, int>.Choice2Of6(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice2Of7 should be the second choice``() =
        Choice<int, int, int, int, int, int, int>.Choice2Of7(1)
        |> should be (choice 2)

    [<Fact>]
    member __.``Choice3Of3 should be the third choice``() =
        Choice<int, int, int>.Choice3Of3(1)
        |> should be (choice 3)

    [<Fact>]
    member __.``Choice3Of4 should be the third choice``() =
        Choice<int, int, int, int>.Choice3Of4(1)
        |> should be (choice 3)

    [<Fact>]
    member __.``Choice3Of5 should be the third choice``() =
        Choice<int, int, int, int, int>.Choice3Of5(1)
        |> should be (choice 3)

    [<Fact>]
    member __.``Choice3Of6 should be the third choice``() =
        Choice<int, int, int, int, int, int>.Choice3Of6(1)
        |> should be (choice 3)

    [<Fact>]
    member __.``Choice3Of7 should be the third choice``() =
        Choice<int, int, int, int, int, int, int>.Choice3Of7(1)
        |> should be (choice 3)

    [<Fact>]
    member __.``Choice4Of4 should be the fourth choice``() =
        Choice<int, int, int, int>.Choice4Of4(1)
        |> should be (choice 4)

    [<Fact>]
    member __.``Choice4Of5 should be the fourth choice``() =
        Choice<int, int, int, int, int>.Choice4Of5(1)
        |> should be (choice 4)

    [<Fact>]
    member __.``Choice4Of6 should be the fourth choice``() =
        Choice<int, int, int, int, int, int>.Choice4Of6(1)
        |> should be (choice 4)

    [<Fact>]
    member __.``Choice4Of7 should be the fourth choice``() =
        Choice<int, int, int, int, int, int, int>.Choice4Of7(1)
        |> should be (choice 4)

    [<Fact>]
    member __.``Choice5Of5 should be the fifth choice``() =
        Choice<int, int, int, int, int>.Choice5Of5(1)
        |> should be (choice 5)

    [<Fact>]
    member __.``Choice5Of6 should be the fifth choice``() =
        Choice<int, int, int, int, int, int>.Choice5Of6(1)
        |> should be (choice 5)

    [<Fact>]
    member __.``Choice5Of7 should be the fifth choice``() =
        Choice<int, int, int, int, int, int, int>.Choice5Of7(1)
        |> should be (choice 5)

    [<Fact>]
    member __.``Choice6Of6 should be the sixth choice``() =
        Choice<int, int, int, int, int, int>.Choice6Of6(1)
        |> should be (choice 6)

    [<Fact>]
    member __.``Choice6Of7 should be the sixth choice``() =
        Choice<int, int, int, int, int, int, int>.Choice6Of7(1)
        |> should be (choice 6)

    [<Fact>]
    member __.``Choice7Of7 should be the seventh choice``() =
        Choice<int, int, int, int, int, int, int>.Choice7Of7(1)
        |> should be (choice 7)

    [<Fact>]
    member __.``Choice1Of2 should not be the second choice``() =
        Choice<int, int>.Choice1Of2(1)
        |> should not' (be choice 2)

    [<Fact>]
    member __.``Choice2Of3 should not be the third choice``() =
        Choice<int, int, int>.Choice2Of3(1)
        |> should not' (be choice 3)

    [<Fact>]
    member __.``Choice3Of4 should not be the fourth choice``() =
        Choice<int, int, int, int>.Choice3Of4(1)
        |> should not' (be choice 4)

    [<Fact>]
    member __.``Choice4Of5 should not be the fifth choice``() =
        Choice<int, int, int, int, int>.Choice4Of5(1)
        |> should not' (be choice 5)

    [<Fact>]
    member __.``Choice5Of6 should not be the fifth choice``() =
        Choice<int, int, int, int, int, int>.Choice5Of6(1)
        |> should not' (be choice 6)

    [<Fact>]
    member __.``Choice6Of7 should not be the seventh choice``() =
        Choice<int, int, int, int, int, int, int>.Choice6Of7(1)
        |> should not' (be choice 7)
