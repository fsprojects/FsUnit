namespace FsUnit.Test

open System
open Xunit
open FsUnit.Xunit
open Xunit.Sdk

type ``shouldFail tests``() =

    [<Fact>]
    member _.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> should contain 1)

    [<Fact>]
    member _.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<Fact>]
    member _.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<Fact>]
    member _.``shouldFail should throw an exception``() =
        (fun () -> shouldFail id) |> should throw typeof<EqualException>

    [<Fact>]
    member _.``shouldFail should not throw an exception when fail``() =
        (fun () -> shouldFail(fun () -> [] |> should contain 1))
        |> should not' (throw typeof<EqualException>)

    [<Fact>]
    member _.``test raising exception``() =
        fun () -> raise(ArgumentException "help")
        |> should (throwWithMessage "help") typeof<ArgumentException>

    [<Fact>]
    member _.``Null source should fail``() =
        shouldFail(fun () -> Seq.empty |> Seq.append null |> ignore)
