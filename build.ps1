nuget restore .\Examples.sln
msbuild .\Examples.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release
if ($env:APPVEYOR_BUILD_NUMBER -eq $NULL) {
  nuget restore .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln
	msbuild .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
}