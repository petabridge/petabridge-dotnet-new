# Petabridge.Templates
.NET CLI templates for [Petabridge](https://petabridge.com/)-style projects.

## Goals
The goal of this project is provide templates for creating professional-quality OSS projects that do the following:

1. Have unit tests;
2. Have performance tests;
3. Have documentation;
4. Have build system support, x-plat; and
5. Have standardized conventions that allow all of the above to be extended and workable.

## Installation and Use
To use these templates, execute the following command on the `dotnet` CLI:

```
C:\> dotnet new -i "Petabridge.Templates::*"
```

This will download the latest available [Petabridge.Templates package from NuGet](https://www.nuget.org/packages/Petabridge.Templates) and install it into your CLI.

After the installation process is complete, you'll see all of the templates included in the Petabridge.Templates package listed in your set of available templates if you execute the `dotnet new -l` command:

```
Templates                         Short Name      Language      Tags
--------------------------------------------------------------------------------------
Console Application               console         [C#], F#      Common/Console
Class library                     classlib        [C#], F#      Common/Library
Petabridge .NET Core Library      pb-lib          [C#]          Petabridge/DocFx/Tests
Unit Test Project                 mstest          [C#], F#      Test/MSTest
xUnit Test Project                xunit           [C#], F#      Test/xUnit
ASP.NET Core Empty                web             [C#]          Web/Empty
ASP.NET Core Web App              mvc             [C#], F#      Web/MVC
ASP.NET Core Web API              webapi          [C#]          Web/WebAPI
Solution File                     sln                           Solution
```

To uninstall the package, use the following command:

```
C:\> dotnet new -u Petabridge.Templates
```

### Available Templates
The following templates are installed as part of your `Petabridge.Templates` installation:

|    Template Name   | Short Name | Description                                                                                                                                   |
|:------------------:|------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| [Petabridge.Library](https://github.com/petabridge/Petabridge.Library/) | pb-lib     | A professional .NET Core project setup including build scripts, documentation, unit tests, and performance tests for a class library project. |
| [Petabridge.App](https://github.com/petabridge/Petabridge.App/) | pb-akka-cluster     | Creates a headless .NET Core 3.0 service that includes full [Akka.NET](https://getakka.net/) clustering support, Docker support, documentation, and build systems. |
| [Petabridge.App.Web](https://github.com/petabridge/Petabridge.App.Web) | pb-akka-web     | Does the same as `pb-akka-cluster`, but hosts [Akka.NET](https://getakka.net/) inside an ASP.NET Core 3.0 simple web application. |


You can read more about how these templates work by clicking on their titles and reading the `README.md` for each individual project.

To use one of these templates, you can use the `dotnet new` command followed by the name or shortname.

```
C:\> dotnet new pb-lib [-n name] [other arguments]
```

So for instance, if I execute `dotnet new pb-lib -n "MyProject"` the following output will appear in my working directory:

```
D:\MyProject\build.cmd
D:\MyProject\build.fsx
D:\MyProject\build.ps1
D:\MyProject\build.sh
D:\MyProject\docs
D:\MyProject\MyProject.sln
D:\MyProject\README.md
D:\MyProject\RELEASE_NOTES.md
D:\MyProject\src
D:\MyProject\docs\api
D:\MyProject\docs\articles
D:\MyProject\docs\docfx.json
D:\MyProject\docs\images
D:\MyProject\docs\index.md
D:\MyProject\docs\toc.yml
D:\MyProject\docs\api\index.md
D:\MyProject\docs\articles\index.md
D:\MyProject\docs\articles\toc.yml
D:\MyProject\docs\images\icon.png
D:\MyProject\src\common.props
D:\MyProject\src\MyProject
D:\MyProject\src\MyProject.Tests
D:\MyProject\src\MyProject.Tests.Performance
D:\MyProject\src\MyProject\Class1.cs
D:\MyProject\src\MyProject\MyProject.csproj
D:\MyProject\src\MyProject.Tests\MyProject.Tests.csproj
D:\MyProject\src\MyProject.Tests\UnitTest1.cs
D:\MyProject\src\MyProject.Tests.Performance\MyProject.Tests.Performance.csproj
D:\MyProject\src\MyProject.Tests.Performance\UnitTest1.cs
```

I'll have a new .NET Standard library project complete with a cross-platform build system, documentation, unit tests, performance tests, and a README explaining how all of the above work ready to go from day one.

See [the official `dotnet new` documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) for more information on the sorts of options that are available when using project templates.

## Questions, Comments, and Suggestions
We accept pull requests! Please let us know what we can do to make these templates more useful, extensible, or easier to use.

## About Petabridge

![Petabridge logo](docs/images/petabridge_logo_small.png)

[Petabridge](http://petabridge.com/) is a company dedicated to making it easier for .NET developers to build distributed and high-performance applications in .NET.

Petabridge provides [Akka.NET](http://getakka.net/) consulting, training, and support including advanced training in [Akka.Remote](https://petabridge.com/training/akka-remoting/), [Akka.Cluster](https://petabridge.com/training/akka-clustering/), and [Akka.NET Design Patterns](https://petabridge.com/training/akka-design-patterns/)!

---
Copyright 2015 - 2019 Petabridge® All rights reserved.
