#load "../.paket/load/netstandard2.0/docs/FSharp.Literate.fsx"
#load "../.paket/load/netstandard2.0/docs/Giraffe.fsx"

#if !FAKE
#r "netstandard"
#endif

// HACK: force usage of Fsharp.Compiler.Services
// or the indirect reference from FSharp.Literate will fail to load
let dummy (pos: FSharp.Compiler.Range.pos) = pos.Column
FSharp.Compiler.Range.mkPos 1 1 |> dummy

open System
open FSharp.Literate
open Giraffe.GiraffeViewEngine

let (</>) x y = IO.Path.Combine(x, y)

module Path =
    let root = __SOURCE_DIRECTORY__
    let content = root </> "content"
    let output = root </> "output"
    let files = root </> "files"

    let dir p = IO.Path.GetDirectoryName(p: string)
    let filename p = IO.Path.GetFileName(p: string)
    let changeExt ext p = IO.Path.ChangeExtension(p, ext)

module Directory =
    let ensure dir =
        if not (IO.Directory.Exists dir) then IO.Directory.CreateDirectory dir |> ignore

    let copyRecursive (path: string) dest =
        let path =
            if not (path.EndsWith(string IO.Path.DirectorySeparatorChar)) then
                path + string IO.Path.DirectorySeparatorChar
            else path

        let trim (p: string) =
            if p.StartsWith(path) then p.Substring(path.Length)
            else failwithf "Cannot find path root"

        IO.Directory.EnumerateFiles(path, "*", IO.SearchOption.AllDirectories)
        |> Seq.iter (fun p ->
            let target = dest </> trim p
            ensure (Path.dir target)
            IO.File.Copy(p, target, true))




type Template =
    { Name: string
      Description: string
      Body: string
      Author: string
      GitHub: string
      NuGet: string
      Root: string
      Tooltips: string }

let properties =
    { Name = "FsUnit"
      Description = "FsUnit is a set of libraries that makes unit-testing with F# more enjoyable."
      Author = "Ray Vernagus and Daniel Mohl"
      GitHub = "http://github.com/fsprojects/FsUnit"
      NuGet = "https://www.nuget.org/packages?q=FsUnit"
      Body = ""
      Root = "."
      Tooltips = "" }

let template t =
    html [ _lang "en" ] [ 
        head [] [
            meta [ _charset "utf-8" ]
            title [] [ str t.Name ]
            meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
            meta [ _name "description"; _content t.Description ]
            meta [ _name "author"; _content t.Author ]

            script [ _src "https://code.jquery.com/jquery-1.8.0.js" ] []
            script [ _src "https://code.jquery.com/ui/1.8.23/jquery-ui.js" ] []
            script [ _src "https://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.1/js/bootstrap.min.js" ] []
            link [ _href "https://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.1/css/bootstrap-combined.min.css"; _rel "stylesheet" ]

            link [ _type "text/css"; _rel "stylesheet"; _href "content/style.css" ]
            script [ _type "text/javascript"; _src "content/tips.js" ] [] 
        ]
        body [] [ 
            div [ _class "container" ] [ 
                div [ _class "masthead" ] [ 
                    ul [ _class "nav nav-pills pull-right" ] [ 
                        li [] [ a [ _href "https://fscheck.github.io/FsCheck/" ] [ str "FsCheck" ] ]
                        li [] [ a [ _href "https://github.com/fsprojects/Foq" ] [ str "Foq" ] ]
                        li [] [ a [ _href "https://fsharp.org" ] [ str "fsharp.org" ] ]
                        li [] [ a [ _href t.GitHub ] [ str "github page" ] ] 
                    ]
                    h3 [ _class "muted" ] [ 
                        a [ _href "/index.html" ] [ str t.Name ] 
                    ] 
                ]
                hr []
                div [ _class "row" ] [ 
                    div [ _class "span9"; _id "main" ] [ 
                        rawText t.Body 
                    ]
                    div [ _class "span3" ] [ 
                        img [ _src "img/logo.png"; _style "width:150px;margin:10px"; _alt "Project Logo"]
                        ul [ _class "nav nav-list"; _id "menu"; _style "margin-top: 20px;" ] [ 
                            li [ _class "nav-header" ] [ str t.Name ]
                            li [] [ a [ _href "index.html" ] [ str "Home page" ] ]
                            li [ _class "divider" ] []
                            li [] [ a [ _href t.NuGet ] [ str "Get Library via NuGet" ] ]
                            li [] [ a [ _href t.GitHub ] [ str "Source Code on GitHub" ] ]
                            li [] [ a [ _href "license.html" ] [ str "License" ] ]
                            li [] [ a [ _href "release-notes.html" ] [ str "Release Notes" ] ]

                            li [ _class "nav-header" ] [ str "Getting started" ]
                            li [] [ a [ _href "NUnit.html" ] [ str "NUnit Classic" ] ]
                            li []
                              [ a [ _href "Paket.html" ] [ str "Lightweight FsUnit with Paket" ] ]
                            li [] [ a [ _href "FsUnitTyped.html" ] [ str "FsUnitTyped" ] ]
                            li [ _class "divider" ] []

                            li [] [ a [ _href "xUnit.html" ] [ str "xUnit" ] ]
                            li [] [ a [ _href "MsTest.html" ] [ str "MsTest" ] ]

                            li [ _class "nav-header" ] [ str "Documentation" ]
                            li [] [ a [ _href "operators.html" ] [ str "Operators" ] ]  
                        ] 
                    ] 
                ] 
            ]
            a [ _href t.GitHub ] [
                img [ _style "position: absolute; top: 0; right: 0; border: 0;"
                      _src "https://s3.amazonaws.com/github/ribbons/forkme_right_gray_6d6d6d.png"
                      _alt "Fork me on GitHub" ] 
            ]
            rawText t.Tooltips 
        ] 
    ]

