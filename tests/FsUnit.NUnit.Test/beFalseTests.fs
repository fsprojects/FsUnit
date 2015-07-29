namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``be False tests`` ()=
    [<Test>] member test.
     ``false should be False`` ()=
        false |> should be False

    [<Test>] member test.
     ``true should fail to be False`` ()=
        shouldFail (fun () -> true |> should be False)

    [<Test>] member test.
     ``true should not be False`` ()=
        true |> should not' (be False)

    [<Test>] member test.
     ``false should fail to not be False`` ()=
        shouldFail (fun () -> false |> should not' (be False))
