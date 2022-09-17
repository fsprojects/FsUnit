namespace FsUnit

open System
open System.Collections
open Microsoft.FSharp.Core
open LanguagePrimitives
open NUnit.Framework
open NUnit.Framework.Constraints

type Equality<'T when 'T: equality> =

    static member Reference =
        Func<'T, 'T, bool>(fun x y -> FastGenericEqualityComparer<'T>.Equals (x, y))

    static member Structural =
        Func<'T, 'T, bool>(fun x y -> StructuralComparisons.StructuralEqualityComparer.Equals(x, y))

    static member StructuralC =
        Comparison<'T>(fun x y -> StructuralComparisons.StructuralComparer.Compare(x, y))

    static member inline IsEqualTo(x: 'T) =
        match (box x) with
        | :? IStructuralEquatable -> Is.EqualTo(x).Or.EqualTo(x).Using<'T>(Equality.Structural)
        | :? IStructuralComparable -> Is.EqualTo(x).Or.EqualTo(x).Using<'T>(Equality.StructuralC)
        | _ -> Is.EqualTo(x)

    static member IsNotEqualTo(x: 'T) =
        NotConstraint(Equality.IsEqualTo(x))
