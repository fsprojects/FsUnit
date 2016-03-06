(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsUnit.NUnit/"
#r "NUnit.Framework.dll"
#r "FsUnit.NUnit.dll"

(**
What is FsUnit.Typed?
===============

**FsUnit.Typed** is a strongly typed subset of FsUnit operators that makes
unit-testing with `FsUnit` even more safe and enjoyable (Available only for `NUnit 3`).

FsUnit.Typed from NuGet
-----------------------

The `FsUnit.Typed` is part of `FsUnit` package for NUnit and can be [installed from NuGet](https://nuget.org/packages/FsUnit).

FsUnit.Typed with Paket
-----------------------

`FsUnit.Typed` supports lightweight usage scenario with [Paket](http://fsprojects.github.io/Paket/).

In the case when you do not want to add dependency on [FsUnit](https://www.nuget.org/packages/FsUnit/)
package to your project, you can add reference to [FsUnit.Typed.fs](https://github.com/fsprojects/FsUnit/blob/master/src/FsUnit.NUnit/FsUnit.Typed.fs)
file and [NUnit](https://www.nuget.org/packages/NUnit/) package.

Example of `paket.dependencies` file:

    [lang=paket]
    source https://nuget.org/api/v2

    nuget FSharp.Core
    github fsprojects/FsUnit src/FsUnit.NUnit/FsUnit.Typed.fs

    group Test
        source https://nuget.org/api/v2
        nuget NUnit.Console
        nuget NUnit

Example of `paket.reference` file for test projects:

    [lang=paket]
    File:FsUnit.Typed.fs
    group Test
        NUnit

Syntax
-------

With FsUnit.Typed, you can write unit tests like this:
*)

open NUnit.Framework
open FsUnit.Typed

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
