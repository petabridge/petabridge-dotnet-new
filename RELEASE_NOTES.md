#### 0.3.1 September 07 2018 ####
* Fixed a minor issue with `build.sh` not working correctly out of the box due to an unexpected parameter in `dotnet-install.sh`.
* Upgraded to NBench v1.2.2 to avoid NuGet package downgrade warnings.

#### 0.3.0 July 14 2018 ####
This is a major update to the `Petabridge.Library` `dotnet new` template; most notably it enables .NET Core execution of performance tests using [NBench v1.2.1](https://github.com/petabridge/NBench#running-nbench-tests-with-dotnet-nbench) and the new `dotnet nbench` tool. In addition, we've fixed a number of issues related to DocFx output.

* [Update template to support NBench for .NET Standard and .NET Core](https://github.com/petabridge/petabridge-dotnet-new/issues/24) - also automatically runs NBench now as part of the `./build.cmd all` or `./build.sh all` invocations.
* [DocFx: fix searchbar on IIS](https://github.com/petabridge/petabridge-dotnet-new/issues/54)
* [DocFx: add support for sitemaps](https://github.com/petabridge/petabridge-dotnet-new/issues/47)
* [DocFx: Bug: API documentation not generated correctly out of the box for .NET Standard 2.0](https://github.com/petabridge/petabridge-dotnet-new/issues/36)
* [Bug: build.sh references incorrect URL for dotnet-install.sh](https://github.com/petabridge/petabridge-dotnet-new/issues/51)

You can [see the full list of changes for this update here](https://github.com/petabridge/petabridge-dotnet-new/milestone/2).

#### 0.2.1 April 19 2018 ####
* [Disable NBench by default](https://github.com/petabridge/petabridge-dotnet-new/pull/41)
* [Add default description tag to projects](https://github.com/petabridge/petabridge-dotnet-new/issues/33)
* [Add reference to xunit.runner.visualstudio in test projects](https://github.com/petabridge/petabridge-dotnet-new/issues/32)
* [Change build system to build the entire solution, rather than iterating over individual projects](https://github.com/petabridge/petabridge-dotnet-new/issues/31) - significantly speeds up build times.

#### 0.2.0 January 17 2018 ####
* [Upgrade template to .NET Standard 2.0](https://github.com/petabridge/petabridge-dotnet-new/issues/28).
* [See the full v0.2.0 change set here](https://github.com/petabridge/petabridge-dotnet-new/milestone/1).

#### 0.1.3 October 18 2017 ####
* [`build.fsx` can not automatically detect TeamCity and toggle TC formatting on and off for XUnit2 test runs](https://github.com/petabridge/petabridge-dotnet-new/pull/19).
* [Updated XUnit2 target version to 2.3.0 stable](https://github.com/petabridge/petabridge-dotnet-new/pull/20).

#### 0.1.2 August 19 2017 ####
* Added .gitignore file to the Petabridge.Library template
* Added a sample Apache 2 `LICENSE` file to the template
* Added `AssemblyInfo` stage in order to sync `RELEASE_NOTES.md` with `common.props`; now you only need to update the assembly version of your projects inside `RELEASE_NOTES.md`.

#### 0.1.1 August 15 2017 ####
Added a `description` field to the Petabridge.Library template.

#### 0.1.0 August 15 2017 ####
First release of `Petabridge.Templates`, and ships with the following project templates:

* `Petabridge.Library` - creates a library project complete with unit tests, performance tests, FAKE build system, and DocFx documentation.
