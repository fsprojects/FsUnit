namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be greaterThan tests``() =
    [<Fact>]
    member __.``11 should be greater than 10``() =
        11 |> should be (greaterThan 10)

    [<Fact>]
    member __.``11.1 should be greater than 11.0``() =
        11.1 |> should be (greaterThan 11.0)

    [<Fact>]
    member __.``9 should not be greater than 10``() =
        9 |> should not' (be greaterThan 10)

    [<Fact>]
    member __.``9.1 should not be greater than 9.2``() =
        9.1 |> should not' (be greaterThan 9.2)

    [<Fact>]
    member __.``9.2 should not be greater than 9.2``() =
        9.2 |> should not' (be greaterThan 9.2)

    [<Fact>]
    member __.``10 should not be greater than 10 but messages should equal``() =
        (fun () -> 10 |> should be (greaterThan 10))
        |> fun f -> Assert.Throws<MatchException>(f)
        |> fun e -> (e.Expected, e.Actual)
        |> should equal ("Greater than 10", "10")
