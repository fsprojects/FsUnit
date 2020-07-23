namespace FsUnit.Test

open NUnit.Framework
open FsUnit
open System

[<TestFixture>]
type ``be supersetOf tests``() =

    [<SetUp>]
    member __.setup () =
        FSharpCustomMessageFormatter() |> ignore

    [<Test>]
    member __.``1 to 10 should be superset of 5, 3 and 8``() =
        [ 1 .. 10 ] |> should be (supersetOf [ 5; 3; 8 ])

    [<Test>]
    member __.``1 to 10 should be superset of 5``() =
        [ 1 .. 10 ] |> should be (supersetOf [ 5 ])

    [<Test>]
    member __.``1 to 10 should be superset of 4 to 8``() =
        { 1 .. 10 } |> should be (supersetOf { 4 .. 8 })

    [<Test>]
    member __.``1 to 10 should be superset of 4, 1 and 7``() =
        [| 1 .. 10 |] |> should be (supersetOf [| 4; 1; 7 |])

    [<Test>]
    member __.``1 to 10 should not be superset of 5, 1 and 11``() =
        [ 1 .. 10 ] |> should not' (be supersetOf [ 5; 1; 11 ])

    [<Test>]
    member __.``5 should not be superset of 1 to 10``() =
        [ 5 ] |> should not' (be supersetOf [ 1 .. 10 ])

    [<Test>]
    member __.``1 to 10 should be superset of 1 to 10``() =
        [ 1 .. 10 ] |> should be (supersetOf [ 1 .. 10 ])

    [<Test>]
    member __.``Ok ok should fail with be superset of Ok no but message should be equal``() =
        (fun () -> [ Ok "ok" ] |> should be (supersetOf [ Ok "no" ]))
        |> Assert.Throws<AssertionException>
        |> fun e ->
            e.Message
            |> should equal (sprintf "  Expected: superset of [Ok \"no\"]%s  But was:  [Ok \"ok\"]%s" Environment.NewLine Environment.NewLine)

    [<Test>]
    member __.``should fail on '1 to 10 should be superset of 1 to 11'``() =
        shouldFail(fun () -> [ 1 .. 10 ] |> should be (supersetOf [ 1 .. 11 ]))
