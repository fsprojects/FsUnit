namespace FsUnit.Test

open Xunit
open Xunit.Sdk
open FsUnit.Xunit

type ``should startWith tests``() =
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
    member _.``ships should not start with ss and should throw EqualException``() =
        (fun _ -> "ships" |> should startWith "ss")
        |> should throw typeof<EqualException>
