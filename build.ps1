msbuild .\Examples.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release
if ($env:APPVEYOR_BUILD_NUMBER -eq $NULL) {
	msbuild .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
}
.\build-aspnetcore.ps1