namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

[<TestFixture>]
type ``be True tests`` ()=
    [<Test>] member test.
     ``true should be True`` ()=
        true |> should be True

    [<Test>] member test.
     ``false should fail to be True`` ()=
        false |> should not' (be True)

    [<Test>] member test.
     ``false should not be True`` ()=
        false |> should not' (be True)

    [<Test>] member test.
     ``true should fail to not be True`` ()=
        true |> should be True
