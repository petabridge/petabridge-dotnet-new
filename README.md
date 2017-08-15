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

To uninstall the package, use the following command:

```
C:\> dotnet new -u Petabridge.Templates
```

### Available Templates
The following templates are installed as part of your `Petabridge.Templates` installation:

|    Template Name   | Short Name | Description                                                                                                                                   |
|:------------------:|------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| [Petabridge.Library](src/Content/Petabridge.Library/README.md) | pb-lib     | A professional .NET Core project setup including build scripts, documentation, unit tests, and performance tests for a class library project. |

To use one of these templates, you can use the `dotnet new` command followed by the name or shortname.

```
C:\> dotnet new pb-lib [-n name] [other arguments]
```

See [the official `dotnet new` documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) for more information on the sorts of options that are available when using project templates.

You can read more about how these templates work by clicking on their titles and reading the `README.md` for each individual project.

## Questions, Comments, and Suggestions
We accept pull requests! Please let us know what we can do to make these templates more useful, extensible, or easier to use.

## About Petabridge

![Petabridge logo](docs/images/petabridge_logo_small.png)

[Petabridge](http://petabridge.com/) is a company dedicated to making it easier for .NET developers to build distributed and high-performance applications in .NET.

Petabridge provides [Akka.NET](http://getakka.net/) consulting, training, and support including advanced training in [Akka.Remote](https://petabridge.com/training/akka-remoting/), [Akka.Cluster](https://petabridge.com/training/akka-clustering/), and [Akka.NET Design Patterns](https://petabridge.com/training/akka-design-patterns/)!

---
Copyright 2015 - 2017 Petabridge, LLC. All rights reserved.