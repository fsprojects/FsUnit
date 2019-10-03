#r @"paket:
source https://nuget.org/api/v2
framework netstandard2.0
nuget Fake.Core.Target
nuget Fake.Core.ReleaseNotes 
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.DotNet.MSBuild
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.DotNet.Paket
nuget Fake.DotNet.FSFormatting 
nuget Fake.Tools.Git
nuget Fake.Api.GitHub //"

#if !FAKE
#load "./.fake/build.fsx/intellisense.fsx"
#r "netstandard" // Temp fix for https://github.com/fsharp/FAKE/issues/1985
#endif

open Fake 
open Fake.Core.TargetOperators
open Fake.Core 
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet
open Fake.Tools
open Fake.Tools.Git
open System
open System.IO

Target.initEnvironment()

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

// File system information
let solutionFile  = "FsUnit.sln"

// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitOwner = "fsprojects"
let gitHome = "https://github.com/" + gitOwner

// The name of the project on GitHub
let gitName = "FsUnit"

// The url for the raw files hosted
//let gitRaw = environVarOrDefault "gitRaw" "https://raw.github.com/fsprojects"
let gitRaw = "https://raw.github.com/fsprojects"

// --------------------------------------------------------------------------------------
// END TODO: The rest of the file includes standard build steps
// --------------------------------------------------------------------------------------

// Read additional information from the release notes document
let release = ReleaseNotes.load "RELEASE_NOTES.md"

// Helper active pattern for project types
let (|Fsproj|Csproj|Vbproj|) (projFileName:string) =
    match projFileName with
    | f when f.EndsWith("fsproj") -> Fsproj
    | f when f.EndsWith("csproj") -> Csproj
    | f when f.EndsWith("vbproj") -> Vbproj
    | _                           -> failwith (sprintf "Project file %s not supported. Unknown project type." projFileName)

// Generate assembly info files with the right version & up-to-date information
Target.create "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ AssemblyInfo.Title (projectName)
          AssemblyInfo.Product project
          AssemblyInfo.Description summary
          AssemblyInfo.Version release.AssemblyVersion
          AssemblyInfo.FileVersion release.AssemblyVersion ]

    let getProjectDetails (projectPath:string) =
        let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
        ( projectPath,
          projectName,
          Path.GetDirectoryName(projectPath),
          (getAssemblyInfoAttributes projectName)
        )

    !! "src/**/*.??proj"
    |> Seq.filter (fun x -> not <| x.Contains(".netstandard"))
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, projectName, folderName, attributes) ->
        match projFileName with
        | Fsproj -> AssemblyInfoFile.createFSharp (folderName @@ "AssemblyInfo.fs") attributes
        | Csproj -> AssemblyInfoFile.createCSharp ((folderName @@ "Properties") @@ "AssemblyInfo.cs") attributes
        | Vbproj -> AssemblyInfoFile.createVisualBasic ((folderName @@ "My Project") @@ "AssemblyInfo.vb") attributes
        )
)

// Copies binaries from default VS location to expected bin folder
// But keeps a subdirectory structure for each project in the
// src folder to support multiple project outputs
Target.create "CopyBinaries" (fun _ ->
    !! "src/**/*.??proj"
    |>  Seq.map (fun f -> ((Path.GetDirectoryName f) @@ "bin/Release", "bin" @@ (Path.GetFileNameWithoutExtension f)))
    |>  Seq.iter (fun (fromDir, toDir) -> Shell.copyDir toDir fromDir (fun _ -> true))
)

// --------------------------------------------------------------------------------------
// Clean build results

Target.create "Clean" (fun _ ->
    Shell.cleanDirs 
        [
        "bin"; "temp"; 
        "src/FsUnit.NUnit/bin/";
        "src/FsUnit.NUnit/obj/";
        "src/FsUnit.Xunit/bin/";
        "src/FsUnit.Xunit/obj/";
        "src/FsUnit.MsTestUnit/bin/"
        "src/FsUnit.MsTestUnit/obj/"
        ]
)

