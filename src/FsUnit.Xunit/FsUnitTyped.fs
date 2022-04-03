namespace FsUnitTyped

open System.Diagnostics
open FsUnit.Xunit

[<AutoOpen>]
module TopLevelOperators =

    [<DebuggerStepThrough>]
    let shouldEqual<'a> (expected: 'a) (actual: 'a) =
        should equal expected actual

    [<DebuggerStepThrough>]
    let shouldNotEqual<'a> (expected: 'a) (actual: 'a) =
        expected |> should not' (equal actual)

    [<DebuggerStepThrough>]
    let shouldContain<'a when 'a : equality> (x: 'a) (y: 'a seq) =
        y |> should contain x

    [<DebuggerStepThrough>]
    let shouldBeEmpty<'a> (list: 'a seq) =
        list |> should be Empty

    [<DebuggerStepThrough>]
    let shouldNotContain<'a when 'a : equality> (x: 'a) (y: 'a seq) =
        if Seq.exists ((=) x) y then
            failwith $"Seq %A{y} should not contain %A{x}"

    [<DebuggerStepThrough>]
    let shouldBeSmallerThan<'a when 'a : comparison> (x: 'a) (y: 'a) =
        should be (lessThan x) y

    [<DebuggerStepThrough>]
    let shouldBeGreaterThan<'a when 'a : comparison> (x: 'a) (y: 'a) =
        should be (greaterThan x) y

    [<DebuggerStepThrough>]
    let shouldFail<'exn when 'exn :> exn>(f: unit -> unit) =
        should throw typeof<'exn> f

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
