namespace FsUnit.Test
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``have unique items list tests`` ()=
    [<Test>] member test.
     ``empty list should have unique items `` ()=
        [] |> should be unique

    [<Test>] member test.
     ``empty list should fail to have non-unique items `` ()=
        shouldFail(fun () -> [] |> should not (be unique))
    
    [<Test>] member test.
     ``one-item list should have unique items `` ()=
        [1] |> should be unique
    
    [<Test>] member test.
     ``one-item list should fail to have non-unique items `` ()=
        shouldFail(fun () -> [1] |> should not (be unique))

    [<Test>] member test.
     ``unique list should have unique items `` ()=
        [1;2;3] |> should be unique

    [<Test>] member test.
     ``unique list should fail to have non-unique `` ()=
        shouldFail(fun () -> [1;2;3] |> should not (be unique))

    [<Test>] member test.
     ``non-unique list should not have unique items`` ()=
        [1;1;1] |> should not (be unique)
    
    [<Test>] member test.
      ``non-unique list should fail to have unique items `` ()=
        shouldFail(fun () -> [1;1;1] |> should be unique)