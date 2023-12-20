namespace FsUnit

module CustomConstraints =

    open NUnit.Framework.Constraints

    type OfSameCaseConstraint(expected: Quotations.Expr) =
        inherit Constraint()

        member this.Expected = expected

        override this.Description =
            defaultArg (Common.caseName this.Expected) "<The method only works on union types!>"

        override this.ApplyTo<'TActual>(actual: 'TActual) : ConstraintResult =
            if Common.isUnionCase actual then
                let result = Common.isOfCase this.Expected actual
                ConstraintResult(this, actual, result)
            else
                failwith $"Value (not expression) is not a union case. Got a {actual.GetType().Name}."
