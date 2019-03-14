#### 0.5.1 March 07 2019 ####
**Bugfix Release for Petabridge.Templates v0.5.0**

* Fixed Azure Pipelines YAML - now properly supports build triggers and test reporting.
* Modified `RunTests` task to emit `vtx` files for use in Azure Pipelines. TeamCity integration still works.
* Removed separate `Restore` phase from builds since `dotnet build` handles this implicitly now.