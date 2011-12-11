c:\nuget\nuget.exe pack .\FsUnit.MbUnit.nuspec
md c:\nuget\FsUnit.MbUnit\
copy .\*.nupkg c:\nuget\FsUnit.MbUnit\ /Y
pause