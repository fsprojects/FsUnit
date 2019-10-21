namespace FsUnit.Test
open NUnit.Framework
open FsUnit

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
     ``collection type should equal collection`` ()=
        [1..10] |> should equal [1..10]

    [<Test>] member test.
     ``collection type should not equal equivalent if is not in same order`` ()=
        [1;2;3] |> should  not' (equal [3;2;1])

    [<Test>] member test.
     ``collection type should equivalent collection `` ()=
        [1..10] |> should equivalent [1..10]

    [<Test>] member test.
     ``collection type should equal equivalent independent of order`` ()=
        [1;2;3] |> should  equivalent [3;2;1]

    [<Test>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        shouldFail (fun () -> 1 |> should equal 2)

    [<Test>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should not' (equal 2)

    [<Test>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        shouldFail (fun () -> 1 |> should not' (equal 1))

    [<Test>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<Test>] member test.
     ``reference type should fail to equal other`` ()=
        shouldFail (fun () -> anObj |> should equal otherObj)

    [<Test>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should not' (equal otherObj)

    [<Test>] member test.
     ``reference type should fail to not equal itself`` ()=
        shouldFail (fun () -> anObj |> should not' (equal anObj))

    [<Test>] member test.
     ``should pass when Equals returns true`` ()=
        anObj |> should equal (new AlwaysEqual())

    [<Test>] member test.
     ``should fail when Equals returns false`` ()=
        shouldFail (fun () -> anObj |> should equal (new NeverEqual()))

    [<Test>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should not' (equal (new NeverEqual()))

    [<Test>] member test.
     ``should fail when negated and Equals returns true`` ()=
        shouldFail (fun () -> anObj |> should not' (equal (new AlwaysEqual())))

    [<Test>] member test.
     ``None should equal None`` ()=
        None |> should equal None
