properties {
    $signKeyPath = "../../keys/fx.key.pfx"
    $majorVersion = "0.2"
    $majorWithReleaseVersion = "0.2.2"
    $version = GetVersion $majorWithReleaseVersion
    $baseDir  = resolve-path ..
    $sourceDir = "$baseDir\src"
    $builds = @(
        @{ SrcFolder="fx.configuration"; Name = "fx.configuration"; TargetFramework="net45"; FinalDir="net45"; },
        @{ SrcFolder="fx.configuration"; Name = "fx.configuration"; TargetFramework="net40"; FinalDir="net40"; },
        @{ SrcFolder="fx.configuration"; Name = "fx.configuration"; TargetFramework="net35"; FinalDir="net35"; }
    )
}

task default -depends Build

task CleanOldBuild {
    Write-Host -ForegroundColor Yellow "Cleaning obj\bin and old build folders"

    foreach ($build in $builds)
    {
        $projectDir = $build.SrcFolder
        DeleteFolder "$sourceDir/$projectDir/obj"
        DeleteFolder "$sourceDir/$projectDir/bin"

        DeleteFolder (GetFinalDir $build)
    }
}

task Build -depends CleanOldBuild {

    Write-Host -ForegroundColor Green "Updating assembly version"
    Write-Host
    Update-AssemblyInfoFiles $sourceDir ($majorVersion + '.0.0') $version

    foreach ($build in $builds)
    {
        $srcDir = $build.SrcFolder
        $name = $build.Name
        $targetFramework = $build.TargetFramework
        $finalDir = GetFinalDir $build
        $projectFileName = "../src/$srcDir/$name.$targetFramework.csproj"
        Write-Host -ForegroundColor Green "Building " $name
        Write-Host -ForegroundColor Green "FinalDir " $finalDir
        exec { msbuild $projectFileName "/t:Clean;Rebuild" /p:Configuration=Release "/p:Platform=Any CPU" "/p:OutputPath=$finalDir" "/p:DocumentationFile=$finalDir\$name.xml" /p:AssemblyOriginatorKeyFile=$signKeyPath "/p:SignAssembly=true" "/p:DefineConstants=`"CODE_ANALYSIS;TRACE;`"" "/p:DebugSymbols=true" "/p:VisualStudioVersion=12.0" | Out-Default } "Error building $name"
    }
}

function Update-AssemblyInfoFiles ([string] $sourceDir, [string] $assemblyVersionNumber, [string] $fileVersionNumber)
{
    $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $assemblyVersion = 'AssemblyVersion("' + $assemblyVersionNumber + '")';
    $fileVersion = 'AssemblyFileVersion("' + $fileVersionNumber + '")';
    
    Get-ChildItem -Path $sourceDir -r -filter AssemblyInfo.cs | ForEach-Object {
        
        $filename = $_.Directory.ToString() + '\' + $_.Name
        Write-Host $filename
        $filename + ' -> ' + $version
    
        (Get-Content $filename) | ForEach-Object {
            % {$_ -replace $assemblyVersionPattern, $assemblyVersion } |
            % {$_ -replace $fileVersionPattern, $fileVersion }
        } | Set-Content -Encoding Unicode $filename
    }
}

function GetVersion($majorVersion)
{
    $now = [DateTime]::Now
    
    $year = $now.Year - 2000
    $month = $now.Month
    $totalMonthsSince2000 = ($year * 12) + $month
    $day = $now.Day
    $minor = "{0}{1:00}" -f $totalMonthsSince2000, $day
    
    $hour = $now.Hour
    $minute = $now.Minute
    $revision = "{0:00}{1:00}" -f $hour, $minute
    
    return $majorVersion + "." + $minor
}

function DeleteFolder($folderPath)
{
    if(Test-Path -Path $folderPath)
    {
        del $folderPath -Recurse -Force
    }
}

function GetFinalDir($build)
{
    $finalDir = $build.FinalDir
    $finalDir = "$baseDir/build/$finalDir"
    return $finalDir
}