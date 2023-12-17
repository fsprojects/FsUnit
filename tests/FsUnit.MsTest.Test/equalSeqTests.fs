namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type ``equalSeqTests``() =

    [<TestMethod>]
    member _.``sequence should equal sequence``() =
        Seq.init 3 ((+) 1) |> should equalSeq (Seq.init 3 ((+) 1))

    [<TestMethod>]
    member _.``sequence should not equal sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq(Seq.init 3 ((-) 3)))

    [<TestMethod>]
    member _.``filled sequence should not equal empty sequence``() =
        Seq.init 3 ((+) 1) |> should not' (equalSeq Seq.empty)

    [<TestMethod>]
    member _.``empty sequence should equal empty sequence``() =
        Seq.empty |> should equalSeq Seq.empty

    [<TestMethod>]
    member _.``sequence should not equal another sequence``() =
        Seq.init 4 ((+) 1) |> should not' (equalSeq(Seq.init 5 ((+) 1)))
