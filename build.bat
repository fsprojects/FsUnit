@echo off
cls
if not exist tools\FAKE\tools\Fake.exe ( 
	".nuget\NuGet.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
)
"tools\FAKE\tools\Fake.exe" "build.fsx" %*
pause
