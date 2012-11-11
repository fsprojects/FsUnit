namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
open FsUnitDepricated

[<TestFixture>]
type ``be False tests`` ()=
    [<Test>] member test.
     ``false should be False`` ()=
        false |> should be False

    [<Test>] member test.
     ``true should fail to be False`` ()=
        true |> should not (be False)

    [<Test>] member test.
     ``true should not be False`` ()=
        true |> should not (be False)

    [<Test>] member test.
     ``false should fail to not be False`` ()=
        false |> should be False
