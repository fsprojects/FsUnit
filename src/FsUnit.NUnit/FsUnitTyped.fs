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
    let shouldContain (actual: 'a) (expected: 'a seq) =
        Assert.Contains(actual, Seq.toArray expected)

    [<DebuggerStepThrough>]
    let shouldBeEmpty(actual: 'a seq) =
        Assert.IsEmpty(actual)

    [<DebuggerStepThrough>]
    let shouldNotContain (expected: 'a) (actual: 'a seq) =
        Assert.That(actual, Does.Not.Contain(expected), $"Seq %A{actual} should not contain %A{expected}")

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (expected: 'a) (actual: 'a) =
        Assert.Less(actual, expected)

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (expected: 'a) (actual: 'a) =
        Assert.Greater(actual, expected)

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        Assert.Throws(Is.InstanceOf<'exn>(), TestDelegate(f)) |> ignore

    [<DebuggerStepThrough>]
    let shouldContainText (expected: string) (actual: string) =
        Assert.That(actual, Does.Contain(expected), $"\"{expected}\" is not a substring of \"{actual}\"")

    [<DebuggerStepThrough>]
    let shouldNotContainText (expected: string) (actual: string) =
        Assert.That(actual, Does.Not.Contain(expected), $"\"{expected}\" is a substring of \"{actual}\"")

    [<DebuggerStepThrough>]
    let shouldHaveLength expected actual =
        Assert.That(Seq.length actual, Is.EqualTo(expected), $"Invalid length in %A{actual}")
