#r "./SourceCode/packages/FAKE.1.58.10/tools/FakeLib.dll"

open Fake 
open System.IO

// properties
let currentDate = System.DateTime.UtcNow
let projectName = "FsUnit"
let coreSummary = "FsUnit makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework."
let projectSummary = "FsUnit makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework."
let projectDescription = "FsUnit makes unit-testing with F# more enjoyable. It adds a special syntax to your favorite .NET testing framework."
let authors = ["Ray Vernagus"; "Daniel Mohl" ]
let mail = "dmohl@yahoo.com"
let homepage = "http://fsunit.codeplex.com/"

// directories
let buildNUnitDir = @".\build\FsUnit.NUnit\"
let buildMbUnitDir = @".\build\FsUnit.MbUnit\"
let buildXunitDir = @".\build\FsUnit.xUnit\"
let packagesDir = @".\packages\"
let testNUnitDir = @".\SourceCode\FsUnit.NUnit.Test\bin\Release\"
let testMbUnitDir = @".\SourceCode\FsUnit.MbUnit.Test\bin\Release\"
let testXunitDir = @".\SourceCode\FsUnit.xUnit.Test\bin\Release\"
let deployDir = @".\deploy\"
let nugetNUnitLibDir = @".\NuGet\FsUnit.NUnit\Lib\"
let nugetMbUnitLibDir = @".\NuGet\FsUnit.MbUnit\Lib\"
let nugetXunitLibDir = @".\NuGet\FsUnit.Xunit\Lib\"
let targetPlatformDir = getTargetPlatformDir "4.0.30319"

let appNUnitReferences  = !! @".\SourceCode\FsUnit.NUnit\*.*proj" 
let appMbUnitReferences  = !! @".\SourceCode\FsUnit.MbUnit\*.*proj"
let appXunitReferences  = !! @".\SourceCode\FsUnit.xUnit\*.*proj" 
let nunitTestReferences = !! @".\SourceCode\FsUnit.NUnit.Test\*.*proj"
let mbUnitTestReferences = !! @".\SourceCode\FsUnit.MbUnit.Test\*.*proj"
let xunitTestReferences = !! @".\SourceCode\FsUnit.xUnit.Test\*.*proj"
let testNUnitAssemblies = !! (testNUnitDir + @"\*.Test.dll")
let testMbUnitAssemblies = !! (testMbUnitDir + @"\*.Test.dll")
let testxUnitAssemblies = !! (testXunitDir + @"\*.Test.dll") 
let nunitPath = @".\SourceCode\packages\NUnit.2.5.10.11092\tools"
let nunitOutput = testNUnitDir + @"TestResults.xml"
let mbUnitPath = @".\SourceCode\packages\mbunit.3.3.454.0\tools\bin\gallio.echo.exe"
let xunitPath = @".\SourceCode\packages\xunit.1.8.0.1549\tools\xunit.console.clr4.x86"
 
// Targets
Target? Clean <-
  fun _ ->
    CleanDir buildNUnitDir
    CleanDir buildMbUnitDir
    CleanDir buildXunitDir
    CleanDir testNUnitDir
    CleanDir testMbUnitDir
    CleanDir testXunitDir
 
Target? BuildApp <-
  fun _ ->    
    let buildIt framework =
        let target = getBuildParamOrDefault framework "All"
        let frameworkVersion = getBuildParamOrDefault "frameworkVersion" framework
        let getVersionConstant = 
            let v = ("[^\\d]" >=> "") (frameworkVersion)
            "NET" + v.Substring(0,2)
        let frameworkParams = 
            ["TargetFrameworkVersion", frameworkVersion; "DefineConstants", getVersionConstant]

        let buildDirectory dir = 
            sprintf @"%s%s\" dir getVersionConstant
        
        [(buildDirectory(buildNUnitDir), appNUnitReferences); (buildDirectory(buildMbUnitDir), appMbUnitReferences);
         (buildDirectory(buildXunitDir), appXunitReferences)]
        |> Seq.iter (fun (bDir, appRefs) -> MSBuild bDir "Rebuild" (["Configuration","Release"] @ frameworkParams) appRefs
                                            |> Log "AppBuild-Output: " )
        
        [(buildDirectory(buildNUnitDir), "FsUnit.NUnit.dll", nugetNUnitLibDir);
         (buildDirectory(buildMbUnitDir), "FsUnit.MbUnit.dll", nugetMbUnitLibDir);
         (buildDirectory(buildMbUnitDir), "FsUnit.MbUnit.xml", nugetMbUnitLibDir);
         (buildDirectory(buildXunitDir), "FsUnit.Xunit.dll", nugetXunitLibDir);
         (buildDirectory(buildXunitDir), "FsUnit.Xunit.xml", nugetXunitLibDir)]
        |> Seq.iter (fun (bDir, filename, nuDir) ->  
            XCopy (bDir + filename) (nuDir + getVersionConstant + @"\" + filename))

    ["v4.0"; "v2.0"] |> Seq.iter(fun v -> buildIt v)
 
Target? BuildTest <-
  fun _ ->
    [(testNUnitDir, nunitTestReferences);
     (testMbUnitDir, mbUnitTestReferences);
     (testXunitDir, xunitTestReferences)]
    |> Seq.iter (fun (testdir, testRefs) -> 
                    MSBuildDebug testdir "Build" testRefs
                    |> Log "TestBuild-Output: " )  
  
Target? Test <-
   fun _ ->
     testNUnitAssemblies |> NUnit (fun p -> {p with ToolPath = nunitPath; DisableShadowCopy = true; OutputFile = nunitOutput})
     testxUnitAssemblies |> xUnit (fun p -> {p with ToolPath = xunitPath})
     testMbUnitAssemblies |> xUnit (fun p -> {p with ToolPath = mbUnitPath})

Target? Default <-
  fun _ -> trace ""
 
// Dependencies
For? BuildApp <- Dependency? Clean
For? BuildTest <- Dependency? Clean
For? Test <-
    Dependency? BuildApp
      |> And? BuildTest
For? Default <- Dependency? Test   
 
// start build
Run? Default