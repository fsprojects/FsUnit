c:\nuget\nuget.exe pack .\FsUnit.MbUnit.nuspec
md c:\nuget\FsUnit.MbUnit\
copy .\*.nupkg c:\nuget\FsUnit.MbUnit\ /Y

c:\nuget\nuget.exe pack .\FsUnit.MbUnit.Sample.nuspec
md c:\nuget\FsUnit.MbUnit.Sample\
copy .\*.nupkg c:\nuget\FsUnit.MbUnit.Sample\ /Y

pause