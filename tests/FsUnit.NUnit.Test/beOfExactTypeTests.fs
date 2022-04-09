namespace FsUnit.Test

open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``should be of exact type tests``() =
    [<Test>]
    member _.``empty string should be of exact type String``() =
        "" |> should be ofExactType<string>

    [<Test>]
    member _.``0[dot]0 should be of exact type float``() =
        0.0 |> should be ofExactType<float>

    [<Test>]
    member _.``1 should be of exact type int``() =
        1 |> should be ofExactType<int>

    [<Test>]
    member _.``1 should not be of exact type obj``() =
        1 |> should not' (be ofExactType<obj>)

    [<Test>]
    member _.``1 should not be of exact type string``() =
        1 |> should not' (be ofExactType<string>)
