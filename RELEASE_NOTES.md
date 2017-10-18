#### 0.1.3 October 18 2017 ####
* [`build.fsx` can not automatically detect TeamCity and toggle TC formatting on and off for XUnit2 test runs](https://github.com/petabridge/petabridge-dotnet-new/pull/19).
* [U]pdated XUnit2 target version to 2.3.0 stable](https://github.com/petabridge/petabridge-dotnet-new/pull/20).

#### 0.1.2 August 19 2017 ####
* Added .gitignore file to the Petabridge.Library template
* Added a sample Apache 2 `LICENSE` file to the template
* Added `AssemblyInfo` stage in order to sync `RELEASE_NOTES.md` with `common.props`; now you only need to update the assembly version of your projects inside `RELEASE_NOTES.md`.

#### 0.1.1 August 15 2017 ####
Added a `description` field to the Petabridge.Library template.

#### 0.1.0 August 15 2017 ####
First release of `Petabridge.Templates`, and ships with the following project templates:

* `Petabridge.Library` - creates a library project complete with unit tests, performance tests, FAKE build system, and DocFx documentation.