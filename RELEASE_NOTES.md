### 2.1.0 - March 7, 2016
* Added support of `NUnit 3.2`
* Added pretty-print for F# value types - https://github.com/fsprojects/FsUnit/pull/89

### 2.0.0 - February 8, 2016
* Added support of `NUnit 3` - https://github.com/fsprojects/FsUnit/pull/83
* Dropped support of obsolete `not` operator

### 1.4.1.0 - 07 December 2015
* Fixed `should be null` - https://github.com/fsprojects/FsUnit/issues/52

### 1.4.0.0 - 03 November 2015
* Migration to xUnit 2.1
* FsUnit.NUnit compiled for net45
* Target FsUnit to FSharp.Core 3.1.2.5
* FsUnitDepricated module renamed to FsUnitDeprecated https://github.com/fsprojects/FsUnit/pull/46
* Enable substring checks https://github.com/fsprojects/FsUnit/pull/45
* Fixed assertion message for NUnit equal constraint - https://github.com/fsprojects/FsUnit/pull/60
* Added support of `shouldFail` operator for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/64
* Added support of `instanceOfType` operator for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/65
* Added support of `Empty` operator for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/66
* Added support of `NaN` operator for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/67
* Added support of `haveLength` and `haveCount` operators for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/68
* Added support of `unique` operator for xUnit, MsTest and MbUnit - https://github.com/fsprojects/FsUnit/pull/70

### 1.3.1.0 - 26 July 2015
* Bump NUnit version up to 2.6.4
* Bump xUnit version up to 1.9.2
* Bump MbUnit version up to 3.4.14
* Migration to Paket
* Readme and samples converted to FsUnit site

### 1.3.0.1 - June 29 2014

### 1.2.1.0 - April 28 2013
* Includes new features for generic assertions and containment check. Currently, this feature is only supported for the NUnit implementation. Thanks to jack-pappas for the contributions.

### 1.1.0.0 - April 21 2012
* Pulls in the latest versions for xUnit.NET and NUnit. Replaces the "not" keyword with "not'" and adds the FsUnitDepricated module for backward compatibility. Adds MsTest support for VS11 only.

### 1.0.1.3 - April 21 2012
* Includes new assertions for NUnit such as NaN, instanceOfType, and unique.

### 1.0.0.4 - December 25 2011
* Added support for xUnit.NET and MbUnit and a new assertion.

### 0.9.1.1 - December 03 2011
* Added several new assertions.

### 0.9.0.0 - February 12 2011
* Ray Vernagus built this version and several before it with NUnit as the targeted testing framework.