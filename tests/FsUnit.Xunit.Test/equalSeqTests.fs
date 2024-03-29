﻿namespace FsUnit.Test

open Xunit
open FsUnit.Xunit

type ``equalSeq tests``() =

    [<Fact>]
    member _.``sequence should equal sequence``() =
        Seq.init 3 ((+) 1) |> should equalSeq (Seq.init 3 ((+) 1))

    [<Fact>]
    member _.``sequence should not equal sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq(Seq.init 3 ((-) 3)))

    [<Fact>]
    member _.``filled sequence should not equal empty sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq Seq.empty)

    [<Fact>]
    member _.``empty sequence should equal empty sequence``() =
        Seq.empty |> should equalSeq Seq.empty

    [<Fact>]
    member _.``sequence should not equal another sequence``() =
        Seq.init 4 ((+) 1) |> should not' (equalSeq(Seq.init 5 ((+) 1)))
