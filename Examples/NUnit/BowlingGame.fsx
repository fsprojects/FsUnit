(*
Thanks to Keith Nicholas and "Julian" from hubFS for this example!
  http://cs.hubfs.net/forums/thread/3938.aspx
*)
#r "FsUnit.NUnit.dll"
#r "nunit.framework.dll"
open NUnit.Framework
open FsUnit

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

[<TestFixture>]
type ``A game of bowling`` ()=
    [<Test>] member x.
     ``with simple scores should get the expected score.`` ()=
            scoreBowls [1;2;3] |> should equal 6
    
    [<Test>] member x.
     ``with a spare should get the expected score (spare).`` ()=
            scoreBowls [2;8;1] |> should equal 12
    
    [<Test>] member x.
     ``with a strike should get the expected score (strike).`` ()=
            scoreBowls [10;1;2] |> should equal 16
    
    [<Test>] member x.
     ``that is perfect should get a score of 300.`` ()=
            scoreBowls [for i in 1..18 -> 10] |> should equal 300
    
    [<Test>] member x.
     ``with spares in the last frame should get the expected score (spare in last frame).`` ()=
            scoreBowls ([for i in 1..18 -> 0] @ [2;8;1]) |> should equal 11
    
    [<Test>] member x.
     ``with a strike in the last frame should get the expected score (strike in last frame).`` ()=
            scoreBowls ([for i in 1..18 -> 0] @ [10;10;1]) |> should equal 21
        
    [<Test>] member x.
     ``with double strikes should add the score of the first strike to the score of the second.`` ()=
            scoreBowls [10;10;1] |> should equal 33
    
    [<Test>] member x.
     ``that looks like an average bowler's game should get the expected score (example game).`` ()=
            scoreBowls [1;4;4;5;6;4;5;5;10;0;1;7;3;6;4;10;2;8;6] |> should equal 133
