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
    let shouldContain (x: 'a) (y: 'a seq) =
        let list = List<_>()

        for a in y do
            list.Add a

        Assert.Contains(x, list)

    [<DebuggerStepThrough>]
    let shouldBeEmpty(list: 'a seq) =
        Assert.IsEmpty(list)

    [<DebuggerStepThrough>]
    let shouldNotContain (x: 'a) (y: 'a seq) =
        if Seq.exists ((=) x) y then
            failwith $"Seq %A{y} should not contain %A{x}"

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
    let shouldContainText (x: string) (y: string) =
        if y.Contains(x) |> not then
            failwith $"\"{x}\" is not a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldNotContainText (x: string) (y: string) =
        if y.Contains(x) then
            failwith $"\"{x}\" is a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldHaveLength expected list =
        let actual = Seq.length list

        if actual <> expected then
            failwith $"Invalid length in %A{list}\r\nExpected: {expected}\r\nActual: {actual}"
