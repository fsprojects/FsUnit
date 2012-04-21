namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core
open FsUnitDepricated

[<TestFixture>]
type ``be Null tests`` ()=
    [<Test>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<Test>] member test.
     ``null should fail to not be Null`` ()=
        null |> should be Null
        
    [<Test>] member test.
     ``non-null should fail to be  Null`` ()=
        "something" |> should not (be Null)
        
    [<Test>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should not (be Null)
