powershell -Command "& { Start-Transcript runbuild.txt; Import-Module ..\tools\psake\psake.psm1; Invoke-psake .\build.ps1 %*; Stop-Transcript; }"
