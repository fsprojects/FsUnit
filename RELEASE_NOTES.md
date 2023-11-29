### 5.6.1.0 - Nov 29, 2023
- Set NUnit dependency < 4.0.0 to prevent compatibility issues. - (https://github.com/fsprojects/FsUnit/pull/257)

### 5.6.0.0 - Nov 10, 2023
- Set `>= LOCKEDVERSION` in Nuget dependencies for broader compatibility. - (https://github.com/fsprojects/FsUnit/pull/254)

### 5.5.0.0 - Oct 27, 2023
- Update dependencies. - (https://github.com/fsprojects/FsUnit/pull/250)

### 5.4.0.0 - Jul 10, 2023
- Add support for xunit 2.5.0. - (https://github.com/fsprojects/FsUnit/pull/240)
- Update dependencies.

### 5.3.1.0 - Jun 7, 2023
- Set FSharp.Core back to ~5.0.0 to support older projects. (https://github.com/fsprojects/FsUnit/pull/236)
- Update some dependencies.

### 5.3.0.0 - May 6, 2023
- Remove .NET7 as framework because of incompatibilities.
- Update dependencies.

### 5.2.0 - Jan 13, 2023
- Align should & throw in xUnit and MsTest. -> (https://github.com/fsprojects/FsUnit/pull/226)
- Add .NET7 as TargetFramework.
- Update dependencies.

### 5.1.0 - Oct 29, 2022
- Add `equalSeq` operator - https://github.com/fsprojects/FsUnit/pull/222

### 5.0.5 - Sep 27, 2022
- Fix `throwWithMessage` that now ignores return type. - https://github.com/fsprojects/FsUnit/pull/220

### 5.0.4 - Sep 6, 2022
- Fix actual messages in xUnit & MsTest in operators `throw` & `throwWithMessage` when exception will be thrown inside lambda. - https://github.com/fsprojects/FsUnit/pull/216

### 5.0.3 - Aug 16, 2022
- Fixed a reference issue with .NET Framework.

### 5.0.2 - Aug 15, 2022
- Dependency update (NHamcrest 2.0.1 => 3.0.1) -> (https://github.com/fsprojects/FsUnit/pull/211)

### 5.0.1 - Aug 5, 2022
- Docs updates
- Dependencies update

### 5.0.0 - Apr 9, 2022
- [BREAKING] xUnit equality assertions executed of expected value instead of actual
- FsUnitTyped assertions for xUnit (by @Smaug123) - https://github.com/fsprojects/FsUnit/commit/736b7a1378efe0266533fddcd0e47a6e53672256
- Native assertions for NUnit/FsUnitTyped (by @CaptnCodr) - https://github.com/fsprojects/FsUnit/commit/b4f29af63b809e5a84fcd4835bad6b47860a08da
- Allows usage of parent exception types in shouldFail assertions - https://github.com/fsprojects/FsUnit/commit/c9963411a065fde2a49f5fe258c48a9b3ab1606e
- Docs for Expecto assertions - http://fsprojects.github.io/FsUnit/Expecto.html
- Fantomas code formatting
- Dependencies update

### 4.2.0 - Jan 15, 2022
- Adjust license URL to be the raw link, fix http --> https - https://github.com/fsprojects/FsUnit/pull/195
- Update copyright time period and change license to MIT. - https://github.com/fsprojects/FsUnit/pull/196

### 4.1.0 - Nov 14, 2021
- Add net6.0 support. - https://github.com/fsprojects/FsUnit/pull/194
- Drop F# 4.7.x support.

### 4.0.7 - Oct 12, 2021
- Fix `ofCase` which didn't handle 'None'. - https://github.com/fsprojects/FsUnit/pull/192

### 4.0.6 - Aug 14, 2021
- Update dotnet tools (Paket 5.258.1 => 6.0.4, FSharp.Formatting.CommandTool 7.2.9 => 11.4.2). - https://github.com/fsprojects/FsUnit/pull/188

### 4.0.5 - Jul 18, 2021
- Dependency update (Paket 5.257.0 => 5.258.1, FAKE-CLI 5.20.3 => 5.20.4). - https://github.com/fsprojects/FsUnit/pull/186
- Use explicit MSTest.TestAdapter v2.1.2.

### 4.0.4 - Jan 16, 2021
- Dependency update (NUnit 3.12 => 3.13).
- Nuget authors update.

### 4.0.2 - Nov 07, 2020
- Fix license information and sample nuget packages. - https://github.com/fsprojects/FsUnit/pull/176

### 4.0.1 - Jul 31, 2020
- Prefer IStructuralEquatable to IStructuralComparable - https://github.com/fsprojects/FsUnit/pull/171

### 4.0.0 - Jul 28, 2020
- Better support for IStructuralEquatable under NUnit - https://github.com/fsprojects/FsUnit/pull/147
- Refactorings & Fantomas integration - https://github.com/fsprojects/FsUnit/pull/157
- Dropped net46 support - https://github.com/fsprojects/FsUnit/pull/169

### 3.9.0 - Jun 25, 2020
- Readable assertion messages on failure - https://github.com/fsprojects/FsUnit/pull/155
- Dependencies update

### 3.8.1 - Apr 2, 2020
* MSTest.TestFramework (2.1.1)

### 3.8.0 - Nov 29, 2019
* Added `equivalent` assertion for NUnit and MsTest - https://github.com/fsprojects/FsUnit/pull/145

### 3.7.0 - Nov 2, 2019
* Added `subsetOf` operator - https://github.com/fsprojects/FsUnit/pull/144

### 3.6.0 - Oct 30, 2019
* Added `supersetOf` operator - https://github.com/fsprojects/FsUnit/pull/141

### 3.5.0 - Oct 2, 2019
* Added `ofCase` matcher - https://github.com/fsprojects/FsUnit/pull/134
* Removed MbUnit from source code

### 3.4.1 - Aug 18, 2019
* xunit (2.4.1)
* NUnit (3.12)
* MSTest.TestFramework (1.4)

### 3.4.0 - Nov 10, 2018
* Added `inRange` operator

### 3.3.0 - Nov 9, 2018
* NUnit (3.11)
* xunit (2.4.1)

### 3.2.0 - Jul 30, 2018
* xunit (2.4)
* NUnit (3.10.1)
* MSTest.TestFramework (1.3.2)
* NETStandard.Library (2.0.3)

### 3.1.0 - Feb 16, 2018
* Multi-target .NET Core 2.0 projects
* Fixed "Change shouldBeSmallerThan to fail when passed 2 equal numbers" https://github.com/fsprojects/FsUnit/pull/112
* Added slighly more meaningful messages to a few matchers https://github.com/fsprojects/FsUnit/pull/115
* NuGet package allow to reference FSharp.Core 4.3.x https://github.com/fsprojects/FsUnit/issues/116

### 3.0.0 - Aug 11, 2017
* Support NUnit 3.6
* Compiled for .NET Standard 1.6 (NUnit, xUnit, MSTest)
* Removed `choice n` combinator from `FsUnit.NUnit`

### 2.3.2 - Oct 4, 2016
* Added support of `NUnit 3.5`

### 2.3.1 - July 9, 2016
* Added support of `NUnit 3.4.1`

### 2.3.0 - June 27, 2016
* Added support of `NUnit 3.4`

### 2.2.0 - March 26, 2016
* Added support of `NUnit 3.2.1`
* Added FsUnitTyped with statically typed operators - https://github.com/fsprojects/FsUnit/pull/85
* Fixed: Structural equality fail - https://github.com/fsprojects/FsUnit/issues/78
* Fixed: Statically typed equality test - https://github.com/fsprojects/FsUnit/issues/21
* Fixed: Simplify "should throw" - https://github.com/fsprojects/FsUnit/issues/20
* Fixed: matchList can match empty obj lists - https://github.com/fsprojects/FsUnit/pull/90

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
