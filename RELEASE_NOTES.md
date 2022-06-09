#### 2.1.0 June 09 2022 ####

- Migrated Petabridge.App and Petabridge.App.Web templates to use [Akka.Hosting](https://github.com/akkadotnet/Akka.Hosting)
- Migrated Petabridge.App and Petabridge.App.Web to use file-scoped namespaces and minimal .NET 6 APIs
- Enabled nullability for Petabridge.App and Petabridge.App.Web
- Removed dependency on Akka.Bootstrap.Docker, migrated to using Microsoft.Extensions.Configuration instead
