@echo off
cls

dotnet tool restore
dotnet run --project build/build.fsproj -- %*
