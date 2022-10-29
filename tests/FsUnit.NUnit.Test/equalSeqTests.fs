namespace FsUnit.Test

open System
open NUnit.Framework
open FsUnit

type ``equalSeq Tests``() =

    [<Test>]
    member _.``sequence should equal sequence``() =
        Seq.init 3 ((+) 1) |> should equalSeq (Seq.init 3 ((+) 1))

    [<Test>]
    member _.``sequence should not equal sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq(Seq.init 3 ((-) 3)))

    [<Test>]
    member _.``filled sequence should not equal empty sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq Seq.empty)

    [<Test>]
    member _.``empty sequence should equal empty sequence``() =
        Seq.empty |> should equalSeq Seq.empty

    [<Test>]
    member _.``sequence should not equal another sequence``() =
        Seq.init 4 ((+) 1) |> should not' (equalSeq(Seq.init 5 ((+) 1)))
