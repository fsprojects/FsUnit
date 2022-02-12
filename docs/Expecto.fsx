(*** hide ***)
#r "nuget: Expecto"

(**
Expecto
========================

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The Expecto library can be <a href="https://nuget.org/packages/Expecto">installed from NuGet</a>:
      <pre>PM> Install-Package Expecto</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>
*)

(**
**Expecto.Flip** has a similar syntax to `FsUnit`.

`Expecto` is **not** part of FsUnit.

Syntax
-------

With `Expecto.Flip` you can write your unit tests like this:

*)

open Expecto.Flip.Expect

(**
One object equals or does not equal another:
*)

1 |> equal "1 is equal to 1." 1
1 |> notEqual  "1 is not equal to 2." 2

(**
One comparable value greater or smaller than another:
*)

(11, 10) |> isGreaterThan "11 is greater than 10."
(10, 11) |> isLessThan "10 is less than 11."

(**
& more operators:
*)

true |> isTrue "Value is true."
false |> isFalse "Value is false."

"" |> isEmpty
"Foobar" |> isNotEmpty "Value is not empty."
None |> isNone "Value is None."

{1 .. 10} |> contains "Seq 1 to 10 contains 4." 4
