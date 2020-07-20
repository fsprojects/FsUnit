namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``should be of exact type tests``() =
    [<TestMethod>]
    member __.``empty string should be of exact type String``() =
        "" |> should be ofExactType<string>

    [<TestMethod>]
    member __.``0[dot]0 should be of exact type float``() =
        0.0 |> should be ofExactType<float>

    [<TestMethod>]
    member __.``1 should be of exact type int``() =
        1 |> should be ofExactType<int>

    [<TestMethod>]
    member __.``1 should not be of exact type obj``() =
        1 |> should not' (be ofExactType<obj>)

    [<TestMethod>]
    member __.``1 should not be of exact type string``() =
        1 |> should not' (be ofExactType<string>)
