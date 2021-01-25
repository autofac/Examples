dotnet build .\Examples.sln
if ($NULL -eq $env:APPVEYOR_BUILD_NUMBER -and $IsWindows) {
  # Only build the Service Fabric demo when it's not AppVeyor and the current environment is Windows.
  nuget restore .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln
  msbuild .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
}