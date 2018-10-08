(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsUnit.MbUnit/"
#r "FsUnit.MbUnit.dll"
#r "MbUnit.dll"
#r "NHamcrest.dll"

(**
FsUnit for MbUnit
========================

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The FsUnit library for MbUnit can be <a href="https://nuget.org/packages/FsUnit.MbUnit">installed from NuGet</a>:
      <pre>PM> Install-Package FsUnit.MbUnit</pre>
      Sample FsUnit tests for MbUnit can be <a href="https://nuget.org/packages/FsUnit.MbUnit.Sample">installed from NuGet</a>:
      <pre>PM> Install-Package FsUnit.MbUnit.Sample</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

Euler - Problem 1
-----------------
*)
module ``Project Euler - Problem 1`` =
    open MbUnit.Framework
    open FsUnit.MbUnit

    let GetSumOfMultiplesOf3And5 max =
        seq{3..max-1} |> Seq.fold(fun acc number ->
                            (if (number % 3 = 0 || number % 5 = 0) then
                                acc + number else acc)) 0

    [<Test>]
    let ``When getting sum of multiples of 3 and 5 to a max number of 10 it should return a sum of 23`` () =
        GetSumOfMultiplesOf3And5(10) |> should equal 23

(**
LightBulb
---------
*)
module ``LightBulb Tests`` =
    open MbUnit.Framework
    open FsUnit.MbUnit

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


(**
BowlingGame
---------
Thanks to `Keith Nicholas` and `Julian` from hubFS for this example!
*)
module ``BowlingGame A game of bowling`` =
    open MbUnit.Framework
    open FsUnit.MbUnit

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

    [<Test>]
    let ``with simple scores should get the expected score.`` () =
        scoreBowls [1;2;3] |> should equal 6

    [<Test>]
    let ``with a spare should get the expected score (spare).`` () =
        scoreBowls [2;8;1] |> should equal 12

    [<Test>]
    let ``with a strike should get the expected score (strike).`` () =
        scoreBowls [10;1;2] |> should equal 16

    [<Test>]
    let ``that is perfect should get a score of 300.``() =
        scoreBowls [for i in 1..18 -> 10] |> should equal 300

    [<Test>]
    let ``with spares in the last frame should get the expected score (spare in last frame).`` () =
        scoreBowls ([for i in 1..18 -> 0] @ [2;8;1]) |> should equal 11

    [<Test>]
    let ``with a strike in the last frame should get the expected score (strike in last frame).`` () =
        scoreBowls ([for i in 1..18 -> 0] @ [10;10;1]) |> should equal 21

    [<Test>]
    let ``with double strikes should add the score of the first strike to the score of the second.`` () =
        scoreBowls [10;10;1] |> should equal 33

    [<Test>]
    let ``that looks like an average bowler's game should get the expected score (example game).`` () =
        scoreBowls [1;4;4;5;6;4;5;5;10;0;1;7;3;6;4;10;2;8;6] |> should equal 133
