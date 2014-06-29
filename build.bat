@echo off
cls
if not exist packages\FAKE\tools\Fake.exe ( 
	".nuget\NuGet.exe" "install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion" "-Prerelease"
)
"packages\FAKE\tools\Fake.exe" "build.fsx" %*
