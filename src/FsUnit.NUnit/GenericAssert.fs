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
    static member AreEqual<'T when 'T: equality>(expected: 'T, actual: 'T) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        Assert.That<'T>(actual, eqConstraint)

    /// <summary>
    /// Verifies that two values are equal.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreEqual<'T when 'T: equality>(expected: 'T, actual: 'T, message: string) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        Assert.That<'T>(actual, eqConstraint, message)

    /// <summary>
    /// Verifies that two values are equal.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreEqual<'T when 'T: equality>(expected: 'T, actual: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        Assert.That<'T>(actual, eqConstraint, String.Format(message, args))

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    static member AreNotEqual<'T when 'T: equality>(expected: 'T, actual: 'T) : unit =
        let neqConstraint = Equality.IsNotEqualTo(expected)
        Assert.That<'T>(actual, neqConstraint)

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreNotEqual<'T when 'T: equality>(expected: 'T, actual: 'T, message: string) : unit =
        let neqConstraint = Equality.IsNotEqualTo(expected)
        Assert.That<'T>(actual, neqConstraint, message)

    /// <summary>
    /// Verifies that two values are not equal.
    /// If they are, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreNotEqual<'T when 'T: equality>(expected: 'T, actual: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        let neqConstraint = Equality.IsNotEqualTo(expected)
        Assert.That<'T>(actual, neqConstraint, String.Format(message, args))

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    static member AreNotSame<'T when 'T: not struct>(expected: 'T, actual: 'T) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That<'T>(actual, sameConstraint)

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreNotSame<'T when 'T: not struct>(expected: 'T, actual: 'T, message: string) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That<'T>(actual, sameConstraint, message)

    /// <summary>
    /// Asserts that two objects do not refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreNotSame<'T when 'T: not struct>(expected: 'T, actual: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        let sameConstraint = Is.Not.SameAs expected
        Assert.That<'T>(actual, sameConstraint, String.Format(message, args))

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    static member AreSame<'T when 'T: not struct>(expected: 'T, actual: 'T) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That<'T>(actual, sameConstraint)

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member AreSame<'T when 'T: not struct>(expected: 'T, actual: 'T, message: string) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That<'T>(actual, sameConstraint, message)

    /// <summary>
    /// Asserts that two objects refer to the same object.
    /// If they are not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The actual object.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member AreSame<'T when 'T: not struct>(expected: 'T, actual: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        let sameConstraint = Is.SameAs expected
        Assert.That<'T>(actual, sameConstraint, String.Format(message, args))

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    static member Contains<'T when 'T: equality>(expected: 'T, actual: IEnumerable<'T>) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        let containsConstraint = SomeItemsConstraint(eqConstraint)
        Assert.That(actual, containsConstraint)

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Contains<'T when 'T: equality>(expected: 'T, actual: IEnumerable<'T>, message: string) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        let containsConstraint = SomeItemsConstraint(eqConstraint)
        Assert.That(actual, containsConstraint, message)

    /// <summary>
    /// Asserts that an object is contained in a list.
    /// </summary>
    /// <param name="expected">The expected object.</param>
    /// <param name="actual">The list to be examined.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Contains<'T when 'T: equality>(expected: 'T, actual: IEnumerable<'T>, message: string, [<ParamArray>] args: obj[]) : unit =
        let eqConstraint = Equality.IsEqualTo(expected)
        let containsConstraint = SomeItemsConstraint(eqConstraint)
        Assert.That(actual, containsConstraint, String.Format(message, args))

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    static member Greater<'T when 'T: comparison>(arg1: 'T, arg2: 'T) : unit =
        Assert.That<'T>(arg1, Is.GreaterThan arg2)

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Greater<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string) : unit =
        Assert.That<'T>(arg1, Is.GreaterThan arg2, message)

    /// <summary>
    /// Verifies that the first value is greater than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Greater<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg1, Is.GreaterThan arg2, String.Format(message, args))

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    static member GreaterOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T) : unit =
        Assert.That<'T>(arg1, Is.GreaterThanOrEqualTo arg2)

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member GreaterOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string) : unit =
        Assert.That<'T>(arg1, Is.GreaterThanOrEqualTo arg2, message)

    /// <summary>
    /// Verifies that the first value is greater than or equal to than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be greater.</param>
    /// <param name="arg2">The second value, expected to be less.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member GreaterOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg1, Is.GreaterThanOrEqualTo arg2, String.Format(message, args))

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    static member Less<'T when 'T: comparison>(arg1: 'T, arg2: 'T) : unit =
        Assert.That<'T>(arg1, Is.LessThan arg2)

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Less<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string) : unit =
        Assert.That<'T>(arg1, Is.LessThan arg2, message)

    /// <summary>
    /// Verifies that the first value is less than the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Less<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg1, Is.LessThan arg2, String.Format(message, args))

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    static member LessOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T) : unit =
        Assert.That<'T>(arg1, Is.LessThanOrEqualTo arg2)

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member LessOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string) : unit =
        Assert.That<'T>(arg1, Is.LessThanOrEqualTo arg2, message)

    /// <summary>
    /// Verifies that the first value is less than or equal to the second value.
    /// If it is not, then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg1">The first value, expected to be less.</param>
    /// <param name="arg2">The second value, expected to be greater.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member LessOrEqual<'T when 'T: comparison>(arg1: 'T, arg2: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg1, Is.LessThanOrEqualTo arg2, String.Format(message, args))

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    static member NotNull<'T when 'T: not struct>(arg: 'T) : unit =
        Assert.That<'T>(arg, Is.Not.Null)

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member NotNull<'T when 'T: not struct>(arg: 'T, message: string) : unit =
        Assert.That<'T>(arg, Is.Not.Null, message)

    /// <summary>
    /// Verifies that the object that is passed in is not equal to 'null'.
    /// If the object is 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member NotNull<'T when 'T: not struct>(arg: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg, Is.Not.Null, String.Format(message, args))

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    static member Null<'T when 'T: not struct>(arg: 'T) : unit =
        Assert.That<'T>(arg, Is.Null)

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    static member Null<'T when 'T: not struct>(arg: 'T, message: string) : unit =
        Assert.That<'T>(arg, Is.Null, message)

    /// <summary>
    /// Verifies that the object that is passed in is equal to 'null'.
    /// If the object is not 'null', then an NUnit.Framework.AssertException is thrown.
    /// </summary>
    /// <param name="arg">The object that is to be tested.</param>
    /// <param name="message">The message to display in case of failure.</param>
    /// <param name="args">Array of objects to be used in formatting the message.</param>
    static member Null<'T when 'T: not struct>(arg: 'T, message: string, [<ParamArray>] args: obj[]) : unit =
        Assert.That<'T>(arg, Is.Null, String.Format(message, args))
