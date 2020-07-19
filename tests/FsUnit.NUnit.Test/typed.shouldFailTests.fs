namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``shouldFail tests``() =
    [<Test>]
    member __.``empty List should fail to contain item``() =
        shouldFail(fun () -> [] |> shouldContain 1)

    [<Test>]
    member __.``non-null should fail to be  Null``() =
        shouldFail(fun () -> "something" |> shouldEqual null)

    [<Test>]
    member __.``shouldFail should fail when everything is OK``() =
        shouldFail(fun () -> shouldFail id)

    [<Test>]
    member __.``Simplify "should throw"``() =
        (fun () -> failwith "BOOM!") |> shouldFail<System.Exception>
