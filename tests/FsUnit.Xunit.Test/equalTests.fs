namespace FsUnit.Test

open System.Collections.Immutable

open Xunit
open FsUnit.Xunit
open NHamcrest.Core

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1

type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

type ``equal Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1,2,3)
    let equivalentImmutableArray = ImmutableArray.Create(1,2,3)
    let otherImmutableArray = ImmutableArray.Create(1,2,4)

    [<Fact>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> should equal 1

    [<Fact>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        'f' |> should not' (equal 'F')

    [<Fact>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not' (equal 2)

    [<Fact>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        1 |> should equal 1

    [<Fact>] member test.
     ``collection type should equal collection`` ()=
        [1..10] |> should equal [1..10]

    [<Fact>] member test.
     ``collection type should not equal equivalent if is not in same order`` ()=
        [1;2;3] |> should not' (equal [3;2;1])

    [<Fact>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<Fact>] member test.
     ``reference type should fail to equal other`` ()=
        anObj |> should not' (equal otherObj)

    [<Fact>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not' (equal otherObj)

    [<Fact>] member test.
     ``reference type should fail to not equal itself`` ()=
        anObj |> should equal anObj

    [<Fact>] member test.
     ``should fail when Equals returns false`` ()=
        anObj |> should not' (equal (new NeverEqual()))

    [<Fact>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not' (equal (new NeverEqual()))

    [<Fact>] member test.
     ``should pass when comparing two lists that have the same values`` ()=
        [1] |> should equal [1]

    [<Fact>] member test.
     ``should pass when comparing two arrays that have the same values`` ()=
        [|1|] |> should equal [|1|]

     [<Fact>] member test.
     ``should pass when comparing two lists that do not have the same values`` ()=
        [1] |> should not' (equal [2])

    [<Fact>] member test.
     ``should pass when comparing two arrays that do not have the same values`` ()=
        [|1|] |> should not' (equal [|2|])

    [<Fact>] member test.
     ``None should equal None`` ()=
        None |> should equal None

    [<Fact>] member test.
     ``structural value type should equal equivalent value`` () =
        anImmutableArray |> should equal equivalentImmutableArray

    [<Fact>] member test.
     ``structural value type should not equal non-equivalent value`` () =
        anImmutableArray |> should not' (equal otherImmutableArray)

