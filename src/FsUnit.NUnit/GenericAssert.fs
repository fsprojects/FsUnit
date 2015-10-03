// TODO : Add license header.

namespace FsUnit

open System
open System.Collections.Generic
open NUnit.Framework
open NUnit.Framework.Constraints
open LanguagePrimitives

/// Generic test assertions.
[<AbstractClass; Sealed>]
type Assert =
    /// <summary>
    /// Verifies that two values are equal.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    static member AreEqual<'T when 'T : equality> (expected : 'T, actual : 'T) : unit =
        let eqConstraint = Is.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, eqConstraint, null, null)

    /// <summary>
    /// Verifies that two values are equal.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreEqual<'T when 'T : equality> (expected : 'T, actual : 'T, message : string) : unit =
        let eqConstraint = Is.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, eqConstraint, message, null)

    /// <summary>
    /// Verifies that two values are equal.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreEqual<'T when 'T : equality>
        (expected : 'T, actual : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        let eqConstraint = Is.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, eqConstraint, message, args)

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    static member AreNotEqual<'T when 'T : equality> (expected : 'T, actual : 'T) : unit =
        let neqConstraint = Is.Not.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, neqConstraint, null, null)

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreNotEqual<'T when 'T : equality> (expected : 'T, actual : 'T, message : string) : unit =
        let neqConstraint = Is.Not.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, neqConstraint, message, null)

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreNotEqual<'T when 'T : equality>
        (expected : 'T, actual : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        let neqConstraint = Is.Not.EqualTo(expected).Using FastGenericEqualityComparer<'T>
        Assert.That (actual, neqConstraint, message, args)

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    static member AreNotSame<'T when 'T : not struct> (expected : 'T, actual : 'T) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That (actual, sameConstraint, null, null)

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreNotSame<'T when 'T : not struct> (expected : 'T, actual : 'T, message : string) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That (actual, sameConstraint, message, null)

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreNotSame<'T when 'T : not struct>
        (expected : 'T, actual : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That (actual, sameConstraint, message, args)

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    static member AreSame<'T when 'T : not struct> (expected : 'T, actual : 'T) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That (actual, sameConstraint, null, null)

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreSame<'T when 'T : not struct> (expected : 'T, actual : 'T, message : string) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That (actual, sameConstraint, message, null)

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreSame<'T when 'T : not struct>
        (expected : 'T, actual : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That (actual, sameConstraint, message, args)

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    static member Contains<'T> (expected : 'T, actual : ICollection<'T>) : unit =
        let containsConstraint = CollectionContainsConstraint (expected)
        Assert.That (actual, containsConstraint, null, null)

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Contains<'T> (expected : 'T, actual : ICollection<'T>, message : string) : unit =
        let containsConstraint = CollectionContainsConstraint (expected)
        Assert.That (actual, containsConstraint, null, null)

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Contains<'T>
        (expected : 'T, actual : ICollection<'T>, message : string, [<ParamArray>] args : obj[]) : unit =
        let containsConstraint = CollectionContainsConstraint (expected)
        Assert.That (actual, containsConstraint, null, null)

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    static member Greater<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T) : unit =
        Assert.That (arg1, Is.GreaterThan arg2, null, null)

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Greater<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T, message : string) : unit =
        Assert.That (arg1, Is.GreaterThan arg2, message, null)

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Greater<'T when 'T : comparison>
        (arg1 : 'T, arg2 : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg1, Is.GreaterThan arg2, message, args)

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    static member GreaterOrEqual<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T) : unit =
        Assert.That (arg1, Is.GreaterThanOrEqualTo arg2, null, null)

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member GreaterOrEqual<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T, message : string) : unit =
        Assert.That (arg1, Is.GreaterThanOrEqualTo arg2, message, null)

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member GreaterOrEqual<'T when 'T : comparison>
        (arg1 : 'T, arg2 : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg1, Is.GreaterThanOrEqualTo arg2, message, args)

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    static member Less<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T) : unit =
        Assert.That (arg1, Is.LessThan arg2, null, null)

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Less<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T, message : string) : unit =
        Assert.That (arg1, Is.LessThan arg2, message, null)

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Less<'T when 'T : comparison>
        (arg1 : 'T, arg2 : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg1, Is.LessThan arg2, message, args)

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    static member LessOrEqual<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T) : unit =
        Assert.That (arg1, Is.LessThanOrEqualTo arg2, null, null)

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member LessOrEqual<'T when 'T : comparison> (arg1 : 'T, arg2 : 'T, message : string) : unit =
        Assert.That (arg1, Is.LessThanOrEqualTo arg2, message, null)

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member LessOrEqual<'T when 'T : comparison>
        (arg1 : 'T, arg2 : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg1, Is.LessThanOrEqualTo arg2, message, args)

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    static member NotNull<'T when 'T : not struct> (arg : 'T) : unit =
        Assert.That (arg, Is.Not.Null, null, null)

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member NotNull<'T when 'T : not struct> (arg : 'T, message : string) : unit =
        Assert.That (arg, Is.Not.Null, message, null)

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member NotNull<'T when 'T : not struct>
        (arg : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg, Is.Not.Null, message, args)

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    static member Null<'T when 'T : not struct> (arg : 'T) : unit =
        Assert.That (arg, Is.Null, null, null)

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Null<'T when 'T : not struct> (arg : 'T, message : string) : unit =
        Assert.That (arg, Is.Null, message, null)

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Null<'T when 'T : not struct>
        (arg : 'T, message : string, [<ParamArray>] args : obj[]) : unit =
        Assert.That (arg, Is.Null, message, args)





