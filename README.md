FsUnit
=======

**FsUnit** is a set of libraries that makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework.
FsUnit currently supports NUnit, MbUnit, xUnit, and MsTest (VS11 only).

The goals of FsUnit are:

* to make unit-testing feel more at home in F# , i.e., more functional.
* to leverage existing test frameworks while at the same time adapting them to the F# language in new ways.

Syntax
=======

With FsUnit, you can write unit tests like this:

One object equals or does not equal another:
```fsharp
1 |> should equal 1

1 |> should not' (equal 2)
```

One numeric object equals or does not equal another, with a specified tolerance:
```fsharp
10.1 |> should (equalWithin 0.1) 10.11

10.1 |> should not' ((equalWithin 0.001) 10.11)
```
A string does or does not start with or end with a specified substring:
```fsharp
"ships" |> should startWith "sh"

"ships" |> should not' (startWith "ss")

"ships" |> should endWith "ps"

"ships" |> should not' (endWith "ss")
```
A List, Seq, or Array instance contains or does not contain a value:
```fsharp
[1] |> should contain 1

[] |> should not' (contain 1)
```
A List or Array instance has a certain length (NUnit only):
```fsharp
anArray |> should haveLength 4
```
A Collection instance has a certain count (NUnit only):
```fsharp
aCollection |> should haveCount 4
```
A function should throw a certain type of exception:
```fsharp
(fun () -> failwith "BOOM!" |> ignore) |> should throw typeof<System.Exception>

(fun () -> failwith "BOOM!" |> ignore) |> should (throwWithMessage "BOOM!") typeof<System.Exception>
```
A number of assertions can be created using the `be` keyword:
```fsharp
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
```
Deprecated Functions
=======

Prior to version 1.1.0.0, FsUnit implemented a function named `not` that overwrote the F# operator of the same name. This is not ideal, 
so as of version 1.1.0.0 the FsUnit function has been renamed to `not'` (not + single-quote). If you need or want the previous function, it 
can be made available by opening the FsUnitDepricated module. 

Visual Studio 11 Support
=======

