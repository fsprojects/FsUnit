namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``be Null tests``() =

    [<Fact>]
    member _.``null should be Null``() =
        null |> should be Null

    [<Fact>]
    member _.``null should fail to not be Null``() =
        shouldFail(fun () -> null |> should not' (be Null))

    [<Fact>]
    member _.``non-null should fail to be Null``() =
        shouldFail(fun () -> "something" |> should be Null)

    [<Fact>]
    member _.``non-null should not be Null``() =
        "something" |> should not' (be Null)

    [<Fact>]
    member _.``null should be null``() =
        null |> should be null

    [<Fact>]
    member _.``null should fail to not be null``() =
        shouldFail(fun () -> null |> should not' (be null))

    [<Fact>]
    member _.``non-null should fail to be null``() =
        shouldFail(fun () -> "something" |> should be null)

    [<Fact>]
    member _.``non-null should not be null``() =
        "something" |> should not' (be null)
