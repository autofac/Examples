########################
# THE BUILD!
########################

Push-Location $PSScriptRoot
try {
    Import-Module $PSScriptRoot/build/Autofac.Build.psd1 -Force

    $globalJson = (Get-Content "$PSScriptRoot/global.json" | ConvertFrom-Json -NoEnumerate);

    $sdkVersion = $globalJson.sdk.version

    # Install dotnet SDK versions during CI. In a local build we assume you have
    # everything installed; on CI we'll force the install. If you install _any_
    # SDKs, you have to install _all_ of them because you can't install SDKs in
    # two different locations. dotnet CLI locates SDKs relative to the
    # executable.
    if ($Null -ne $env:APPVEYOR_BUILD_NUMBER) {
        Install-DotNetCli -Version $sdkVersion
        foreach ($additional in $globalJson.additionalSdks)
        {
            Install-DotNetCli -Version $additional;
        }
    }

    # Write out dotnet information
    & dotnet --info

    # Build/package
    Write-Message "Building projects"
    &dotnet build $PSScriptRoot\Examples.sln
    if ($NULL -eq $env:APPVEYOR_BUILD_NUMBER -and $IsWindows) {
        # Only build the Service Fabric demo when it's not AppVeyor and the current environment is Windows.
        nuget restore $PSScriptRoot\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln
        msbuild $PSScriptRoot\src\ServiceFabricDemo\AutofacServiceFabricDemo.sln /t:Rebuild /verbosity:Minimal /p:Configuration=Release /p:Platform=x64
    }

    # Finished
    Write-Message "Build finished"
}
finally {
    Pop-Location
}
