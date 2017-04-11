msbuild .\Examples.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release
msbuild .\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
.\build-aspnetcore.ps1