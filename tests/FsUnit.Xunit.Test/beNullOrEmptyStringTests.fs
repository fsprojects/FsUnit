namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be NullOrEmptyString tests``() =
    [<Fact>]
    member __.``empty string should be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member __.``null should be NullOrEmptyString``() =
        null |> should be NullOrEmptyString

    [<Fact>]
    member __.``non-empty string should fail to be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<Fact>]
    member __.``non-empty string should not be NullOrEmptyString``() =
        "a string" |> should not' (be NullOrEmptyString)

    [<Fact>]
    member __.``empty string should fail to not be NullOrEmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member __.``null should fail to not be NullOrEmptyString``() =
        null |> should be NullOrEmptyString
