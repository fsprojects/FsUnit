namespace FsUnit

open System
open System.Collections
open Microsoft.FSharp.Core
open LanguagePrimitives
open NUnit.Framework
open NUnit.Framework.Constraints

type Equality<'T when 'T: equality> =
    static member Reference =
        System.Func<'T, 'T, bool>(fun x y ->
            let f =
                FastGenericEqualityComparer<'T>.Equals(x, y)

            printfn "Ref returns %b" f
            f)

    static member Structural =
        System.Func<'T, 'T, bool>(fun x y ->
            let f =
                StructuralComparisons.StructuralEqualityComparer.Equals(x, y)

            printfn "Struct returns %b" f
            f)

    static member StructuralC =
        Comparison<'T>(fun x y ->
            let f =
                StructuralComparisons.StructuralComparer.Compare(x, y)

            printfn "Struct returns %d" f
            f)

    static member inline IsEqualTo(x: 'T) =
        match (box x) with
        | :? IStructuralComparable -> Is.EqualTo(x).Or.EqualTo(x).Using<'T>(Equality.StructuralC)
        | :? IStructuralEquatable -> Is.EqualTo(x).Or.EqualTo(x).Using<'T>(Equality.Structural)
        | _ -> Is.EqualTo(x)

    static member IsNotEqualTo(x: 'T) = NotConstraint(Equality.IsEqualTo(x))
