namespace FsUnit.Typed.Test

open NUnit.Framework
open FsUnitTyped

[<TestFixture>]
type ``Typed: shouldEqual null tests``() =
    [<Test>]
    member _.``null should be null``() =
        null |> shouldEqual null

    [<Test>]
    member _.``null should fail to not be null``() =
        shouldFail(fun () -> null |> shouldNotEqual null)
