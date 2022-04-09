namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be EmptyString tests``() =
    [<Fact>]
    member _.``empty string should be EmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member _.``non-empty string should fail to be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<Fact>]
    member _.``non-empty string should not be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<Fact>]
    member _.``empty string should fail to not be EmptyString``() =
        "" |> should be EmptyString
