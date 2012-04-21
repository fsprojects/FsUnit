namespace FsUnit.Test
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open FsUnitDepricated

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
        'f' |> should not (equal 'F')
    
    [<TestMethod>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not (equal 2)

    [<TestMethod>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        1 |> should equal 1

    [<TestMethod>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<TestMethod>] member test.
     ``reference type should fail to equal other`` ()=
        anObj |> should not (equal otherObj)
        
    [<TestMethod>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not (equal otherObj)

    [<TestMethod>] member test.
     ``reference type should fail to not equal itself`` ()=
        anObj |> should equal anObj

    [<TestMethod>] member test.
     ``should fail when Equals returns false`` ()=
        anObj |> should not (equal (new NeverEqual()))
        
    [<TestMethod>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not (equal (new NeverEqual()))

