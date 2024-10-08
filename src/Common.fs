namespace FsUnit

module Common =

    open Microsoft.FSharp.Quotations.Patterns
    open Microsoft.FSharp.Reflection

    let isUnionCase x =
        FSharpType.IsUnion(<@ x @>.Type) |> not && isNull(box x)
        || FSharpType.IsUnion(x.GetType())

    /// <summary>
    /// Takes an expression and returns the name of the union cases that are the result of this expression.
    /// Note, not all ways an expression may result in an union case are covered in this function.
    /// </summary>
    let rec caseName =
        function
        | Lambda(_, expr)
        | Let(_, _, expr) -> caseName expr
        | NewUnionCase(case, _) -> Some case.Name
        | NewTuple expressions ->
            expressions
            |> List.choose caseName
            |> (fun x -> System.String.Join(", ", x))
            |> Some
        | _ -> None

    /// <summary>
    /// Checks whether the given value is of the same case of a union type as the
    /// case defined by the given expression.
    /// </summary>
    /// <exception cref="System.Exception">If the expression is not an union case or does not result in an union case.</exception>
    /// <exception cref="System.Exception">If argument to check is not an union case or does not result in an union case.</exception>
    /// <remarks>Note, not all ways an expression may result in an union case are covered in this function.</remarks>
    let rec isOfCase =
        function
        | Lambda(_, expr)
        | Let(_, _, expr) -> isOfCase expr
        | NewUnionCase(case, _) ->
            // Returns a function that check whether the tag of the argument matches
            // the tag of the union given in the expression.
            let readTag = FSharpValue.PreComputeUnionTagReader case.DeclaringType

            let comparator = (=) case.Tag

            (fun x ->
                if isUnionCase x then
                    x :> obj |> (readTag >> comparator)
                else
                    failwith "Value (not expression) is not a union case.")
        | NewTuple expressions ->
            // a tuple may contain several union cases so we can simply
            // map this functions over all expressions
            let mappedExpressions = expressions |> List.map isOfCase
            (fun x -> mappedExpressions |> List.exists(fun expression -> x |> expression))
        | _ -> failwith "Expression (not value) is not a union case."
