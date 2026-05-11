# big-code-analysis-output

Integration-test fixtures and accepted [insta] snapshot trees for the
[`big-code-analysis`](https://github.com/dekobon/big-code-analysis) Rust
workspace.

This repository is consumed as a git submodule at
`tests/repositories/big-code-analysis-output/` in the parent project.
It is not a standalone crate and contains no Rust code.

## Layout

```text
.
├── csharp/                  # Hand-written C# corpus exercised by tests/csharp_test.rs
├── php/                     # Hand-written PHP  corpus exercised by tests/php_test.rs
└── snapshots/
    ├── csharp/              # Snapshots for the in-tree csharp/  corpus
    ├── php/                 # Snapshots for the in-tree php/     corpus
    ├── serde/               # Snapshots for the serde      submodule corpus
    ├── pdf.js/              # Snapshots for the pdf.js     submodule corpus
    └── DeepSpeech/          # Snapshots for the DeepSpeech submodule corpus
                             #   (only native_client/ is currently snapshotted)
```

### Two roles

1. **Source corpora** — the `csharp/` and `php/` directories hold small,
   purpose-written programs that cover language constructs the per-language
   metric implementations need to exercise (anonymous types, control flow,
   generics, traits/enums, embedded markup, etc.). Add cases here when a
   new metric or language feature needs targeted coverage.
2. **Snapshot trees** — `snapshots/<corpus>/<path>.snap` mirrors each
   input file's relative path under its corpus. The parent's
   `tests/common/mod.rs` writes serialized `FuncSpace` metrics with
   `insta::assert_yaml_snapshot!`; values are rounded to three decimal
   places and the `name` field is redacted so snapshots are reproducible
   across machines. For `serde/`, `pdf.js/`, and `DeepSpeech/` the
   source files come from sibling submodules in the parent repo, not
   from this submodule.

## Updating snapshots

Run the integration tests from the parent checkout:

```bash
cargo test --workspace --all-features
cargo insta test --review            # or --accept for a clean batch
```

Drift typically arrives in waves (a grammar bump, a metric-computation
fix, a Halstead operator reclassification). After verifying the diff is
metric-value-only, accepting in batch is fine.

The parent project also enforces a snapshot-anchor policy (see
`AGENTS.md`), but that policy targets the per-metric **JSON** snapshots
under `src/metrics/` — the integration snapshots in this submodule are
YAML and are out of scope.

## Workflow contract with the parent repo

A behaviour-changing fix in the parent that shifts these snapshots is
not done until **all four** of the following are true in the same
change:

1. `cargo test --workspace --all-features` exits clean from a fresh
   working tree (no `.snap.new` left behind here).
2. The accepted snapshots are committed and pushed to this repository's
   `main` branch.
3. The parent records the new submodule SHA (`git add
   tests/repositories/big-code-analysis-output`) in the **same parent
   commit** as the fix — never as a follow-up.
4. After any rebase, force-push, or long-running batch fix, the
   integration tests are re-run. This submodule's history is
   force-pushed often enough that prior accepts cannot be assumed to
   survive.

A behaviour-changing fix without the matching submodule bump leaves the
next fresh clone with either an unfetchable submodule SHA or stranded
`.snap.new` drift that blocks CI on every subsequent change.

## License

Mozilla Public License 2.0 — see [`LICENSE`](LICENSE).

[insta]: https://insta.rs/