Visual Studio 11 support is available for all 4 of the targetted testing frameworks. FsUnit.MsTest is supported only in VS11 and no additional steps are required to use it.
FsUnit for NUnit, FsUnit.MbUnit, and FsUnit.Xunit target F# 2.0 as well as F# 3.0. Because of this, a few additional steps are required
in order to use these libraries in VS11. After installing one of these packages, add an `App.config` file to the project (if one doesn't already exist).
Build the project and then run the command "Add-BindingRedirect projectname" (where projectname is the name of your test project) in the NuGet
Package Manager Console. This command will update the `App.config` to include binding redirects from previous version of `FSharp.Core` to 
FSharp.Core version 4.3.0.0. More information about this command can be found at http://docs.nuget.org/docs/reference/package-manager-console-powershell-reference.

NuGet
=======

NuGet packages are available for each of the supported testing frameworks:

* The package with ID FsUnit supports NUnit. It is the original.
* The package with ID FsUnit.Xunit supports Xunit.NET.
* The package with ID FsUnit.MbUnit supports MbUnit.
* The packager with ID Fs30Unit.MsTest supports MsTest in VS11. 
	
Examples
=======

The following are examples of FsUnit with MbUnit, xUnit, and NUnit respectively: 

MbUnit:
```fsharp
module Test.``Project Euler - Problem 1``

open MbUnit.Framework
open FsUnit.MbUnit

let GetSumOfMultiplesOf3And5 max =  
	seq{3..max-1} |> Seq.fold(fun acc number ->  
						(if (number % 3 = 0 || number % 5 = 0) then   
							acc + number else acc)) 0 

[<Test>]
let ``When getting sum of multiples of 3 and 5 to a max number of 10 it should return a sum of 23`` () =  
	GetSumOfMultiplesOf3And5(10) |> should equal 23 
```
xUnit (Thanks to Keith Nicholas and "Julian" from hubFS for this example! http://cs.hubfs.net/forums/thread/3938.aspx):
```fsharp
module BowlingGame.``A game of bowling``

open Xunit
open FsUnit.Xunit

let (|EndOfGame|IncompleteStrike|Strike|Normal|Other|) (l, frame) =
	match l with
	| _ when frame = 11            -> EndOfGame(0)
	| [10;s]                       -> IncompleteStrike(10+s+s)
	| 10::s::n::tail               -> Strike(10+s+n, s::n::tail)
	|  f::s::n::tail when f+s = 10 -> Normal(f+s+n,  n::tail)
	|  f::s::n::tail               -> Normal(f+s,    n::tail)
	| ls                           -> Other(List.fold (+) 0 ls)

let scoreBowls bowls =
	let rec scoreBowls' frame l current_score =
		let nextframe = scoreBowls' (frame+1)
		match (l, frame) with
		| EndOfGame(score)        -> current_score + score
		| IncompleteStrike(score) -> current_score + score
		| Strike(score, l)        -> nextframe l (current_score + score)
		| Normal(score, l)        -> nextframe l (current_score + score)
		| Other(score)            -> current_score + score
	scoreBowls' 1 bowls 0

[<Fact>] 
let ``with simple scores should get the expected score.`` () =
	scoreBowls [1;2;3] |> should equal 6

[<Fact>]
let ``with a spare should get the expected score (spare).`` () =
	scoreBowls [2;8;1] |> should equal 12

[<Fact>]
let ``with a strike should get the expected score (strike).`` () =
	scoreBowls [10;1;2] |> should equal 16

[<Fact>]
let ``that is perfect should get a score of 300.``() =
	scoreBowls [for i in 1..18 -> 10] |> should equal 300

[<Fact>]
let ``with spares in the last frame should get the expected score (spare in last frame).`` () =
	scoreBowls ([for i in 1..18 -> 0] @ [2;8;1]) |> should equal 11

[<Fact>]
let ``with a strike in the last frame should get the expected score (strike in last frame).`` () =
	scoreBowls ([for i in 1..18 -> 0] @ [10;10;1]) |> should equal 21

[<Fact>] 
let ``with double strikes should add the score of the first strike to the score of the second.`` () =
	scoreBowls [10;10;1] |> should equal 33

[<Fact>]
let ``that looks like an average bowler's game should get the expected score (example game).`` () =
	scoreBowls [1;4;4;5;6;4;5;5;10;0;1;7;3;6;4;10;2;8;6] |> should equal 133
```
NUnit (Note: NUnit can also be utilized without specifying a type as in the examples for MbUnit and xUnit):
```fsharp
namespace LightBulb.Tests

open NUnit.Framework
open FsUnit

type LightBulb(state) =
	member x.On = state
	override x.ToString() =
		match x.On with
		| true  -> "On"
		| false -> "Off"

[<TestFixture>] 
type ``Given a LightBulb that has had its state set to true`` ()=
	let lightBulb = new LightBulb(true)

	[<Test>] member x.
	 ``when I ask whether it is On it answers true.`` ()=
			lightBulb.On |> should be True

	[<Test>] member x.
	 ``when I convert it to a string it becomes "On".`` ()=
			string lightBulb |> should equal "On"

[<TestFixture>]
type ``Given a LightBulb that has had its state set to false`` ()=
	let lightBulb = new LightBulb(false)

	[<Test>] member x.
	 ``when I ask whether it is On it answers false.`` ()=
			lightBulb.On |> should be False

	[<Test>] member x.
	 ``when I convert it to a string it becomes "Off".`` ()=
			string lightBulb |> should equal "Off"
```
Getting Involved
=======

GitHub makes collaboration very easy. To get involved with FsUnit, simply follow the directions provided by GitHub to
fork this repository, then implement lots of cool stuff, and finally send a pull request.

A few things to keep in mind:

* Going forward, FsUnit will aim to support as much functionality as possible across all supported testing frameworks.

* Development environments need to be setup to run tests for MbUnit, xUnit.NET and NUnit. A product like ReSharper can make this easier.

* Since the unit tests for FsUnit are written with FsUnit, failing tests are just as important as passing tests.  

Release Notes
=======

* 1.2.1.0 - Includes new features for generic assertions and containment check. Currently, this feature is only supported for the NUnit implementation. Thanks to jack-pappas for the contributions. 
* 1.1.0.0 - Pulls in the latest versions for xUnit.NET and NUnit. Replaces the "not" keyword with "not'" and adds the FsUnitDepricated module for backward compatibility. Adds MsTest support for VS11 only.
* 1.0.1.3 - Includes new assertions for NUnit such as NaN, instanceOfType, and unique.
* 1.0.0.4 - Added added support for xUnit.NET and MbUnit and a new assertion.
* 0.9.1.1 - Added several new assertions.
* 0.9.0.0 - Ray Vernagus built this version and several before it with NUnit as the targeted testing framework.

Maintainer(s)
============

- [@dmohl](https://github.com/dmohl)

The default maintainer account for projects under "fsprojects" is [@fsgit](https://github.com/fsgit) - F# Community Project Incubation Space (repo management)
