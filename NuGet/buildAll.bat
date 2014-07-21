c:\nuget\nuget.exe pack .\FsUnit.MbUnit\FsUnit.MbUnit.nuspec
md c:\nuget\FsUnit.MbUnit\

c:\nuget\nuget.exe pack .\\FsUnit.MbUnit\FsUnit.MbUnit.Sample.nuspec
md c:\nuget\FsUnit.MbUnit.Sample\

c:\nuget\nuget.exe pack .\FsUnit.MsTest\Fs30Unit.MsTest.nuspec 
md c:\nuget\Fs30Unit.MsTest\

c:\nuget\nuget.exe pack .\FsUnit.MsTest\Fs30Unit.MsTest.Sample.nuspec 
md c:\nuget\Fs30Unit.MsTest.Sample\

c:\nuget\nuget.exe pack .\FsUnit.NUnit\FsUnit.nuspec
md c:\nuget\FsUnit\

c:\nuget\nuget.exe pack .\FsUnit.NUnit\FsUnit.Sample.nuspec
md c:\nuget\FsUnit.Sample\

c:\nuget\nuget.exe pack .\FsUnit.Xunit\FsUnit.Xunit.nuspec
md c:\nuget\FsUnit.Xunit\

c:\nuget\nuget.exe pack .\FsUnit.Xunit\FsUnit.Xunit.Sample.nuspec
md c:\nuget\FsUnit.Xunit.Sample\

pause
