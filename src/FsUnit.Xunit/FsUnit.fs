module FsUnit.Xunit

open System
open Xunit
open Xunit.Sdk
open NHamcrest
open NHamcrest.Core

type Assert with

    static member That<'a>(actual, matcher: IMatcher<'a>) =
        if not(matcher.Matches(actual)) then
            let description = StringDescription()
            matcher.DescribeTo(description)

            let raiseEqualException(value: string) =
                raise(EqualException.ForMismatchedValues(description.ToString(), value))

            match box actual with
            | :? (unit -> unit) as actualFunc ->
                (try
                    actualFunc()
                    String.Empty
                 with ex ->
                     ex.ToString())
                |> raiseEqualException
            | _ -> $"%A{actual}" |> raiseEqualException

let inline should (f: 'a -> ^b) x (actual: obj) =
    let matcher = f x

    let actual =
        match actual with
        | :? (unit -> unit) as assertFunc -> box assertFunc
        | :? (unit -> obj) as assertFunc -> box(assertFunc >> ignore)
        | _ -> actual

    if isNull(box matcher) then
        Assert.That(actual, Is.Null())
    else
        Assert.That(actual, matcher)

let inline shouldFail(f: unit -> unit) =
    let failed =
        try
            f()
            false
        with _ ->
            true

    if not failed then
        raise(ThrowsException.ForNoException(f.GetType()))

let equalSeq expected =
    CustomMatchers.equalSeq (fun (e: seq<'a>) (a: seq<'a>) -> Assert.Equal<seq<'a>>(e, a)) expected

let equal expected =
    CustomMatchers.equal expected

let equivalent expected =
    CustomMatchers.equivalent (fun e a -> Assert.Equivalent(e, a, true)) expected

let equalWithin (tolerance: obj) (expected: obj) =
    CustomMatchers.equalWithin tolerance expected

let not'(expected: obj) =
    CustomMatchers.not' expected

let throw(t: Type) =
    CustomMatchers.throw t

let throwWithMessage (m: string) (t: Type) =
    CustomMatchers.throwWithMessage m t

let be = CustomMatchers.be

let Null = CustomMatchers.Null

let Empty = CustomMatchers.Empty

let EmptyString = CustomMatchers.EmptyString

let NullOrEmptyString = CustomMatchers.NullOrEmptyString

let True = CustomMatchers.True

let False = CustomMatchers.False

let NaN = CustomMatchers.NaN

let unique = CustomMatchers.unique

let sameAs expected =
    CustomMatchers.sameAs expected

let greaterThan(expected: obj) =
    CustomMatchers.greaterThan expected

let greaterThanOrEqualTo(expected: obj) =
    CustomMatchers.greaterThanOrEqualTo expected

let lessThan(expected: obj) =
    CustomMatchers.lessThan expected

let lessThanOrEqualTo(expected: obj) =
    CustomMatchers.lessThanOrEqualTo expected

let endWith(expected: string) =
    CustomMatchers.endWith expected

let startWith(expected: string) =
    CustomMatchers.startWith expected

let haveSubstring(expected: string) =
    CustomMatchers.haveSubstring expected

let ofExactType<'a> = CustomMatchers.ofExactType<'a>

let instanceOfType<'a> = CustomMatchers.instanceOfType<'a>

let contain expected =
    CustomMatchers.contain expected

let haveLength expected =
    CustomMatchers.haveLength expected

let haveCount expected =
    CustomMatchers.haveCount expected

let matchList = CustomMatchers.matchList

let choice = CustomMatchers.choice

let ascending = CustomMatchers.ascending

let descending = CustomMatchers.descending

let inRange min max =
    CustomMatchers.inRange min max

let supersetOf expected =
    CustomMatchers.supersetOf expected

let subsetOf expected =
    CustomMatchers.subsetOf expected
