#### 2.0.0 February 21 2022 ####

- Switched build automation system from FAKE to [NUKE](https://nuke.build/)
- Upgraded [pb-lib](https://github.com/petabridge/Petabridge.Library/), [`pb-akka-cluster`](https://github.com/petabridge/Petabridge.App) and [`pb-akka-web`](https://github.com/petabridge/Petabridge.App.Web) to all use .NET 6
- Replaced `common.props` with `Directory.Build.props`
- Git versioning with [GitVersion](https://gitversion.net/)
- Added README to NuGet Package

#### 1.2.0 April 15 2021 ####

- Upgraded [`pb-akka-cluster`](https://github.com/petabridge/Petabridge.App) and [`pb-akka-web`](https://github.com/petabridge/Petabridge.App.Web) to both use .NET 5
- Modernized [`pb-akka-cluster`](https://github.com/petabridge/Petabridge.App) and [`pb-akka-web`](https://github.com/petabridge/Petabridge.App.Web) to both [use the best `IHostedService` practices for running Akka.NET services behind the scenes](https://petabridge.com/blog/akkadotnet-ihostedservice/).
