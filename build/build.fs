module Build

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet
open Fake.Tools.Git
open System.IO

let execContext = Context.FakeExecutionContext.Create false "build.fs" []
Context.setExecutionContext (Context.RuntimeContext.Fake execContext)

// --------------------------------------------------------------------------------------
// Project-specific details below
// --------------------------------------------------------------------------------------

// Information about the project are used
//  - for version and project name in generated AssemblyInfo file
//  - by the generated NuGet package
//  - to run tests and to publish documentation on GitHub gh-pages
//  - for documentation, you also need to edit info in "docs/tools/generate.fsx"

// The name of the project
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "FsUnit"

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "FsUnit is a set of libraries that makes unit-testing with F# more enjoyable."

// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitOwner = "fsprojects"
let gitHome = "https://github.com/" + gitOwner

// The name of the project on GitHub
let gitName = "FsUnit"

// The url for the raw files hosted
//let gitRaw = environVarOrDefault "gitRaw" "https://raw.github.com/fsprojects"
let gitRaw = "https://raw.github.com/fsprojects"
let cloneUrl = "git@github.com:fsprojects/FsUnit.git"

// --------------------------------------------------------------------------------------
// END TODO: The rest of the file includes standard build steps
// --------------------------------------------------------------------------------------

// Read additional information from the release notes document
let release = ReleaseNotes.load "RELEASE_NOTES.md"
let version = release.AssemblyVersion

// Helper active pattern for project types
let (|Fsproj|Csproj|Vbproj|) (projFileName: string) =
    match projFileName with
    | f when f.EndsWith("fsproj") -> Fsproj
    | f when f.EndsWith("csproj") -> Csproj
    | f when f.EndsWith("vbproj") -> Vbproj
    | _ -> failwith $"Project file %s{projFileName} not supported. Unknown project type."

// Generate assembly info files with the right version & up-to-date information
Target.create "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ AssemblyInfo.Title(projectName)
          AssemblyInfo.Product project
          AssemblyInfo.Description summary
          AssemblyInfo.Version version
          AssemblyInfo.FileVersion version ]

    let getProjectDetails (projectPath: string) =
        let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
        (projectPath, projectName, Path.GetDirectoryName(projectPath), (getAssemblyInfoAttributes projectName))

    !! "src/**/*.??proj"
    |> Seq.filter (fun x -> not <| x.Contains(".netstandard"))
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, _, folderName, attributes) ->
        match projFileName with
        | Fsproj -> AssemblyInfoFile.createFSharp (folderName @@ "AssemblyInfo.fs") attributes
        | Csproj -> AssemblyInfoFile.createCSharp ((folderName @@ "Properties") @@ "AssemblyInfo.cs") attributes
        | Vbproj -> AssemblyInfoFile.createVisualBasic ((folderName @@ "My Project") @@ "AssemblyInfo.vb") attributes))


// --------------------------------------------------------------------------------------
// Clean build results

Target.create "Clean" (fun _ ->
    Shell.cleanDirs
        [ "bin"
          "temp"
          "src/FsUnit.NUnit/bin/"
          "src/FsUnit.NUnit/obj/"
          "src/FsUnit.Xunit/bin/"
          "src/FsUnit.Xunit/obj/"
          "src/FsUnit.MsTestUnit/bin/"
          "src/FsUnit.MsTestUnit/obj/" ])

Target.create "CleanDocs" (fun _ -> Shell.cleanDirs [ "docs/output" ])

// --------------------------------------------------------------------------------------
// Check code format & format code using Fantomas

let sourceFiles =
    !! "src/**/*.fs"
    ++ "tests/**/*.fs"
    -- "./**/*Assembly*.fs"
    -- "tests/**/obj/**/*.fs"

Target.create "CheckFormat" (fun _ ->
    let result =
        sourceFiles
        |> Seq.map (sprintf "\"%s\"")
        |> String.concat " "
        |> sprintf "%s --check"
        |> DotNet.exec id "fantomas"

    if result.ExitCode = 0 then
        Trace.log "No files need formatting"
    elif result.ExitCode = 99 then
        failwith "Some files need formatting, check output for more info"
    else
        Trace.logf $"Errors while formatting: %A{result.Errors}")

