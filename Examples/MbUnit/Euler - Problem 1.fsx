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
