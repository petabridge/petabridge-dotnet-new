#I @"tools/FAKE/tools"
#r "FakeLib.dll"

open System
open System.IO
open System.Text

open Fake
open Fake.DotNetCli
open Fake.DocFxHelper

// Information about the project for Nuget and Assembly info files
let product = "Petabridge.Library"
let authors = [ "Petabridge" ]
let copyright = "Copyright Petabridge, LLC © 2015-2017"
let company = "Petabridge, LLC"
let description = "dotnet new templates for professional OSS projects"
let tags = ["template"; "dotnet new"; "Petabridge"; "DocFx"; "build"; "NBench"; "Akka";]
let configuration = "Release"

// Read release notes and version
let buildNumber = environVarOrDefault "BUILD_NUMBER" "0"
let preReleaseVersionSuffix = (if (not (buildNumber = "0")) then (buildNumber) else "") + "-beta"
let versionSuffix = 
    match (getBuildParam "nugetprerelease") with
    | "dev" -> preReleaseVersionSuffix
    | _ -> ""

let releaseNotes =
    File.ReadLines "./RELEASE_NOTES.md"
    |> ReleaseNotesHelper.parseReleaseNotes

// Directories
let toolsDir = __SOURCE_DIRECTORY__ @@ "tools"
let output = __SOURCE_DIRECTORY__  @@ "bin"
let outputTests = __SOURCE_DIRECTORY__ @@ "TestResults"
let outputPerfTests = __SOURCE_DIRECTORY__ @@ "PerfResults"
let outputNuGet = output @@ "nuget"

// Copied from original NugetCreate target
let nugetDir = output @@ "nuget"
let workingDir = output @@ "build"
let nugetExe = FullName @"./tools/nuget.exe"

Target "Clean" (fun _ ->
    CleanDir output
    CleanDir outputTests
    CleanDir outputPerfTests
    CleanDir outputNuGet
    CleanDir workingDir
    CleanDir "docs/_site"
    CleanDirs !! "./**/bin"
    CleanDirs !! "./**/obj"
)

//--------------------------------------------------------------------------------
// Nuget targets 
//--------------------------------------------------------------------------------

let overrideVersionSuffix (project:string) =
    match project with
    | _ -> versionSuffix // add additional matches to publish different versions for different projects in solution
Target "CreateNuget" (fun _ -> 
    ensureDirectory outputNuGet   
    let nuspecFiles = !! "src/**/*.nuspec" 

    for nuspec in nuspecFiles do
        printfn "Creating nuget packages for %s" nuspec
        CleanDir workingDir
        
        let project = Path.GetFileNameWithoutExtension nuspec 
        let projectDir = Path.GetDirectoryName nuspec
        let releaseVersion = releaseNotes.NugetVersion

        let pack outputDir =
            NuGetHelper.NuGet
                (fun p ->
                    { p with
                        Description = description
                        Authors = authors
                        Copyright = copyright
                        Project =  project
                        Properties = ["Configuration", "Release"]
                        ReleaseNotes = releaseNotes.Notes |> String.concat "\n"
                        Version = releaseVersion
                        Tags = tags |> String.concat " "
                        OutputPath = outputDir
                        WorkingDir = workingDir})
                nuspec

        CopyDir workingDir projectDir allFiles

        pack outputNuGet 
)

Target "PublishNuget" (fun _ ->
    let projects = !! "./bin/nuget/*.nupkg" -- "./bin/nuget/*.symbols.nupkg"
    let apiKey = getBuildParamOrDefault "nugetkey" ""
    let source = getBuildParamOrDefault "nugetpublishurl" ""
    let symbolSource = getBuildParamOrDefault "symbolspublishurl" ""
    let shouldPublishSymbolsPackages = not (symbolSource = "")

    if (not (source = "") && not (apiKey = "") && shouldPublishSymbolsPackages) then
        let runSingleProject project =
            DotNetCli.RunCommand
                (fun p -> 
                    { p with 
                        TimeOut = TimeSpan.FromMinutes 10. })
                (sprintf "nuget push %s --api-key %s --source %s --symbol-source %s" project apiKey source symbolSource)

        projects |> Seq.iter (runSingleProject)
    else if (not (source = "") && not (apiKey = "") && not shouldPublishSymbolsPackages) then
        let runSingleProject project =
            DotNetCli.RunCommand
                (fun p -> 
                    { p with 
                        TimeOut = TimeSpan.FromMinutes 10. })
                (sprintf "nuget push %s --api-key %s --source %s" project apiKey source)

        projects |> Seq.iter (runSingleProject)
)

//--------------------------------------------------------------------------------
// Help 
//--------------------------------------------------------------------------------

Target "Help" <| fun _ ->
    List.iter printfn [
      "usage:"
      "./build.ps1 [target]"
      ""
      " Targets for building:"
      " * Build      Builds"
      " * Nuget      Create and optionally publish nugets packages"
      " * RunTests   Runs tests"
      " * All        Builds, run tests, creates and optionally publish nuget packages"
      " * DocFx      Creates a DocFx-based website for this solution"
      ""
      " Other Targets"
      " * Help       Display this help" 
      ""]

//--------------------------------------------------------------------------------
//  Target dependencies
//--------------------------------------------------------------------------------

Target "All" DoNothing
Target "Nuget" DoNothing

// nuget dependencies
"Clean" ==> "CreateNuget"
"CreateNuget" ==> "PublishNuget" ==> "Nuget"

// docs
//"BuildRelease" ==> "Docfx"

// all
"Nuget" ==> "All"

RunTargetOrDefault "Help"