namespace FsUnit.Typed.Test

open Xunit
open FsUnitTyped

type ``shouldFail tests``() =
    [<Fact>]
    member __.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> shouldContain 1)

    [<Fact>]
    member __.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> shouldEqual null)

    [<Fact>]
    member __.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<Fact>]
    member __.``Simplify "should throw"``() =
        (fun () -> failwith "BOOM!") |> shouldFail<System.Exception>
