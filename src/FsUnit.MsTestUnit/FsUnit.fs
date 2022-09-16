module FsUnit.MsTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open NHamcrest
open NHamcrest.Core

let inline private assertThat(actual, matcher: IMatcher<'a>) =
    if not(matcher.Matches(actual)) then
        let description = StringDescription()
        matcher.DescribeTo(description)

        let raiseAssertFailedException value =
            raise(AssertFailedException($"%A{description} was %A{value}", null))

        match box actual with
        | :? (unit -> unit) as actualfunc ->
            (try
                actualfunc()
                String.Empty
             with ex ->
                 ex.ToString())
            |> raiseAssertFailedException
        | _ -> actual |> raiseAssertFailedException

type Assert with

    static member That<'a>(actual, matcher: IMatcher<'a>) =
        assertThat(actual, matcher)

let inline should (f: 'a -> ^b) x (actual: obj) =
    let matcher = f x

    let actual =
        match actual with
        | :? (unit -> unit) as assertFunc -> box assertFunc
        | _ -> actual

    if isNull(box matcher) then
        assertThat(actual, Is.Null())
    else
        assertThat(actual, matcher)

let inline shouldFail(f: unit -> unit) =
    let failed =
        try
            f()
            false
        with _ ->
            true

    if not failed then
        raise(AssertFailedException("Method should fail"))

let equal expected =
    CustomMatchers.equal expected

let equivalent expected =
    CustomMatchers.equivalent (fun e a -> CollectionAssert.AreEquivalent(e, a)) expected

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

let haveLength n =
    CustomMatchers.haveLength n

let haveCount n =
    CustomMatchers.haveCount n

let matchList = CustomMatchers.matchList

let choice = CustomMatchers.choice

let ascending = CustomMatchers.ascending

let descending = CustomMatchers.descending

let inRange min max =
    CustomMatchers.inRange min max

let ofCase case =
    CustomMatchers.ofCase case

let supersetOf expected =
    CustomMatchers.supersetOf expected

let subsetOf expected =
    CustomMatchers.subsetOf expected
