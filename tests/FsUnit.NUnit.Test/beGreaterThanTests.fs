namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be greaterThan tests``() =
    [<Test>]
    member __.``11 should be greater than 10``() =
        11 |> should be (greaterThan 10)

    [<Test>]
    member __.``11.1 should be greater than 11.0``() =
        11.1 |> should be (greaterThan 11.0)

    [<Test>]
    member __.``9 should not be greater than 10``() =
        9 |> should not' (be greaterThan 10)

    [<Test>]
    member __.``9.1 should not be greater than 9.2``() =
        9.1 |> should not' (be greaterThan 9.2)

    [<Test>]
    member __.``9.2 should not be greater than 9.2``() =
        9.2 |> should not' (be greaterThan 9.2)
