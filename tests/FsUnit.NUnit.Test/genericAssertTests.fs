namespace FsUnit.GenericAssert.Tests

open System.Collections.Immutable

open NUnit.Framework
open FsUnit

type Assert = FsUnit.Assert

type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1


type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1

[<TestFixture>]
type ``areEqual Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let equivalentImmutableArray = ImmutableArray.Create(1, 2, 3)

    [<Test>]
    member __.``value type should equal equivalent value``() =
        Assert.AreEqual(1, 1)

    [<Test>]
    member __.``value type should fail to equal nonequivalent value``() =
        shouldFail(fun () -> Assert.AreEqual(1, 2))

    [<Test>]
    member __.``reference type should equal itself``() =
        Assert.AreEqual(anObj, anObj)

    [<Test>]
    member __.``reference type should fail to equal other``() =
        shouldFail(fun () -> Assert.AreEqual(anObj, otherObj))

    [<Test>]
    member __.``should pass when Equals returns true``() =
        Assert.AreEqual(box(new AlwaysEqual()), anObj)

    [<Test>]
    member __.``should fail when Equals returns false``() =
        shouldFail(fun () -> Assert.AreEqual(anObj, box(new NeverEqual())))

    [<Test>]
    member __.``None should equal None``() =
        Assert.AreEqual(None, None)

    [<Test>]
    member this.``structural equality``() =
        let actualList: char list = []
        Assert.AreEqual([ ([], "") ], [ (actualList, "") ])

    [<Test>]
    member __.``Empty obj list should match itself``() =
        Assert.AreEqual([], [])

    [<Test>]
    member __.``structural value type should equal equivalent value``() =
        Assert.AreEqual(anImmutableArray, equivalentImmutableArray)

[<TestFixture>]
type ``areNotEqual Tests``() =
    let anObj = new obj()
    let otherObj = new obj()
    let anImmutableArray = ImmutableArray.Create(1, 2, 3)
    let otherImmutableArray = ImmutableArray.Create(1, 2, 4)

    [<Test>]
    member __.``value type should not equal nonequivalent value``() =
        Assert.AreNotEqual(1, 2)

    [<Test>]
    member __.``value type should fail to not equal equivalent value``() =
        shouldFail(fun () -> Assert.AreNotEqual(1, 1))

    [<Test>]
    member __.``reference type should not equal other``() =
        Assert.AreNotEqual(anObj, otherObj)

    [<Test>]
    member __.``reference type should fail to not equal itself``() =
        shouldFail(fun () -> Assert.AreNotEqual(anObj, anObj))

    [<Test>]
    member __.``should pass when negated and Equals returns false``() =
        Assert.AreNotEqual(box(new NeverEqual()), anObj)

    [<Test>]
    member __.``should fail when negated and Equals returns true``() =
        shouldFail(fun () -> Assert.AreNotEqual(box(new AlwaysEqual()), anObj))

    [<Test>]
    member __.``List with elements should not match empty list``() =
        Assert.AreNotEqual([], [ 1 ])

    [<Test>]
    member __.``structural value type should not equal non-equivalent value``() =
        Assert.AreNotEqual(anImmutableArray, otherImmutableArray)

[<TestFixture>]
type ``areSame tests``() =
    let anObj = new obj()
    let otherObj = new obj()

    [<Test>]
    member __.``an object should be the same as itself``() =
        Assert.AreSame(anObj, anObj)

    [<Test>]
    member __.``an object should fail to be same as different object``() =
        shouldFail(fun () -> Assert.AreSame(anObj, otherObj))

[<TestFixture>]
type ``areNotSame tests``() =
    let anObj = new obj()
    let otherObj = new obj()

    [<Test>]
    member __.``an object should not be same as different object``() =
        Assert.AreNotSame(anObj, otherObj)

    [<Test>]
    member __.``an object should fail to not be same as itself``() =
        shouldFail(fun () -> Assert.AreNotSame(anObj, anObj))

