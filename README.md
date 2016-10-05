# Examples
Example projects that consume and demonstrate [Autofac](http://autofac.org) functionality and integration.

[![Build status](https://ci.appveyor.com/api/projects/status/ckc94rt42bfhdt6j?svg=true)](https://ci.appveyor.com/project/Autofac/examples)

##Reading the Examples
The examples in the repo are always for the latest Autofac versions and libraries. Look at the tags on this repo to see examples for older and/or deprecated functionality.

The examples attempt to stick pretty close to the [Autofac documentation](http://autofac.readthedocs.io) so it helps to have that available.

##Building the Examples
The `Examples.sln` file has all the samples in it _except_ the ASP.NET Core example. Opening and building that solution gets you pretty far.

To build the ASP.NET Core example, execute the `build-aspnetcore.ps1` script or use the `dotnet` CLI to `restore` and `build` the project. It's not currently in the solution [due to tooling challenges with AppVeyor being unable to call `nuget restore` on a solution that has dotnet CLI projects](https://github.com/aspnet/cli-samples/issues/32#issuecomment-231129420).