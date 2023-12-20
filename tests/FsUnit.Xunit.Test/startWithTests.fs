namespace FsUnit.Test

open Xunit
open Xunit.Sdk
open FsUnit.Xunit
open FsUnitTyped

type ``startWith tests``() =

    [<Fact>]
    member _.``empty string should start with ""``() =
        "" |> should startWith ""

    [<Fact>]
    member _.``ships should start with ps``() =
        "ships" |> should startWith "sh"

    [<Fact>]
    member _.``ships should not start with ss``() =
        "ships" |> should not' (startWith "ss")

    [<Fact>]
    member _.``ships should not start with ss and check if it's EqualException``() =
        shouldFail<EqualException>(fun _ -> "ships" |> should startWith "ss")
