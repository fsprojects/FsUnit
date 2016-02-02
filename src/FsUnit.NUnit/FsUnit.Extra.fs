namespace FsUnit

open System
open NUnit.Framework.Constraints

type ChoiceConstraint(n) =
  inherit Constraint() with
    override __.Description with get () = sprintf "is choice %d" n

    override this.ApplyTo(actual : 'TActual) : ConstraintResult =
        match box actual with // Forced to box to match C# constraint on 'TActual
        | null -> raise (new ArgumentException("The actual value must be a non-null choice"))
        | o    -> let actualType = actual.GetType()
                  let isSuccess = (new CustomMatchers.ChoiceDiscriminator(n)).check(o)
                  ConstraintResult(this, actualType, isSuccess)

[<AutoOpen>]
module TopLevelOperatorsExtra =
    let choice n = ChoiceConstraint(n)