namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be NullOrEmptyString tests``() =

    [<Fact>]
    member _.``empty string should be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member _.``null should be NullOrEmptyString``() =
        null |> should be NullOrEmptyString

    [<Fact>]
    member _.``non-empty string should fail to be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<Fact>]
    member _.``non-empty string should not be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<Fact>]
    member _.``empty string should fail to not be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member _.``null should fail to not be NullOrEmptyString``() =
        null |> should be NullOrEmptyString
