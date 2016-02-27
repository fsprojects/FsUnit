namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FsUnit.NUnit")>]
[<assembly: AssemblyProductAttribute("FsUnit")>]
[<assembly: AssemblyDescriptionAttribute("FsUnit is a set of libraries that makes unit-testing with F# more enjoyable.")>]
[<assembly: AssemblyVersionAttribute("2.0.0")>]
[<assembly: AssemblyFileVersionAttribute("2.0.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "2.0.0"
