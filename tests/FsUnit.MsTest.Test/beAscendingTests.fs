namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``be ascending tests``() =
    [<TestMethod>]
    member __.``Empty list should be ascending``() =
        [] |> should be ascending

    [<TestMethod>]
    member __.``List with 1 element should be ascending``() =
        [ 1 ] |> should be ascending

    [<TestMethod>]
    member __.``List that only has identical elements should be ascending``() =
        [ 1; 1; 1 ] |> should be ascending

    [<TestMethod>]
    member __.``List that is ascending should be ascending``() =
        [ 1; 2 ] |> should be ascending

    [<TestMethod>]
    member __.``List that is not ascending should not be ascending``() =
        [ 2; 1 ] |> should not' (be ascending)
