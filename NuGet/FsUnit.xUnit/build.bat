c:\nuget\nuget.exe pack .\FsUnit.xUnit.nuspec
md c:\nuget\FsUnit.xUnit\
copy *.nupkg c:\nuget\FsUnit.xUnit\ /Y

c:\nuget\nuget.exe pack .\FsUnit.xUnit.Sample.nuspec
md c:\nuget\FsUnit.xUnit.Sample\
copy *.nupkg c:\nuget\FsUnit.xUnit.Sample\ /Y

pause