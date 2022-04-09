namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldFail tests``() =
    [<Fact>]
    member _.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> shouldContain 1)

    [<Fact>]
    member _.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> shouldEqual null)

    [<Fact>]
    member _.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<Fact>]
    member _.``Simplify "should throw"``() =
        (fun () -> failwith "BOOM!") |> shouldFail<System.Exception>
