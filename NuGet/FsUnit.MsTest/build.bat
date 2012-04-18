c:\nuget\nuget.exe pack .\FsUnit.MsTest.nuspec 

md c:\nuget\FsUnit.MsTest\

copy *.nupkg c:\nuget\FsUnit.MsTest\ /Y

pause