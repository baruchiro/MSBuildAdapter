
# MSBuildAdapter

Adapter for programmatically work with build.

[![Build Status](https://travis-ci.org/baruchiro/MSBuildAdapter.svg?branch=master)](https://travis-ci.org/baruchiro/MSBuildAdapter)

## Supported features

- Get all projects from sln file.
- Get other projects that depend on a current project.
- Get other projects that the current project depends on.
- Get topological sort of projects dependencies.
- Get project properties (TargetFramework, is UnitTest and so).