Target.create "CleanDocs" (fun _ ->
    Shell.cleanDirs ["docs/output"]
)

// --------------------------------------------------------------------------------------
// Build library & test project

Target.create "Build" (fun _ ->
    //DotNetCli.Build    (fun c -> { c with WorkingDir = rootFolder })
    DotNet.exec id "build" "FsUnit.sln -c Release" |> ignore
)

// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

Target.create "NUnit" (fun _ ->
    //DotNetCli.Test (fun c -> {c with WorkingDir = "tests/FsUnit.NUnit.Test/"})
    DotNet.test id "tests/FsUnit.NUnit.Test/"
)

Target.create "xUnit" (fun _ ->
    //DotNetCli.Test (fun c -> {c with WorkingDir = "tests/FsUnit.Xunit.Test/"})
    DotNet.test id "tests/FsUnit.Xunit.Test/"
)

Target.create "MsTest" (fun _ ->
    //DotNetCli.Test (fun c -> {c with WorkingDir = "tests/FsUnit.MsTest.Test/"})
    DotNet.test id "tests/FsUnit.MsTest.Test/"
)

Target.create "RunTests" ignore

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target.create "NuGet" (fun _ ->
    // Paket.pack(fun p ->
    //     { p with
    //         OutputPath = "bin"
    //         Version = release.NugetVersion
    //         ReleaseNotes = String.toLines release.Notes})
    DotNet.exec id "paket" 
        (sprintf "pack bin --version %s --release-notes \"%s\"" 
            release.NugetVersion  (String.toLines release.Notes) )
    |> ignore
)

Target.create "PublishNuget" (fun _ ->
    Paket.push(fun p ->
        { p with
            WorkingDir = "bin" })
)


// --------------------------------------------------------------------------------------
// Generate the documentation

// Target.create "GenerateReferenceDocs" (fun _ ->
//     if not <| executeFSIWithArgs "docs/tools" "generate.fsx" ["--define:RELEASE"; "--define:REFERENCE"] [] then
//       failwith "generating reference documentation failed"
// )

// let generateHelp' fail debug =
//     let args =
//         if debug then ["--define:HELP"]
//         else ["--define:RELEASE"; "--define:HELP"]
//     if executeFSIWithArgs "docs/tools" "generate.fsx" args [] then
//         traceImportant "Help generated"
//     else
//         if fail then
//             failwith "generating help documentation failed"
//         else
//             traceImportant "generating help documentation failed"

// let generateHelp fail =
//     generateHelp' fail false

// Target.create "GenerateHelp" (fun _ ->
//     DeleteFile "docs/content/release-notes.md"
//     CopyFile "docs/content/" "RELEASE_NOTES.md"
//     Rename "docs/content/release-notes.md" "docs/content/RELEASE_NOTES.md"

//     DeleteFile "docs/content/license.md"
//     CopyFile "docs/content/" "license.txt"
//     Rename "docs/content/license.md" "docs/content/license.txt"

//     generateHelp true
// )

// Target.create "GenerateHelpDebug" (fun _ ->
//     DeleteFile "docs/content/release-notes.md"
//     CopyFile "docs/content/" "RELEASE_NOTES.md"
//     Rename "docs/content/release-notes.md" "docs/content/RELEASE_NOTES.md"

//     DeleteFile "docs/content/license.md"
//     CopyFile "docs/content/" "license.txt"
//     Rename "docs/content/license.md" "docs/content/license.txt"

//     generateHelp' true true
// )

// Target.create "KeepRunning" (fun _ ->
//     use watcher = !! "docs/content/**/*.*" |> WatchChanges (fun changes ->
//          generateHelp false
//     )

//     traceImportant "Waiting for help edits. Press any key to stop."

//     System.Console.ReadKey() |> ignore

