namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FsUnit.Xunit")>]
[<assembly: AssemblyProductAttribute("FsUnit")>]
[<assembly: AssemblyDescriptionAttribute("FsUnit is a set of libraries that makes unit-testing with F# more enjoyable.")>]
[<assembly: AssemblyVersionAttribute("2.3.1")>]
[<assembly: AssemblyFileVersionAttribute("2.3.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "2.3.1"
    let [<Literal>] InformationalVersion = "2.3.1"
