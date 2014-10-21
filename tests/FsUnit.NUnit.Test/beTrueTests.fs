namespace FsUnit.Test
open NUnit.Framework
open FsUnit
open FsUnitDeprecated

[<TestFixture>]
type ``be True tests`` ()=
    [<Test>] member test.
     ``true should be True`` ()=
        true |> should be True

    [<Test>] member test.
     ``false should fail to be True`` ()=
        shouldFail (fun () -> false |> should be True)

    [<Test>] member test.
     ``false should not be True`` ()=
        false |> should not (be True)

    [<Test>] member test.
     ``true should fail to not be True`` ()=
        shouldFail (fun () -> true |> should not (be True))
