dotnet build .\Examples.sln
if ($NULL -eq $env:APPVEYOR_BUILD_NUMBER -and $env:APPVEYOR_BUILD_WORKER_IMAGE -like "Visual Studio*") {
  nuget restore .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln
  msbuild .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
}