let write path html =
    let content = renderHtmlDocument html
    IO.File.WriteAllText(path, content)

let docPackagePath path = __SOURCE_DIRECTORY__ + @"/../packages/docs/" + path
let includeDir path = "-I:" + docPackagePath path
let reference path = "-r:" + docPackagePath path

let evaluationOptions =
    [| includeDir "FSharp.Core/lib/netstandard2.0/"
       includeDir "FSharp.Literate/lib/netstandard2.0/"
       includeDir "FSharp.Compiler.Service/lib/netstandard2.0/"
       reference "FSharp.Compiler.Service/lib/netstandard2.0/FSharp.Compiler.Service.dll" |]

let compilerOptions =
    String.concat " "
        ("-r:System.Runtime"
         :: "-r:System.Net.WebClient"
         :: "-r:System.Runtime.Extensions"
         :: Array.toList evaluationOptions)

let parseFsx path =

    let doc =
        Literate.ParseScriptFile
            (path = path, compilerOptions = compilerOptions,
             fsiEvaluator = FSharp.Literate.FsiEvaluator(evaluationOptions))

    let body = FSharp.Literate.Literate.FormatLiterateNodes(doc, OutputKind.Html, "", true, true)
    for err in doc.Errors do
        Printf.printfn "%A" err
    body, body.FormattedTips


let parseMd path =
    let doc =
        Literate.ParseMarkdownFile
            (path, compilerOptions = compilerOptions, fsiEvaluator = FSharp.Literate.FsiEvaluator(evaluationOptions))
    let body = FSharp.Literate.Literate.FormatLiterateNodes(doc, OutputKind.Html, "", true, true)
    for err in doc.Errors do
        Printf.printfn "%A" err
    body, body.FormattedTips

let format (doc: LiterateDocument) = Formatting.format doc.MarkdownDocument true OutputKind.Html

let processFile outdir path =
    printfn "Processing help: %s" path
    let outfile =
        let name =
            path
            |> Path.filename
            |> Path.changeExt ".html"
        outdir </> name

    let parse =
        match IO.Path.GetExtension(path) with
        | ".fsx" -> parseFsx
        | ".md" -> parseMd
        | ext -> failwithf "Unable to process doc for %s files" ext

    let body, tips = parse path

    let t =
        { properties with
              Body = format body
              Tooltips = tips }
    t
    |> template
    |> write outfile


let fileName = System.Environment.GetEnvironmentVariable("CHANGED_FILE")

if System.IO.File.Exists fileName
then
    printfn "!!! %s" fileName
    if fileName.StartsWith(Path.files) then printfn "\tcopy" // TODO:
    elif fileName.StartsWith(Path.content) then processFile Path.output fileName
    else printfn "\tignore"

else
    Directory.copyRecursive Path.files Path.output
    IO.Directory.EnumerateFiles Path.content |> Seq.iter (processFile Path.output)
