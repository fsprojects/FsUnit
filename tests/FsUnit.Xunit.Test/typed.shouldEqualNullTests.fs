namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``Typed: shouldEqual null tests``() =
    [<Fact>]
    member _.``null should be null``() =
        null |> shouldEqual null

    [<Fact>]
    member _.``null should fail to not be null``() =
        shouldFail(fun () -> null |> shouldNotEqual null)
