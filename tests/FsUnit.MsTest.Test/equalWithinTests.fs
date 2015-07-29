namespace FsUnit.Test

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

(* Thanks to erdoll for this suggestion: http://fsunit.codeplex.com/discussions/269320 *)

[<TestClass>]
type ``equalWithin tests``() =
    [<TestMethod>] member test.
      ``should equal within tolerance``() =
          10.1 |> should (equalWithin 0.1) 10.11

    [<TestMethod>] member test.
      ``should equal within tolerance with different types``() =
          10 |> should (equalWithin 0.1) 10

    [<TestMethod>] member test.
      ``should equal within tolerance with same types``() =
          10 |> should (equalWithin 1) 11

    [<TestMethod>] member test.
      ``should equal within tolerance when exactly equal``() =
          10.11 |> should (equalWithin 0.1) 10.11

    [<TestMethod>] member test.
      ``should equal within tolerance when less than``() =
          10.09 |> should (equalWithin 0.1) 10.11

    [<TestMethod>] member test.
      ``should not equal within tolerance``() =
          10.1 |> should not' ((equalWithin 0.001) 10.11)
