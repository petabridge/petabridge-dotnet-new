#### 0.5.0 March 07 2019 ####
`Petabridge.Templates` now comes with default [Azure DevOps Pipelines YAML files](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema), found in the `/build-system` folder in each new project created via the `pb-lib` `dotnet new` template.

There are three files total:

* `linux-pr-validation.yaml` runs the `build.sh all` command for pull requests on hosted Ubuntu 16.04 VMs.
* `windows-pr-validation.yaml` runs the `build.cmd all` command for pull requested on hosted Windows Server 2016 VMs.
* `windows-release.yaml` runs the full code signing and publication package for your project, plus it creates an automatic release on Github afterwards including all of the signed build artifacts.