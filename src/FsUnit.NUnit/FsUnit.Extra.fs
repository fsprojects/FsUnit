namespace FsUnit

open System
open NUnit.Framework.Constraints

type ChoiceConstraint(n) =
  inherit Constraint() with
    override this.WriteDescriptionTo(writer: MessageWriter): unit =
      writer.WritePredicate("is choice")
      writer.WriteExpectedValue(sprintf "%d" n)
    override this.Matches(actual: obj) =
      match actual with
        | null -> raise (new ArgumentException("The actual value must be a non-null choice"))
        | o -> (new CustomMatchers.ChoiceDiscriminator(n)).check(o)

[<AutoOpen>]
module TopLevelOperatorsExtra =
    let choice n = ChoiceConstraint(n)