(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsUnit.NUnit/netstandard2.0/"
#r "NUnit.Framework.dll"
#r "FsUnit.NUnit.dll"

(**
What is FsUnitTyped?
===============

**FsUnitTyped** is a statically typed set of FsUnit operators that makes
unit-testing with `FsUnit` even more safe and enjoyable (Available only for `NUnit`).

No more untyped constrains and tests like

    1 |> should equal "1"

FsUnitTyped from NuGet
-----------------------

The `FsUnit.Typed` is part of `FsUnit` package for NUnit and can be [installed from NuGet](https://nuget.org/packages/FsUnit).

Syntax
-------

With FsUnitTyped, you can write unit tests like this:
*)

open NUnit.Framework
open FsUnitTyped

(**
One object equals or does not equal another:
*)

1 |> shouldEqual 1
1 |> shouldNotEqual 2

(**
One comparable value greater or smaller than another:
*)

11 |> shouldBeGreaterThan 10
10 |> shouldBeSmallerThan 11


(**
A string contains specified substring:
*)
"ships" |> shouldContainText "hip"

(**
A List, Seq, or Array instance contains, does not contain a value or empty:
*)
[1] |> shouldContain 1
[] |> shouldNotContain 1
[] |> shouldBeEmpty

(**
A List or Array instance has a certain length:
*)
[|1;2;3;4|] |> shouldHaveLength 4

(**
A function should throw a certain type of exception:
*)
(fun _ -> failwith "BOOM!") |> shouldFail<System.Exception>

(**
A function should fail
*)
shouldFail (fun _ -> 5/0 |> ignore)
