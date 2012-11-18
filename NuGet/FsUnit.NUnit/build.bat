c:\nuget\nuget.exe pack .\FsUnit.nuspec
md c:\nuget\FsUnit\
copy *.nupkg c:\nuget\FsUnit\ /Y

c:\nuget\nuget.exe pack .\FsUnit.Sample.nuspec
md c:\nuget\FsUnit.Sample\
copy *.nupkg c:\nuget\FsUnit.Sample\ /Y

pause