//     watcher.Dispose()
// )

Target.create "GenerateDocs" ignore

// let createIndexFsx lang =
//     let content = """(*** hide ***)
// // This block of code is omitted in the generated HTML documentation. Use
// // it to define helpers that you do not want to show in the documentation.
// #I "../../../bin"

// (**
// F# Project Scaffold ({0})
// =========================
// *)
// """
//     let targetDir = "docs/content" @@ lang
//     let targetFile = targetDir @@ "index.fsx"
//     ensureDirectory targetDir
//     System.IO.File.WriteAllText(targetFile, System.String.Format(content, lang))

// Target.create "AddLangDocs" (fun _ ->
//     let args = System.Environment.GetCommandLineArgs()
//     if args.Length < 4 then
//         failwith "Language not specified."

//     args.[3..]
//     |> Seq.iter (fun lang ->
//         if lang.Length <> 2 && lang.Length <> 3 then
//             failwithf "Language must be 2 or 3 characters (ex. 'de', 'fr', 'ja', 'gsw', etc.): %s" lang

//         let templateFileName = "template.cshtml"
//         let templateDir = "docs/tools/templates"
//         let langTemplateDir = templateDir @@ lang
//         let langTemplateFileName = langTemplateDir @@ templateFileName

//         if System.IO.File.Exists(langTemplateFileName) then
//             failwithf "Documents for specified language '%s' have already been added." lang

//         ensureDirectory langTemplateDir
//         Copy langTemplateDir [ templateDir @@ templateFileName ]

//         createIndexFsx lang)
// )

// --------------------------------------------------------------------------------------
// Release Scripts

// Target.create "ReleaseDocs" (fun _ ->
//     let tempDocsDir = "temp/gh-pages"
//     CleanDir tempDocsDir
//     Repository.cloneSingleBranch "" (gitHome + "/" + gitName + ".git") "gh-pages" tempDocsDir

//     CopyRecursive "docs/output" tempDocsDir true |> tracefn "%A"
//     StageAll tempDocsDir
//     Git.Commit.Commit tempDocsDir (sprintf "Update generated documentation for version %s" release.NugetVersion)
//     Branches.push tempDocsDir
// )

// Target.create "Release" (fun _ ->
//     StageAll ""
//     Git.Commit.Commit "" (sprintf "Bump version to %s" release.NugetVersion)
//     Branches.push ""

//     Branches.tag "" release.NugetVersion
//     Branches.pushTag "" "origin" release.NugetVersion

//     // release on github
//     createClient (getBuildParamOrDefault "github-user" "") (getBuildParamOrDefault "github-pw" "")
//     |> createDraft gitOwner gitName release.NugetVersion (release.SemVer.PreRelease <> None) release.Notes
//     // TODO: |> uploadFile "PATH_TO_FILE"
//     |> releaseDraft
//     |> Async.RunSynchronously
// )

Target.create "BuildPackage" ignore

// --------------------------------------------------------------------------------------
// Run all targets by default. Invoke 'build <Target>' to override

Target.create "All" ignore

"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "CopyBinaries"
  ==> "RunTests"
  ==> "All"
  //==> "GenerateReferenceDocs"
  //==> "GenerateDocs"
  //=?> ("ReleaseDocs",isLocalBuild)

"Build" 
  ==> "NUnit"
  ==> "xUnit"
  ==> "MsTest" 
  ==> "RunTests"

"All"
  ==> "NuGet"
  ==> "BuildPackage"
  //==> "PublishNuget"
  //==> "Release"

// "CleanDocs"
//   ==> "GenerateHelp"
//   ==> "GenerateReferenceDocs"
//   ==> "GenerateDocs"

// "CleanDocs"
//   ==> "GenerateHelpDebug"

// "GenerateHelp"
//   ==> "KeepRunning"

// "ReleaseDocs"
//   ==> "Release"

Target.runOrDefault "BuildPackage"
