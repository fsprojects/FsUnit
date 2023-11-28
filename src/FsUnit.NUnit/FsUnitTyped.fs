namespace FsUnitTyped

open System
open System.Diagnostics
open NUnit.Framework
open NUnit.Framework.Legacy

[<AutoOpen>]
module TopLevelOperators =

    [<DebuggerStepThrough>]
    let shouldEqual (expected: 'a) (actual: 'a) =
        Assert.That(actual, FsUnit.Equality.IsEqualTo(expected))

    [<DebuggerStepThrough>]
    let shouldNotEqual (expected: 'a) (actual: 'a) =
        Assert.That(actual, FsUnit.Equality.IsNotEqualTo(expected))

    [<DebuggerStepThrough>]
    let shouldContain (expected: 'a) (actual: 'a seq) =
        CollectionAssert.Contains(actual, expected)

    [<DebuggerStepThrough>]
    let shouldBeEmpty(actual: 'a seq) =
        ClassicAssert.IsEmpty(actual)

    [<DebuggerStepThrough>]
    let shouldNotContain (expected: 'a) (actual: 'a seq) =
        CollectionAssert.DoesNotContain(actual, expected, $"Seq %A{actual} should not contain %A{expected}")

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (expected: 'a) (actual: 'a) =
        ClassicAssert.Less(actual, expected)

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (expected: 'a) (actual: 'a) =
        ClassicAssert.Greater(actual, expected)

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        Assert.Throws(Is.InstanceOf<'exn>(), TestDelegate(f)) |> ignore

    [<DebuggerStepThrough>]
    let shouldContainText (expected: string) (actual: string) =
        StringAssert.Contains(expected, actual)

    [<DebuggerStepThrough>]
    let shouldNotContainText (expected: string) (actual: string) =
        StringAssert.DoesNotContain(expected, actual)

    [<DebuggerStepThrough>]
    let shouldHaveLength (expected: int) actual =
        Assert.That(Seq.length actual, Is.EqualTo(expected), $"Invalid length in %A{actual}")
