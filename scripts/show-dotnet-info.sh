#!/bin/sh
which dotnet
if test $? -eq 0; then
  echo "Using dotnet:"
  dotnet --version
else
  echo "dotnet not found"
fi