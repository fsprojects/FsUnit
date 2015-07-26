(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsUnit.NUnit/"
#r "NUnit.Framework.dll"
#r "FsUnit.NUnit.dll"

(**
What is FsUnit?
===============

**FsUnit** is a set of libraries that makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework.
FsUnit currently supports NUnit, xUnit, MbUnit, and MsTest (VS11 only).

The goals of FsUnit are:

* to make unit-testing feel more at home in F# , i.e., more functional.
* to leverage existing test frameworks while at the same time adapting them to the F# language in new ways.

NuGet packages are available for each of the supported testing frameworks:

* [![NuGet Status](http://img.shields.io/nuget/v/FsUnit.svg?style=flat) - NUnit](https://www.nuget.org/packages/FsUnit/)
* [![NuGet Status](http://img.shields.io/nuget/v/FsUnit.Xunit.svg?style=flat) - xUnit](https://www.nuget.org/packages/FsUnit.Xunit/)
* [![NuGet Status](http://img.shields.io/nuget/v/FsUnit.MbUnit.svg?style=flat) - MbUnit](https://www.nuget.org/packages/FsUnit.MbUnit/)
* [![NuGet Status](http://img.shields.io/nuget/v/Fs30Unit.MsTest.svg?style=flat) - MsTest](https://www.nuget.org/packages/Fs30Unit.MsTest/)


Syntax
-------

With FsUnit, you can write unit tests like this:
*)

open NUnit.Framework
open FsUnit

(**
One object equals or does not equal another:
*)

1 |> should equal 1
1 |> should not' (equal 2)

(**
One numeric object equals or does not equal another, with a specified tolerance:
*)
10.1 |> should (equalWithin 0.1) 10.11
10.1 |> should not' ((equalWithin 0.001) 10.11)

(**
A string does or does not start with or end with a specified substring:
*)
"ships" |> should startWith "sh"
"ships" |> should not' (startWith "ss")
"ships" |> should endWith "ps"
"ships" |> should not' (endWith "ss")

(**
A List, Seq, or Array instance contains or does not contain a value:
*)
[1] |> should contain 1
[] |> should not' (contain 1)

(**
A List or Array instance has a certain length (`NUnit` only):
*)
anArray |> should haveLength 4

(**
A Collection instance has a certain count (`NUnit` only):
*)
aCollection |> should haveCount 4

(**
A function should throw a certain type of exception:
*)
(fun () -> failwith "BOOM!" |> ignore) |> should throw typeof<System.Exception>
(fun () -> failwith "BOOM!" |> ignore) |> should (throwWithMessage "BOOM!") typeof<System.Exception>

(**
A number of assertions can be created using the `be` keyword:
*)

true |> should be True
false |> should not' (be True)

"" |> should be EmptyString
"" |> should be NullOrEmptyString

null |> should be NullOrEmptyString
null |> should be Null

anObj |> should not' (be Null)
anObj |> should be (sameAs anObj)
anObj |> should not' (be sameAs otherObj)

11 |> should be (greaterThan 10)
9 |> should not' (be greaterThan 10)
11 |> should be (greaterThanOrEqualTo 10)
9 |> should not' (be greaterThanOrEqualTo 10)
10 |> should be (lessThan 11)
10 |> should not' (be lessThan 9)
10.0 |> should be (lessThanOrEqualTo 10.1)
10 |> should not' (be lessThanOrEqualTo 9)

0.0 |> should be ofExactType<float>
1 |> should not' (be ofExactType<obj>)

Choice<int, string>.Choice1Of2(42) |> should be (choice 1)

[] |> should be Empty // NUnit only
[1] |> should not' (be Empty) // NUnit only

"test" |> should be instanceOfType<string> // Currently, NUnit only and requires version 1.0.1.0+
"test" |> should not' (be instanceOfType<int>) // Currently, NUnit only and requires version 1.0.1.0+

2.0 |> should not' (be NaN) // Currently, NUnit only and requires version 1.0.1.0+

[1;2;3] |> should be unique // Currently, NUnit only and requires version 1.0.1.0+

[1;2;3] |> should be ascending
[1;3;2] |> should not' (be ascending)
[3;2;1] |> should be descending
[3;1;2] |> should not' (be descending)

(**

Deprecated Functions
--------------------

Prior to version 1.1.0.0, FsUnit implemented a function named `not` that overwrote the F# operator of the same name. This is not ideal, 
so as of version 1.1.0.0 the FsUnit function has been renamed to `not'` (not + single-quote). If you need or want the previous function, it 
can be made available by opening the FsUnitDepricated module. 

Visual Studio 11 Support
------------------------

Visual Studio 11 support is available for all 4 of the targetted testing frameworks. FsUnit.MsTest is supported only in VS11 and no additional steps are required to use it.
FsUnit for NUnit, FsUnit.MbUnit, and FsUnit.Xunit target F# 2.0 as well as F# 3.0. Because of this, a few additional steps are required
in order to use these libraries in VS11. After installing one of these packages, add an `App.config` file to the project (if one doesn't already exist).
Build the project and then run the command "Add-BindingRedirect projectname" (where projectname is the name of your test project) in the NuGet
Package Manager Console. This command will update the `App.config` to include binding redirects from previous version of `FSharp.Core` to 
FSharp.Core version 4.3.0.0. More information about this command can be found at http://docs.nuget.org/docs/reference/package-manager-console-powershell-reference.

 
Contributing
------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding a new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read the [library design notes][readme] to understand how it works.

  [content]: https://github.com/fsprojects/FsUnit/tree/master/docs/content
  [gh]: https://github.com/fsprojects/FsUnit
  [issues]: https://github.com/fsprojects/FsUnit/issues
  [readme]: https://github.com/fsprojects/FsUnit/blob/master/README.md
*)
