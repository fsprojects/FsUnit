namespace FsUnit.Test
open Xunit
open FsUnit.Xunit

type ``be False tests`` ()=
    [<Fact>] member test.
     ``false should be False`` ()=
        false |> should be False

    [<Fact>] member test.
     ``true should fail to be False`` ()=
        true |> should not' (be False)

    [<Fact>] member test.
     ``true should not be False`` ()=
        true |> should not' (be False)

    [<Fact>] member test.
     ``false should fail to not be False`` ()=
        false |> should be False
