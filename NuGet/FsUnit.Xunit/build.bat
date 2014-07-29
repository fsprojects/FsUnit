c:\nuget\nuget.exe pack .\FsUnit.Xunit.nuspec
md c:\nuget\FsUnit.Xunit\
copy *.nupkg c:\nuget\FsUnit.Xunit\ /Y

c:\nuget\nuget.exe pack .\FsUnit.Xunit.Sample.nuspec
md c:\nuget\FsUnit.Xunit.Sample\
copy *.nupkg c:\nuget\FsUnit.Xunit.Sample\ /Y

pause
