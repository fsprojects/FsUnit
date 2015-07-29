namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
[<TestFixture>]
type ``be EmptyString tests`` ()=
    [<Test>] member test.
     ``empty string should be EmptyString`` ()=
        "" |> should be NullOrEmptyString

    [<Test>] member test.
     ``non-empty string should fail to be EmptyString`` ()=
        "a string" |> should not' (be EmptyString)

    [<Test>] member test.
     ``non-empty string should not be EmptyString`` ()=
        "a string" |> should not' (be EmptyString)

    [<Test>] member test.
     ``empty string should fail to not be EmptyString`` ()=
        "" |> should be EmptyString