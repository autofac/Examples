---
name: examples
description: >-
  What an Autofac example project is for and how to keep it small, current,
  and buildable.
applyTo: "**"
---

# Examples

Each project under `src/` shows one Autofac feature or integration working end to end, so a reader can copy the wiring into their own application. Examples are teaching material, not libraries: they reference released NuGet packages, have no tests, and publish nothing.

- Keep each example to the least code that demonstrates its feature. Leave out logging, error handling, configuration layers, and architecture that a real application would add but the reader does not need in order to understand the wiring.
- Show the recommended way to use the feature, matching the documentation page the example follows.
- Reference the latest released version of each Autofac package and of the framework it integrates with. Examples are the one place that tracks the newest releases, because they show current usage.
- Give each example a `README.md` that says what it shows in a sentence, which packages it uses, how to run it, and which documentation page it follows. Add a row for it to the table in the root `README.md`.
- Add new projects to `Examples.slnx` so CI builds them. Everything builds with zero warnings.
- Comment the Autofac-specific lines that a reader is meant to learn from, and nothing else.
- Treat example code as application code. The C# rules for library code, such as the copyright header, `.resx` messages, `ConfigureAwait(false)`, and multiple target frameworks, do not apply here.