[<TestFixture>]
type ``contains tests``() =
    [<Test>]
    member __.``List with item should contain item``() =
        Assert.Contains(1, [ 1 ])

    [<Test>]
    member __.``empty List should fail to contain item``() =
        shouldFail(fun () -> Assert.Contains(1, []))

    [<Test>]
    member __.``Array with item should contain item``() =
        Assert.Contains(1, [| 1 |])

    [<Test>]
    member __.``empty Array should fail to contain item``() =
        shouldFail(fun () -> Assert.Contains(1, [||]))

    [<Test>]
    member __.``Seq with item should contain item``() =
        Assert.Contains(1, seq { yield 1 })

    [<Test>]
    member __.``empty Seq should fail to contain item``() =
        shouldFail(fun () -> Assert.Contains(1, Seq.empty))

[<TestFixture>]
type ``greater tests``() =
    [<Test>]
    member __.``11 should be greater than 10``() =
        Assert.Greater(11, 10)

    [<Test>]
    member __.``11[dot]1 should be greater than 11[dot]0``() =
        Assert.Greater(11.1, 11.0)

    [<Test>]
    member __.``9 should not be greater than 10``() =
        shouldFail(fun () -> Assert.Greater(9, 10))

    [<Test>]
    member __.``9[dot]1 should not be greater than 9[dot]2``() =
        shouldFail(fun () -> Assert.Greater(9.1, 9.2))

    [<Test>]
    member __.``9[dot]2 should not be greater than 9[dot]2``() =
        shouldFail(fun () -> Assert.Greater(9.2, 9.2))

[<TestFixture>]
type ``greaterOrEqual tests``() =
    [<Test>]
    member __.``11 should be greater than 10``() =
        Assert.GreaterOrEqual(11, 10)

    [<Test>]
    member __.``11[dot]1 should be greater than 11[dot]0``() =
        Assert.GreaterOrEqual(11.1, 11.0)

    [<Test>]
    member __.``9 should not be greater than 10``() =
        shouldFail(fun () -> Assert.GreaterOrEqual(9, 10))

    [<Test>]
    member __.``9[dot]1 should not be greater than 9[dot]2``() =
        shouldFail(fun () -> Assert.GreaterOrEqual(9.1, 9.2))

    [<Test>]
    member __.``9[dot]2 should be equal to 9[dot]2``() =
        Assert.GreaterOrEqual(9.2, 9.2)

    [<Test>]
    member __.``9 should be equal to 9``() =
        Assert.GreaterOrEqual(9, 9)

[<TestFixture>]
type ``less tests``() =
    [<Test>]
    member __.``10 should be less than 11``() =
        Assert.Less(10, 11)

    [<Test>]
    member __.``10[dot]0 should be less than 10[dot]1``() =
        Assert.Less(10.0, 10.1)

    [<Test>]
    member __.``10 should not be less than 9``() =
        shouldFail(fun () -> Assert.Less(10, 9))

    [<Test>]
    member __.``9[dot]2 should not be less than 9[dot]1``() =
        shouldFail(fun () -> Assert.Less(9.2, 9.1))

    [<Test>]
    member __.``9[dot]1 should not be less than 9[dot]1``() =
        shouldFail(fun () -> Assert.Less(9.1, 9.1))

[<TestFixture>]
type ``lessOrEqual tests``() =
    [<Test>]
    member __.``10 should be less than 11``() =
        Assert.LessOrEqual(10, 11)

    [<Test>]
    member __.``10[dot]0 should be less than 10[dot]1``() =
        Assert.LessOrEqual(10.0, 10.1)

    [<Test>]
    member __.``10 should not be less than 9``() =
        shouldFail(fun () -> Assert.LessOrEqual(10, 9))

    [<Test>]
    member __.``9[dot]2 should not be less than 9[dot]1``() =
        shouldFail(fun () -> Assert.LessOrEqual(9.2, 9.1))

    [<Test>]
    member __.``9[dot]1 should be less than or equal to 9[dot]1``() =
        Assert.LessOrEqual(9.1, 9.1)

[<TestFixture>]
type ``null tests``() =
    [<Test>]
    member __.``null should be Null``() =
        Assert.Null(null)

    [<Test>]
    member __.``non-null should fail to be null``() =
        shouldFail(fun () -> Assert.Null("something"))

[<TestFixture>]
type ``notNull tests``() =
    [<Test>]
    member __.``non-null should not be Null``() =
        Assert.NotNull("something")

    [<Test>]
    member __.``null should fail to not be null``() =
        shouldFail(fun () -> Assert.NotNull(null))
