# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.0] / 2023-12-12
### DI
- DI container code based from [Onboxframework](https://github.com/engthiago/Onboxframework).
- Add `ContainerUtils` with `CreateContainer` and `CreateContainer(enableDisposeScopedInstances)`
- Add `IContainerScopedInstances` with `DisposeScopedInstances` (default: false)
- Update `Container` variables to `protected`
- Update `Container` the methods `Dispose` and `Clear` to `virtual`
### Tests
- Test `Container`
- Test `ContainerUtils`
- Test `Singleton`
- Test `Scoped`
- Test `Transient`
- Test `DI` and `Dispose`
- Test `Abstract` / `Interface` throws

[vNext]: ../../compare/1.0.0...HEAD
[1.0.0]: ../../compare/1.0.0