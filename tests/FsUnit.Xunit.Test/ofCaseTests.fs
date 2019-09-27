namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open FsUnit.CustomMatchers

type private TestUnion
    = First
    | Second
    | Third

type ``ofCase tests`` ()=
    [<Fact>] member test.
     ``given a matching case asserts successfully`` ()=
        TestUnion.First |> should be (ofCase<@ TestUnion.First @>)

    [<Fact>] member test.
     ``given a non-matching fails`` ()=
        shouldFail (fun () -> TestUnion.Second |> should be (ofCase<@ TestUnion.First @>))
        
    [<Fact>] member test.
     ``given a non-union type throws an exception`` ()=
        (fun () -> TestUnion.Second |> should be (ofCase<@ int @>)) |> should (throwWithMessage "Expression is no union case.") typeof<System.Exception>
