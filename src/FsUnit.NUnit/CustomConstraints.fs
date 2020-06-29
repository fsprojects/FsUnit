namespace FsUnit

module CustomConstraints =

    open NUnit.Framework.Constraints
    open Microsoft.FSharp.Reflection

    type OfSameCaseConstraint (expected: Quotations.Expr) =
        inherit Constraint()

        member this.Expected = expected

        override this.ApplyTo<'TActual> (actual: 'TActual) : ConstraintResult =
            do this.Description <- defaultArg (Common.caseName this.Expected) "<The method only works on union types!>"
            if FSharpType.IsUnion(actual.GetType()) then
                let result = Common.isOfCase this.Expected actual
                ConstraintResult(this, actual, result)
            else
                let actualType = actual.GetType()
                do printfn "Got a %s" actualType.Name
                failwith "Value (not expression) is not a union case."



