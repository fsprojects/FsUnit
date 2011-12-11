FsUnit
=======

**FsUnit** is a set of libraries that makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework.
Project. FsUnit currently supports NUnit, MbUnit, and xUnit.

The goals of FsUnit are:

* to make unit-testing feel more at home in F# , i.e., more functional.
* to leverage existing test frameworks while at the same time adapting them to the F# language in new ways.

**Syntax**

With FsUnit, you can write unit tests like this:

One object equals or does not equal another:

    1 |> should equal 1

    1 |> should not (equal 2)

A List, Seq, or Array instance contains or does not contain a value:

    [1] |> should contain 1

    [] |> should not (contain 1)

A List or Array instance has a certain length (NUnit only):

    anArray |> should haveLength 4

A Collection instance has a certain count (NUnit only):

    aCollection |> should haveCount 4

A function should throw a certain type of exception:

    (fun () -> failwith "BOOM!" |> ignore) |> should throw typeof<System.Exception>

A number of assertions can be created using the `be` keyword:

    true |> should be True

    false |> should not (be True)

    [] |> should be Empty

    [1] |> should not (be Empty)

    "" |> should be EmptyString

    "" |> should be NullOrEmptyString

    null |> should be NullOrEmptyString

    null |> should be Null

    anObj |> should not (be Null)

    anObj |> should be (sameAs anObj)

    anObj |> should not (be sameAs otherObj)

**Examples**

The following are examples of FsUnit with NUnit. 

    module Test.``Project Euler - Problem 1``
	
	open NUnit.Framework
    open FsUnit

    let GetSumOfMultiplesOf3And5 max =  
        seq{3..max-1} |> Seq.fold(fun acc number ->  
                            (if (number % 3 = 0 || number % 5 = 0) then   
                                acc + number else acc)) 0 

    [<Test>]
    let ``When getting sum of multiples of 3 and 5 to a max number of 10 it should return a sum of 23`` () =  
        GetSumOfMultiplesOf3And5(10) |> should equal 23 

Here is a simple example of a class and some associated tests (taken from FsUnit's examples):

    namespace LightBulb.Tests
	
    open NUnit.Framework
    open FsUnit

    type LightBulb(state) =
        member x.On = state
        override x.ToString() =
            match x.On with
            | true  -> "On"
        |     false -> "Off"

    [<TestFixture>] 
    type ``Given a LightBulb that has had its state set to true`` ()=
        let lightBulb = new LightBulb(true)

        [<Test>] member test.
         ``when I ask whether it is On it answers true.`` ()=
                lightBulb.On |> should be True

        [<Test>] member test.
         ``when I convert it to a string it becomes "On".`` ()=
                string lightBulb |> should equal "On"

This next example shows how to use FsUnit with xUnit (Thanks to Keith Nicholas and "Julian" from hubFS for this example!
  http://cs.hubfs.net/forums/thread/3938.aspx):

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
