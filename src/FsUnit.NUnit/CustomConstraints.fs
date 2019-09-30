namespace FsUnit

module CustomConstraints =

    open NUnit.Framework.Constraints
    open Microsoft.FSharp.Quotations.Patterns
    open Microsoft.FSharp.Reflection

    type OfSameCaseConstraint (expected: FSharp.Quotations.Expr) =
        inherit Constraint()

        let rec caseName = function
            | Lambda (_, expr) | Let (_, _, expr) -> caseName expr
            | NewUnionCase (case, _) ->
                Some case.Name
            | NewTuple expressions ->
                expressions 
                |> List.map caseName |> List.choose id
                |> (fun x -> System.String.Join(", ", x))
                |> Some
            | _ -> None 

        let rec isOfCase = function
            | Lambda (_, expr) | Let (_, _, expr) -> isOfCase expr
            | NewUnionCase (case, _) ->
                // Returns a function that check wether the tag of the argument matches 
                // the tag of the union given in the expression.
                let readTag = FSharpValue.PreComputeUnionTagReader case.DeclaringType
                let comparator = (=) case.Tag
                (fun x -> 
                    if FSharpType.IsUnion(x.GetType()) then
                        x :> obj |> (readTag >> comparator)
                    else
                        failwith "Value (not expression) is not a union case.")
            | NewTuple expressions ->
                // a tuple may contain several union cases so we can simply 
                // map this functions over all expressions
                let mappedExpressions = expressions |> List.map isOfCase
                (fun x -> mappedExpressions |> List.exists (fun expression -> x |> expression))
            | _ -> failwith "Expression (not value) is not a union case." 

        member this.Expected = expected

        override this.ApplyTo<'TActual> (actual: 'TActual) : ConstraintResult =
            do this.Description <- defaultArg (caseName this.Expected) "<The method only works on union types!>" 
            if FSharpType.IsUnion(actual.GetType()) then
                let result = isOfCase this.Expected actual
                ConstraintResult(this, actual, result)
            else
                let actualType = actual.GetType()
                do printfn "Got a %s" actualType.Name
                failwith "Value (not expression) is not a union case."
        


