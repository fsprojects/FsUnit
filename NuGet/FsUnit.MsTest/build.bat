c:\nuget\nuget.exe pack .\Fs30Unit.MsTest.nuspec 

md c:\nuget\Fs30Unit.MsTest\

copy *.nupkg c:\nuget\Fs30Unit.MsTest\ /Y

pause