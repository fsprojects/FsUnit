namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be False tests``() =
    [<Fact>]
    member __.``false should be False``() =
        false |> should be False

    [<Fact>]
    member __.``true should fail to be False``() =
        true |> should not' (be False)

    [<Fact>]
    member __.``true should not be False``() =
        true |> should not' (be False)

    [<Fact>]
    member __.``false should fail to not be False``() =
        false |> should be False
