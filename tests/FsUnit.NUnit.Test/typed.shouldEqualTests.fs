namespace FsUnit.Typed.Test
open NUnit.Framework
open FsUnit.Typed

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1


type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1


[<TestFixture>]
type ``shouldEqual Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()

    [<Test>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> shouldEqual 1

    [<Test>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        shouldFail (fun () -> 1 |> shouldEqual 2)

    [<Test>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> shouldNotEqual 2

    [<Test>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        shouldFail (fun () -> 1 |> shouldNotEqual 1)

    [<Test>] member test.
     ``reference type should equal itself`` ()=
        anObj |> shouldEqual anObj

    [<Test>] member test.
     ``reference type should fail to equal other`` ()=
        shouldFail (fun () -> anObj |> shouldEqual otherObj)

    [<Test>] member test.
     ``reference type should not equal other`` ()=
        anObj |> shouldNotEqual otherObj

    [<Test>] member test.
     ``reference type should fail to not equal itself`` ()=
        shouldFail (fun () -> anObj |> shouldNotEqual anObj)

    [<Test>] member test.
     ``should pass when Equals returns true`` ()=
        anObj |> shouldEqual (box(new AlwaysEqual()))

    [<Test>] member test.
     ``should fail when Equals returns false`` ()=
        shouldFail (fun () -> anObj |> shouldEqual (box(new NeverEqual())))

    [<Test>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> shouldNotEqual (box(new NeverEqual()))

    [<Test>] member test.
     ``should fail when negated and Equals returns true`` ()=
        shouldFail (fun () -> anObj |>shouldNotEqual (box(new AlwaysEqual())))

    [<Test>] member test.
     ``None should equal None`` ()=
        None |> shouldEqual None
