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
        if Seq.exists ((=) x) y
        then failwithf "Seq %A should not contain %A" y x

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (x: 'a) (y: 'a) =
        Assert.Less(y, x, sprintf "Expected: %A\nActual: %A" x y)

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (x: 'a) (y: 'a) =
        Assert.Greater(y, x, sprintf "Expected: %A\nActual: %A" x y)

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        Assert.Throws(Is.InstanceOf<'exn>(), TestDelegate(f)) |> ignore

    [<DebuggerStepThrough>]
    let shouldContainText (x: string) (y: string) =
        if y.Contains(x) |> not
        then failwithf "\"%s\" is not a substring of \"%s\"" x y

    [<DebuggerStepThrough>]
    let shouldNotContainText (x: string) (y: string) =
        if y.Contains(x)
        then failwithf "\"%s\" is a substring of \"%s\"" x y

    [<DebuggerStepThrough>]
    let shouldHaveLength expected list =
        let actual = Seq.length list
        if actual <> expected
        then failwithf "Invalid length in %A\r\nExpected: %i\r\nActual: %i" list expected actual
