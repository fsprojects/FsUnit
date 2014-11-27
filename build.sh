#!/bin/bash
if [ ! -f packages/FAKE/tools/Fake.exe ]; then
  mono --runtime=v4.0 .nuget/NuGet.exe install FAKE -OutputDirectory packages -ExcludeVersion  -Prerelease
fi
mono --runtime=v4.0 packages/FAKE/tools/FAKE.exe build.fsx $@

