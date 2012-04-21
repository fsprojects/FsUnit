namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDepricated

[<TestClass>]
type ``should be of exact type tests`` ()=
    [<TestMethod>] member test.
     ``empty string should be of exact type String`` ()=
        "" |> should be ofExactType<string>

    [<TestMethod>] member test.
     ``0.0 should be of exact type float`` ()=
        0.0 |> should be ofExactType<float>
        
    [<TestMethod>] member test.
     ``1 should be of exact type int`` ()=
        1 |> should be ofExactType<int>

    [<TestMethod>] member test.
     ``1 should not be of exact type obj`` ()=
        1 |> should not (be ofExactType<obj>)

    [<TestMethod>] member test.
     ``1 should not be of exact type string`` ()=
        1 |> should not (be ofExactType<string>)
