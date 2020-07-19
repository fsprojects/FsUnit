namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be EmptyString tests``() =
    [<Fact>]
    member __.``empty string should be EmptyString``() =
        "" |> should be NullOrEmptyString

    [<Fact>]
    member __.``non-empty string should fail to be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<Fact>]
    member __.``non-empty string should not be EmptyString``() =
        "a string" |> should not' (be EmptyString)

    [<Fact>]
    member __.``empty string should fail to not be EmptyString``() =
        "" |> should be EmptyString
