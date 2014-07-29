module FsUnit.MbUnit

open System
open MbUnit.Framework
open NHamcrest
open NHamcrest.Core

let inline should (f : 'a -> ^b) x (y : obj) =
    let c = f x
    let y =
        match y with
        | :? (unit -> unit) as assertFunc -> box assertFunc
        | _ -> y
    Assert.That(y, c)

let equal expected = CustomMatchers.equal expected

let equalWithin (tolerance:obj) (expected:obj) = CustomMatchers.equalWithin tolerance expected

let not' (expected:obj) = CustomMatchers.not' expected

let throw (t:Type) = CustomMatchers.throw t

let throwWithMessage (m:string) (t:Type) = CustomMatchers.throwWithMessage m t

let be = CustomMatchers.be

let Null = CustomMatchers.Null

let EmptyString = CustomMatchers.EmptyString

let NullOrEmptyString = CustomMatchers.NullOrEmptyString

let True = CustomMatchers.True

let False = CustomMatchers.False

let sameAs expected = CustomMatchers.sameAs expected

let greaterThan (expected:obj) = CustomMatchers.greaterThan expected

let greaterThanOrEqualTo (expected:obj) = CustomMatchers.greaterThanOrEqualTo expected

let lessThan (expected:obj) = CustomMatchers.lessThan expected

let lessThanOrEqualTo (expected:obj) = CustomMatchers.lessThanOrEqualTo expected

let endWith (expected:string) = CustomMatchers.endWith expected

let startWith (expected:string) = CustomMatchers.startWith expected

let ofExactType<'a> = CustomMatchers.ofExactType<'a>

let contain expected = CustomMatchers.contain expected

let matchList = CustomMatchers.matchList

let choice = CustomMatchers.choice

module FsUnitDepricated = 
    let not x = not' x

// haveLength, haveCount, Empty, and shouldFail are not implemented for MbUnit and xUnit
