namespace FsUnit.Test
open Xunit
open FsUnit.Xunit
open NHamcrest.Core
open FsUnitDepricated

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1
    
type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

type ``equal Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()
    
    [<Fact>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> should equal 1
    
    [<Fact>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        'f' |> should not (equal 'F')
    
    [<Fact>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not (equal 2)

    [<Fact>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        1 |> should equal 1

    [<Fact>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<Fact>] member test.
     ``reference type should fail to equal other`` ()=
        anObj |> should not (equal otherObj)
        
    [<Fact>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not (equal otherObj)

    [<Fact>] member test.
     ``reference type should fail to not equal itself`` ()=
        anObj |> should equal anObj

    [<Fact>] member test.
     ``should fail when Equals returns false`` ()=
        anObj |> should not (equal (new NeverEqual()))
        
    [<Fact>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not (equal (new NeverEqual()))

