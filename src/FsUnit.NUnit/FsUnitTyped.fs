namespace FsUnitTyped

open System.Diagnostics
open NUnit.Framework
open System.Collections.Generic

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
        let list = List<_>()

        for a in actual do
            list.Add a

        Assert.Contains(expected, list)

    [<DebuggerStepThrough>]
    let shouldBeEmpty(actual: 'a seq) =
        Assert.IsEmpty(actual)

    [<DebuggerStepThrough>]
    let shouldNotContain (expected: 'a) (actual: 'a seq) =
        if Seq.exists ((=) expected) actual then
            failwith $"Seq %A{actual} should not contain %A{expected}"

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (x: 'a) (y: 'a) =
        Assert.Less(y, x, $"Expected: %A{x}\nActual: %A{y}")

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (x: 'a) (y: 'a) =
        Assert.Greater(y, x, $"Expected: %A{x}\nActual: %A{y}")

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        Assert.Throws(Is.InstanceOf<'exn>(), TestDelegate(f)) |> ignore

    [<DebuggerStepThrough>]
    let shouldContainText (expected: string) (actual: string) =
        if actual.Contains(expected) |> not then
            failwith $"\"{expected}\" is not a substring of \"{actual}\""

    [<DebuggerStepThrough>]
    let shouldNotContainText (expected: string) (actual: string) =
        if actual.Contains(expected) then
            failwith $"\"{expected}\" is a substring of \"{actual}\""

    [<DebuggerStepThrough>]
    let shouldHaveLength expected list =
        let actual = Seq.length list

        if actual <> expected then
            failwith $"Invalid length in %A{list}\r\nExpected: {expected}\r\nActual: {actual}"
