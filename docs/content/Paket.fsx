(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"

(**
Lightweight FsUnit with Paket
========================

FsUnit supports lightweight usage scenario with [Paket](http://fsprojects.github.io/Paket/) and NUnit.

In the case when you do not want to add dependency on [FsUnit](https://www.nuget.org/packages/FsUnit/)
package to your project, you can add reference to [FsUnit.fs](https://github.com/fsprojects/FsUnit/blob/master/src/FsUnit.NUnit/FsUnit.fs)
file and [NUnit](https://www.nuget.org/packages/NUnit/) package.

Example of `paket.dependencies` file:

    [lang=paket]
    source https://nuget.org/api/v2

    nuget FSharp.Core
    github fsprojects/FsUnit src/FsUnit.NUnit/FsUnit.fs

    group Test
        source https://nuget.org/api/v2
        nuget NUnit.Console
        nuget NUnit

Notice that this scenario works only with `NUnit`. File `src/FsUnit.NUnit/FsUnit.fs` contains dependency-free
subset of `FsUnit` operators. In order to write tests you need to add reference to `NUnit` package and
reference to `NUnit.Runners` to be able to run tests from build script.

Example of `paket.reference` file for test projects:

    [lang=paket]
    File:FsUnit.fs
    group Test
        NUnit

*)