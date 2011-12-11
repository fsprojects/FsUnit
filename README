FsUnit
=======

**FsUnit** is a set of libraries that makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework.
Project. FsUnit currently supports NUnit, MbUnit, and xUnit.

The goals of FsUnit are:

* to make unit-testing feel more at home in F# , i.e., more functional.
* to leverage existing test frameworks while at the same time adapting them to the F# language in new ways.

**Syntax**

With FsUnit, you can write unit tests like this:

One object equals or does not equal another:

    1 |> should equal 1

    1 |> should not (equal 2)

A List, Seq, or Array instance contains or does not contain a value:

    [1] |> should contain 1

    [] |> should not (contain 1)

A List or Array instance has a certain length (NUnit only):

    anArray |> should haveLength 4

A Collection instance has a certain count (NUnit only):

    aCollection |> should haveCount 4

A function should throw a certain type of exception:

    (fun () -> failwith "BOOM!" |> ignore) |> should throw typeof<System.Exception>

A number of assertions can be created using the `be` keyword:

    true |> should be True

    false |> should not (be True)

    [] |> should be Empty

    [1] |> should not (be Empty)

    "" |> should be EmptyString

    "" |> should be NullOrEmptyString

    null |> should be NullOrEmptyString

    null |> should be Null

    anObj |> should not (be Null)

    anObj |> should be (sameAs anObj)

    anObj |> should not (be sameAs otherObj)

**Examples**

The following are examples of FsUnit with NUnit. 

    open NUnit.Framework
    open FsUnit

    let GetSumOfMultiplesOf3And5 max =  
        seq{3..max-1} |> Seq.fold(fun acc number ->  
                            (if (number % 3 = 0 || number % 5 = 0) then   
                                acc + number else acc)) 0 

    [<Test>]
    let ``When getting sum of multiples of 3 and 5 to a max number of 10 it should return a sum of 23`` () =  
        GetSumOfMultiplesOf3And5(10) |> should equal 23 

Here is a simple example of a class and some associated tests (taken from FsUnit's examples):

    open NUnit.Framework
    open FsUnit

    type LightBulb(state) =
        member x.On = state
        override x.ToString() =
            match x.On with
            | true  -> "On"
        |     false -> "Off"

    [<TestFixture>] 
    type ``Given a LightBulb that has had its state set to true`` ()=
        let lightBulb = new LightBulb(true)

        [<Test>] member test.
         ``when I ask whether it is On it answers true.`` ()=
                lightBulb.On |> should be True

        [<Test>] member test.
         ``when I convert it to a string it becomes "On".`` ()=
                string lightBulb |> should equal "On"

