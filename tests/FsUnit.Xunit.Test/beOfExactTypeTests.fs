namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDeprecated

type ``should be of exact type tests`` ()=
    [<Fact>] member test.
     ``empty string should be of exact type String`` ()=
        "" |> should be ofExactType<string>

    [<Fact>] member test.
     ``0.0 should be of exact type float`` ()=
        0.0 |> should be ofExactType<float>
        
    [<Fact>] member test.
     ``1 should be of exact type int`` ()=
        1 |> should be ofExactType<int>

    [<Fact>] member test.
     ``1 should not be of exact type obj`` ()=
        1 |> should not (be ofExactType<obj>)

    [<Fact>] member test.
     ``1 should not be of exact type string`` ()=
        1 |> should not (be ofExactType<string>)
