#### 1.0.4 November 26 2019 ####

Second and final attempt at fixing issue: [only one of the three templates in `Petabridge.Templates` being accessible during `dotnet new`](https://github.com/petabridge/petabridge-dotnet-new/issues/127).

You can now use the following three templates:

* `dotnet new pb-lib` - creates a .NET Standard 2.0 library with a corresponding unit test project, documentation, and build system.
* `dotnet new pb-akka-cluster` - creates a headless .NET Core 3.0 service that includes full [Akka.NET](https://getakka.net/) clustering support, Docker support, documentation, and build systems.
* `dotnet new pb-akka-web` - does the same as `pb-akka-cluster`, but hosts [Akka.NET](https://getakka.net/) inside an ASP.NET Core 3.0 simple web application.
