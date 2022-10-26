namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``equalSeq Tests``() =

    [<Fact>]
    member _.``sequence should equal equal sequence``() =
        Seq.init 3 ((+) 1) |> should equalSeq (Seq.init 3 ((+) 1))

    [<Fact>]
    member _.``filled sequence should not equal empty sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq Seq.empty)

    [<Fact>]
    member _.``sequence should not equal another sequence``() =
        Seq.init 4 ((+) 1) |> should not' (equalSeq(Seq.init 5 ((+) 1)))
