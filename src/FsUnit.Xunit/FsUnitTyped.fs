namespace FsUnitTyped

open System.Diagnostics
open Xunit
open System.Collections.Generic
open FsUnit.Xunit

[<AutoOpen>]
module TopLevelOperators =

    [<DebuggerStepThrough>]
    let shouldEqual (expected: 'a) (actual: 'a) =
        expected |> should equal actual

    [<DebuggerStepThrough>]
    let shouldNotEqual (expected: 'a) (actual: 'a) =
        expected |> should not' (equal actual)

    [<DebuggerStepThrough>]
    let shouldContain (x: 'a) (y: 'a seq) =
        y |> should contain x

    [<DebuggerStepThrough>]
    let shouldBeEmpty(list: 'a seq) =
        list |> should be Empty

    [<DebuggerStepThrough>]
    let shouldNotContain (x: 'a) (y: 'a seq) =
        if Seq.exists ((=) x) y
        then failwith $"Seq %A{y} should not contain %A{x}"

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan (x: 'a) (y: 'a) =
        if not (x < y) then
            failwith $"Expected:\n  %A{x}\nto be smaller than:\n  %A{y}"

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan (x: 'a) (y: 'a) =
        if not (x > y) then
            failwith $"Expected:\n  %A{x}\nto be greater than:\n  %A{y}"

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        f |> should throw typeof<'exn>

    [<DebuggerStepThrough>]
    let shouldContainText (x: string) (y: string) =
        if y.Contains(x) |> not
        then failwith $"\"{x}\" is not a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldNotContainText (x: string) (y: string) =
        if y.Contains(x)
        then failwith $"\"{x}\" is a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldHaveLength expected list =
        let actual = Seq.length list
        if actual <> expected
        then failwith $"Invalid length in %A{list}\r\nExpected: {expected}\r\nActual: {actual}"
