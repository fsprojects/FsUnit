namespace FsUnit.Test
open MbUnit.Framework
open FsUnit.MbUnit
open NHamcrest.Core

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1
    
type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

[<TestFixture>]
type ``equal Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()
    
    [<Test>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> should equal 1
    
    [<Test>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        'f' |> should not (equal 'F')
    
    [<Test>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not (equal 2)

    [<Test>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        1 |> should equal 1

    [<Test>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<Test>] member test.
     ``reference type should fail to equal other`` ()=
        anObj |> should not (equal otherObj)
        
    [<Test>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not (equal otherObj)

    [<Test>] member test.
     ``reference type should fail to not equal itself`` ()=
        anObj |> should equal anObj

    [<Test>] member test.
     ``should fail when Equals returns false`` ()=
        anObj |> should not (equal (NeverEqual()))
        
    [<Test>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not (equal (NeverEqual()))
