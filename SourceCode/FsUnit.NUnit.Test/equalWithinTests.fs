namespace FsUnit.Test

open NUnit.Framework
open FsUnit

(* Thanks to erdoll for this suggestion: http://fsunit.codeplex.com/discussions/269320 *)

[<TestFixture>]
type ``equalWithin tests``() =
    [<Test>] member test.
      ``should equal within tolerance``() =
          10.1 |> should (equalWithin 0.1) 10.11

    [<Test>] member test.
      ``should not equal within tolerance``() =
          10.1 |> should not ((equalWithin 0.001) 10.11)

    [<Test>] member test.
      ``should fail outside tolerance``() =
          shouldFail (fun () ->  10.1 |> should (equalWithin 0.01) 10.4)