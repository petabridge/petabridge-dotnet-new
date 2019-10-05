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
let copyright = "Copyright Petabridge © 2015-2018"
let company = "Petabridge"
let description = "dotnet new templates for professional OSS projects"
let tags = ["template"; "dotnet new"; "Petabridge"; "DocFx"; "build"; "NBench"; "Akka";]
let configuration = "Release"

// Metadata used when signing packages and DLLs
let signingName = "Petabridge.Templates"
let signingDescription = "Petabridge Standard Build Templates"
let signingUrl = "https://github.com/petabridge/petabridge-dotnet-new"

// Read release notes and version
let buildNumber = environVarOrDefault "BUILD_NUMBER" "0"
let preReleaseVersionSuffix = "-beta" + (if (not (buildNumber = "0")) then (buildNumber) else DateTime.UtcNow.Ticks.ToString())
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

Target "AssemblyInfo" (fun _ ->
    XmlPokeInnerText "./src/Petabridge.Templates.csproj" "//Project/PropertyGroup/PackageVersion" releaseNotes.AssemblyVersion    
    XmlPokeInnerText "./src/Petabridge.Templates.csproj" "//Project/PropertyGroup/PackageReleaseNotes" (releaseNotes.Notes |> String.concat "\n")
)

//--------------------------------------------------------------------------------
// Code signing targets
//--------------------------------------------------------------------------------
Target "SignPackages" (fun _ ->
    let canSign = hasBuildParam "SignClientSecret" && hasBuildParam "SignClientUser"
    if(canSign) then
        log "Signing information is available."
        
        let assemblies = !! (outputNuGet @@ "*.nupkg")

        let signPath =
            let globalTool = tryFindFileOnPath "SignClient.exe"
            match globalTool with
                | Some t -> t
                | None -> if isWindows then findToolInSubPath "SignClient.exe" "tools/signclient"
                          elif isMacOS then findToolInSubPath "SignClient" "tools/signclient"
                          else findToolInSubPath "SignClient" "tools/signclient"

        let signAssembly assembly =
            let args = StringBuilder()
                    |> append "sign"
                    |> append "--config"
                    |> append (__SOURCE_DIRECTORY__ @@ "appsettings.json") 
                    |> append "-i"
                    |> append assembly
                    |> append "-r"
                    |> append (getBuildParam "SignClientUser")
                    |> append "-s"
                    |> append (getBuildParam "SignClientSecret")
                    |> append "-n"
                    |> append signingName
                    |> append "-d"
                    |> append signingDescription
                    |> append "-u"
                    |> append signingUrl
                    |> toText

            let result = ExecProcess(fun info -> 
                info.FileName <- signPath
                info.WorkingDirectory <- __SOURCE_DIRECTORY__
                info.Arguments <- args) (System.TimeSpan.FromMinutes 5.0) (* Reasonably long-running task. *)
            if result <> 0 then failwithf "SignClient failed.%s" args

        assemblies |> Seq.iter (signAssembly)
    else
        log "SignClientSecret not available. Skipping signing"
)

//--------------------------------------------------------------------------------
// Nuget targets 
//--------------------------------------------------------------------------------

let overrideVersionSuffix (project:string) =
    match project with
    | _ -> versionSuffix // add additional matches to publish different versions for different projects in solution

Target "CreateNuget" (fun _ -> 
    let projects = !! "src/Petabridge.Templates.csproj" 
    let runSingleProject project =
        DotNetCli.Pack
            (fun p -> 
                { p with
                    Project = project
                    Configuration = configuration
                    VersionSuffix = overrideVersionSuffix project
                    OutputPath = outputNuGet })

    projects |> Seq.iter (runSingleProject)
)

Target "PublishNuget" (fun _ ->
    let projects = !! "./bin/nuget/*.nupkg" -- "./bin/nuget/*.symbols.nupkg"
    let apiKey = getBuildParamOrDefault "nugetkey" ""
    let source = getBuildParamOrDefault "nugetpublishurl" "https://api.nuget.org/v3/index.json"
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
      " * SignPackages  Signs all NuGet packages, provided that the following arguments are passed into the script: SignClientSecret={secret} and SignClientUser={username}"
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
"Clean" ==> "AssemblyInfo" ==> "CreateNuget"
"CreateNuget" ==> "SignPackages" ==> "PublishNuget" ==> "Nuget"
// docs
//"BuildRelease" ==> "Docfx"

// all
"Nuget" ==> "All"

RunTargetOrDefault "Help"