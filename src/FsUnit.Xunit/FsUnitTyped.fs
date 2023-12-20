namespace FsUnitTyped

open System.Diagnostics
open Xunit
open FsUnit.Xunit

[<AutoOpen>]
module TopLevelOperators =

    [<DebuggerStepThrough>]
    let shouldEqual<'a> (expected: 'a) (actual: 'a) =
        actual |> should equal expected

    [<DebuggerStepThrough>]
    let shouldNotEqual<'a> (expected: 'a) (actual: 'a) =
        actual |> should not' (equal expected)

    [<DebuggerStepThrough>]
    let shouldContain<'a when 'a: equality> (expected: 'a) (actual: 'a seq) =
        actual |> should contain expected

    [<DebuggerStepThrough>]
    let shouldBeEmpty<'a>(actual: 'a seq) =
        Assert.Empty actual

    [<DebuggerStepThrough>]
    let shouldNotContain<'a when 'a: equality> (expected: 'a) (actual: 'a seq) =
        if Seq.exists ((=) expected) actual then
            failwith $"Seq %A{actual} should not contain %A{expected}"

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan<'a when 'a: comparison> (expected: 'a) (actual: 'a) =
        actual |> should be (lessThan expected)

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan<'a when 'a: comparison> (expected: 'a) (actual: 'a) =
        actual |> should be (greaterThan expected)

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        f |> should throw typeof<'exn>

    [<DebuggerStepThrough>]
    let shouldContainText (expected: string) (actual: string) =
        if actual.Contains(expected) |> not then
            failwith $"\"{expected}\" is not a substring of \"{actual}\""

    [<DebuggerStepThrough>]
    let shouldNotContainText (expected: string) (actual: string) =
        if actual.Contains(expected) then
            failwith $"\"{expected}\" is a substring of \"{actual}\""

    [<DebuggerStepThrough>]
    let shouldHaveLength<'a> (expected: int) (actual: 'a seq) =
        let actual = Seq.length actual

        if actual <> expected then
            failwith $"Invalid length in %A{actual}\r\nExpected: {expected}\r\nActual: {actual}"
