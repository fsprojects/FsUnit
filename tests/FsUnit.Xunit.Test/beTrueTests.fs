namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be True tests``() =
    [<Fact>]
    member _.``true should be True``() =
        true |> should be True

    [<Fact>]
    member _.``false should fail to be True``() =
        false |> should not' (be True)

    [<Fact>]
    member _.``false should not be True``() =
        false |> should not' (be True)

    [<Fact>]
    member _.``true should fail to not be True``() =
        true |> should be True
