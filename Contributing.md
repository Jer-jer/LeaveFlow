### The Standards (Adopted for LeaveFlow)

Creating this in case I forget.

#### 1. Semantic Versioning (SemVer 2.0.0)

Format: `MAJOR.MINOR.PATCH` (e.g., `1.0.0`)

| Version Part | When to Increment                                     | Example                                |
| ------------ | ----------------------------------------------------- | -------------------------------------- |
| **MAJOR**    | Breaking changes (API shift, data migration required) | `0.9.0` → `1.0.0` (Stable launch)      |
| **MINOR**    | New features, backward-compatible                     | `1.0.0` → `1.1.0` (Added HTMX polling) |
| **PATCH**    | Bug fixes, docs, no new features                      | `1.1.0` → `1.1.1` (Fixed login bug)    |

**Rule for Now:** We are in **`0.x.x`** (Pre-release). MAJOR can break anything. Once we hit **`1.0.0`** (Phase 6), breaking changes require a MAJOR bump.

#### 2. Commit Message Format (Conventional Commits)

Format: `<type>(<scope>): <description>`

| Type       | Meaning                      | Example                                   |
| ---------- | ---------------------------- | ----------------------------------------- |
| `feat`     | New feature                  | `feat(auth): add login endpoint`          |
| `fix`      | Bug fix                      | `fix(db): resolve connection timeout`     |
| `docs`     | Documentation only           | `docs(readme): update installation steps` |
| `chore`    | Maintenance (no code change) | `chore(deps): bump Npgsql version`        |
| `refactor` | Code change, no feature/fix  | `refactor(domain): extract value object`  |
| `test`     | Adding tests                 | `test(domain): add balance edge cases`    |

**Scope:** Optional, but recommended (e.g., `web`, `domain`, `infra`, `ci`).

**Bad commit message:** `fixed stuff`  
**Good commit message:** `fix(infra): resolve docker health check timeout`

---

### Where to Store the Version

1.   **`.csproj` Files:** Update `<Version>` tag in `LeaveFlow.Web.csproj` (and others if synced).
2.   **Git Tags:** Tag releases (`git tag -a v0.1.0 -m "Release v0.1.0"`).
3.   **README Badge:** Add a version badge at the top.
