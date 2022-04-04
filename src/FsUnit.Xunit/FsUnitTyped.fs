namespace FsUnitTyped

open System.Diagnostics
open Xunit
open FsUnit.Xunit

[<AutoOpen>]
module TopLevelOperators =

    /// Asserts that `expected` is equal to `actual`.
    /// The equality instance on `actual` is used, if available.
    [<DebuggerStepThrough>]
    let shouldEqual<'a> (expected: 'a) (actual: 'a) =
        actual |> should equal expected

    /// Asserts that `expected` is not equal to `actual`.
    /// The equality instance on `actual` is used, if available.
    [<DebuggerStepThrough>]
    let shouldNotEqual<'a> (expected: 'a) (actual: 'a) =
        actual |> should not' (equal expected)

    [<DebuggerStepThrough>]
    let shouldContain<'a when 'a: equality> (x: 'a) (y: 'a seq) =
        y |> should contain x

    [<DebuggerStepThrough>]
    let shouldBeEmpty<'a>(list: 'a seq) =
        Assert.Empty list

    [<DebuggerStepThrough>]
    let shouldNotContain<'a when 'a: equality> (x: 'a) (y: 'a seq) =
        if Seq.exists ((=) x) y then
            failwith $"Seq %A{y} should not contain %A{x}"

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan<'a when 'a: comparison> (x: 'a) (y: 'a) =
        y |> should be (lessThan x)

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan<'a when 'a: comparison> (x: 'a) (y: 'a) =
        y |> should be (greaterThan x)

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        f |> should throw typeof<'exn>

    [<DebuggerStepThrough>]
    let shouldContainText (x: string) (y: string) =
        if y.Contains(x) |> not then
            failwith $"\"{x}\" is not a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldNotContainText (x: string) (y: string) =
        if y.Contains(x) then
            failwith $"\"{x}\" is a substring of \"{y}\""

    [<DebuggerStepThrough>]
    let shouldHaveLength<'a> (expected: int) (list: 'a seq) =
        let actual = Seq.length list

        if actual <> expected then
            failwith $"Invalid length in %A{list}\r\nExpected: {expected}\r\nActual: {actual}"
