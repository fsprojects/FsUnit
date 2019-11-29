namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1

type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

[<TestClass>]
type ``equal Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()

    [<TestMethod>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> should equal 1

    [<TestMethod>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        'f' |> should not' (equal 'F')

    [<TestMethod>] member test.
     ``collection type should equal collection`` ()=
        [1..10] |> should equal [1..10]
        
    [<TestMethod>] member test.
     ``collection type should not equal equivalent if is not in same order`` ()=
        [1;2;3] |> should not' (equal [3;2;1])
                
    [<TestMethod>] member test.
     ``list should equivalent collection`` ()=
        [1..10] |> should equivalent [1..10]
        
    [<TestMethod>] member test.
     ``list should equal equivalent independent of order`` ()=
        [1;2;3] |> should equivalent [3;2;1]

    [<TestMethod>] member test.
     ``sequence should equal equivalent independent of order`` ()=
        {1..10} |> should equivalent {10..-1..1}

    [<TestMethod>] member test.
     ``collection should fail on '1 to 10 should not equivalent of 1 to 10'`` ()=
        shouldFail (fun () -> 
            [1..10] |> should not' (equivalent [1..10]))

    [<TestMethod>] member test.
     ``array should equal equivalent independent of order`` ()=
        [|1;4;8|] |> should equivalent [|4;8;1|]

    [<TestMethod>] member test.
     ``equivalent should fail on '[1..10] |> should equivalent []'`` ()=
        shouldFail(fun () -> [1..10] |> should equivalent [])

    [<TestMethod>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not' (equal 2)

    [<TestMethod>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        1 |> should equal 1

    [<TestMethod>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<TestMethod>] member test.
     ``reference type should fail to equal other`` ()=
        anObj |> should not' (equal otherObj)

    [<TestMethod>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not' (equal otherObj)

    [<TestMethod>] member test.
     ``reference type should fail to not equal itself`` ()=
        anObj |> should equal anObj

    [<TestMethod>] member test.
     ``should fail when Equals returns false`` ()=
        anObj |> should not' (equal (new NeverEqual()))

    [<TestMethod>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not' (equal (new NeverEqual()))

    [<TestMethod>] member test.
     ``None should equal None`` ()=
        None |> should equal None

