c:\nuget\nuget.exe pack .\FsUnit.xUnit.nuspec
md c:\nuget\FsUnit.xUnit\
copy *.nupkg c:\nuget\FsUnit.xUnit\ /Y
pause