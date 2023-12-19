namespace FsUnit.Test

open Xunit
open FsUnit.Xunit
open Xunit.Sdk

type ``be greaterThan tests``() =

    [<Fact>]
    member _.``11 should be greater than 10``() =
        11 |> should be (greaterThan 10)

    [<Fact>]
    member _.``11[dot]1 should be greater than 11[dot]0``() =
        11.1 |> should be (greaterThan 11.0)

    [<Fact>]
    member _.``9 should not be greater than 10``() =
        9 |> should not' (be greaterThan 10)

    [<Fact>]
    member _.``9[dot]1 should not be greater than 9[dot]2``() =
        9.1 |> should not' (be greaterThan 9.2)

    [<Fact>]
    member _.``9[dot]2 should not be greater than 9[dot]2``() =
        9.2 |> should not' (be greaterThan 9.2)

    [<Fact>]
    member _.``10 should not be greater than 10 and should throw EqualException``() =
        (fun () -> 10 |> should be (greaterThan 10))
        |> should throw typeof<EqualException>
