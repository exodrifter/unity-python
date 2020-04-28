# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/) 
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased]


## [0.5.0]

### Changed
* Updated IronPython to 2.7.10


## [0.4.1]

### Fixed
* Fix error output being redirected to `Debug.Log` instead of `Debug.LogError`


## [0.4.0]

### Added
* IronPython output is now redirected to the Unity console

### Fixed
* Fix problem where not all types in the `UnityEngine` namespace could be
  imported


## [0.3.1]

### Fixed
* Added a missing DLL `Microsoft.Scripting.Metadata` that is required
  to build


## [0.3.0]

### Changed
* Updated IronPython to 2.7.9


## [0.2.0]

### Added
* Added options parameter to `UnityPython.CreateEngine`

### Changed
* Updated IronPython to 2.7.8


## [0.1.0]

### Changed
* Updated IronPython to 2.7.7


## [0.0.0] - 2015-10-17

Initial support for Python in Unity3D with IronPython 2.6.2.

[Unreleased]: https://github.com/exodrifter/unity-python/compare/0.5.0...HEAD
[0.5.0]: https://github.com/exodrifter/unity-python/compare/0.5.0...0.4.1
[0.4.1]: https://github.com/exodrifter/unity-python/compare/0.4.0...0.4.1
[0.4.0]: https://github.com/exodrifter/unity-python/compare/0.3.1...0.4.0
[0.3.1]: https://github.com/exodrifter/unity-python/compare/0.3.0...0.3.1
[0.3.0]: https://github.com/exodrifter/unity-python/compare/0.2.0...0.3.0
[0.2.0]: https://github.com/exodrifter/unity-python/compare/0.1.0...0.2.0
[0.1.0]: https://github.com/exodrifter/unity-python/compare/0.0.0...0.1.0
[0.0.0]: https://github.com/exodrifter/unity-python/compare/f864edb...0.0.0
