c:\nuget\nuget.exe pack .\FsUnit.nuspec
md c:\nuget\FsUnit\
copy *.nupkg c:\nuget\FsUnit\ /Y
pause