namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``should be of exact type tests``() =
    [<Fact>]
    member __.``empty string should be of exact type String``() =
        "" |> should be ofExactType<string>

    [<Fact>]
    member __.``0[dot]0 should be of exact type float``() =
        0.0 |> should be ofExactType<float>

    [<Fact>]
    member __.``1 should be of exact type int``() =
        1 |> should be ofExactType<int>

    [<Fact>]
    member __.``1 should not be of exact type obj``() =
        1 |> should not' (be ofExactType<obj>)

    [<Fact>]
    member __.``1 should not be of exact type string``() =
        1 |> should not' (be ofExactType<string>)
