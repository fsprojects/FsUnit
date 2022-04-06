namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``Typed: shouldEqual null tests``() =
    [<Fact>]
    member __.``null should be null``() =
        null |> shouldEqual null

    [<Fact>]
    member __.``null should fail to not be null``() =
        shouldFail(fun () -> null |> shouldNotEqual null)