Target.create "Format" (fun _ ->
    let result =
        sourceFiles
        |> Seq.map (sprintf "\"%s\"")
        |> String.concat " "
        |> DotNet.exec id "fantomas"

    if not result.OK then
        printfn $"Errors while formatting all files: %A{result.Messages}")

// --------------------------------------------------------------------------------------
// Build library & test project

Target.create "Build" (fun _ ->
    let result = DotNet.exec id "build" "FsUnit.slnx -c Release"

    if not result.OK then 
        failwithf "Build failed: %A" result.Errors)

// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

Target.create "NUnit" (fun _ ->
    let result = DotNet.exec id "test" "tests/FsUnit.NUnit.Test/"

    if not result.OK then
        failwithf $"NUnit test failed: %A{result.Errors}")

Target.create "xUnit" (fun _ -> 
    let result = DotNet.exec id "test" "tests/FsUnit.Xunit.Test/"

    if not result.OK then
        failwithf $"xUnit test failed: %A{result.Errors}")

Target.create "MsTest" (fun _ -> 
    let result = DotNet.exec id "test" "tests/FsUnit.MsTest.Test/"

    if not result.OK then
        failwithf $"MsTest test failed: %A{result.Errors}")

Target.create "RunTests" ignore

// --------------------------------------------------------------------------------------
// Build NuGet packages with the .NET SDK

Target.create "NuGet" (fun _ ->
    // MSBuild splits -p: values on ',' and ';'; environment variables are read as properties verbatim.
    Environment.setEnvironVar "PackageReleaseNotes" (String.toLines release.Notes)

    let pack projectPath extraProperties =
        let result =
            DotNet.exec id "pack" $"%s{projectPath} -c Release -o bin -p:Version=%s{version} %s{extraProperties}"

        if not result.OK then
            failwithf "Package build failed for %s: %A" projectPath result.Errors
    [ "src/FsUnit.NUnit/FsUnit.NUnit.fsproj"
      "src/FsUnit.Xunit/FsUnit.Xunit.fsproj"
      "src/FsUnit.MsTestUnit/FsUnit.MsTest.fsproj" ]
    |> List.iter (fun projectPath -> pack projectPath ""))



// --------------------------------------------------------------------------------------
// Generate the documentation

Target.create "GenerateDocs" (fun _ ->
    Shell.cleanDir ".fsdocs"

    DotNet.exec id "fsdocs" "build --clean --parameters root https://fsprojects.github.io/FsUnit"
    |> ignore)
// --------------------------------------------------------------------------------------
// Release Scripts

Target.create "ReleaseDocs" (fun _ ->
    let tempDocsDir = "tmp/gh-pages"
    Shell.cleanDir tempDocsDir
    Repository.cloneSingleBranch "" cloneUrl "gh-pages" tempDocsDir

    Repository.fullclean tempDocsDir
    Shell.copyRecursive "output" tempDocsDir true |> Trace.tracefn "%A"
    Staging.stageAll tempDocsDir
    Commit.exec tempDocsDir (sprintf "Update generated documentation for version %s" version)
    Branches.push tempDocsDir)

// --------------------------------------------------------------------------------------
// Run all targets by default. Invoke 'build <Target>' to override

Target.create "All" ignore
Target.create "Release" ignore

"Clean"
  ==> "AssemblyInfo"
  ==> "CheckFormat"
  ==> "Build"
  ==> "RunTests"
  ==> "All"

"Build"
  ==> "NUnit"
  ==> "xUnit"
  ==> "MsTest"
  ==> "RunTests"


"All"
  ==> "NuGet"
  ==> "GenerateDocs"
  ==> "ReleaseDocs"
  ==> "Release"

[<EntryPoint>]
let main args =
    match args with
    | [| target |] -> Target.runOrDefault target
    | _ -> Target.runOrDefault "All"
    0
