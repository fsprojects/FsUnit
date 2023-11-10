namespace global

open FsUnit
open NUnit.Framework

[<SetUpFixture>]
type InitMsgUtils() =
    inherit FSharpCustomMessageFormatter()
