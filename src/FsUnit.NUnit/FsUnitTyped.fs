namespace FsUnitTyped

open System.Diagnostics
open NUnit.Framework

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
        Assert.That(actual, Does.Contain(expected))

    [<DebuggerStepThrough>]
    let shouldBeEmpty(actual: 'a seq) =
        Assert.That(actual, Is.Empty)

    [<DebuggerStepThrough>]
    let shouldNotContain (expected: 'a) (actual: 'a seq) =
        Assert.That(actual, Does.Not.Contain(expected), $"Seq %A{actual} should not contain %A{expected}")

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (expected: 'a) (actual: 'a) =
        Assert.That(actual, Is.LessThan(expected))

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (expected: 'a) (actual: 'a) =
        Assert.That(actual, Is.GreaterThan(expected))

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        Assert.Throws(Is.InstanceOf<'exn>(), TestDelegate(f)) |> ignore

    [<DebuggerStepThrough>]
    let shouldContainText (expected: string) (actual: string) =
        Assert.That(actual, Does.Contain(expected))

    [<DebuggerStepThrough>]
    let shouldNotContainText (expected: string) (actual: string) =
        Assert.That(actual, Does.Not.Contain(expected))

    [<DebuggerStepThrough>]
    let shouldHaveLength (expected: int) actual =
        Assert.That(Seq.length actual, Is.EqualTo(expected), $"Invalid length in %A{actual}")
