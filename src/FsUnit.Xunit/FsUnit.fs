module FsUnit.Xunit

open System
open Xunit
open Xunit.Sdk
open NHamcrest
open NHamcrest.Core

type MatchException (expected, actual, userMessage) =
    inherit AssertActualExpectedException(expected, actual, userMessage)

type Xunit.Assert with
    static member That<'a> (actual, matcher:IMatcher<'a>) =
        if not (matcher.Matches(actual)) then
            let description = new StringDescription()
            matcher.DescribeTo(description)
            let mismatchDescription = new StringDescription()
            matcher.DescribeMismatch(actual, mismatchDescription)
            raise (new MatchException(description.ToString(), mismatchDescription.ToString(), null))

let inline should (f : 'a -> ^b) x (y : obj) =
    let c = f x
    let y =
        match y with
        | :? (unit -> unit) as assertFunc -> box assertFunc
        | _ -> y
    if box c = null then
        Assert.That(y, Is.Null())
    else
        Assert.That(y, c)

let inline shouldFail (f:unit->unit) =
    let failed =
        try
            f()
            false
        with
        | _ -> true
    if not failed then
        raise (new MatchException("Method should fail", "No exception raised", null))


let equal expected = CustomMatchers.equal expected

let equalWithin (tolerance:obj) (expected:obj) = CustomMatchers.equalWithin tolerance expected

let not' (expected:obj) = CustomMatchers.not' expected

let throw (t:Type) = CustomMatchers.throw t

let throwWithMessage (m:string) (t:Type) = CustomMatchers.throwWithMessage m t

let be = CustomMatchers.be

let Null = CustomMatchers.Null

let Empty = CustomMatchers.Empty

let EmptyString = CustomMatchers.EmptyString

let NullOrEmptyString = CustomMatchers.NullOrEmptyString

let True = CustomMatchers.True

let False = CustomMatchers.False

let NaN = CustomMatchers.NaN

let unique = CustomMatchers.unique

let sameAs expected = CustomMatchers.sameAs expected

let greaterThan (expected:obj) = CustomMatchers.greaterThan expected

let greaterThanOrEqualTo (expected:obj) = CustomMatchers.greaterThanOrEqualTo expected

let lessThan (expected:obj) = CustomMatchers.lessThan expected

let lessThanOrEqualTo (expected:obj) = CustomMatchers.lessThanOrEqualTo expected

let endWith (expected:string) = CustomMatchers.endWith expected

let startWith (expected:string) = CustomMatchers.startWith expected

let haveSubstring (expected:string) = CustomMatchers.haveSubstring expected

let ofExactType<'a> = CustomMatchers.ofExactType<'a>

let instanceOfType<'a> = CustomMatchers.instanceOfType<'a>

let contain expected = CustomMatchers.contain expected

let haveLength n = CustomMatchers.haveLength n

let haveCount n = CustomMatchers.haveCount n

let matchList = CustomMatchers.matchList

let choice = CustomMatchers.choice

let ascending = CustomMatchers.ascending

let descending = CustomMatchers.descending
