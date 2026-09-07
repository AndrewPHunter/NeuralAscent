# The Learning Plan

*From Perceptron to Transformer — one gradient at a time*

Andrew P. Hunter · 2025

---

## What This Is

This is the reading and study journal that runs alongside the NeuralAscent implementation
arc. It is a personal learning record kept in public, not a curriculum or a recommendation.

The organising idea is the **parallel model**: theory and implementation stay in sync. You
read about an architecture *while* you are building it — not before, not after. When the
code produces a result you don't fully understand, the books are the first stop.

**Session cadence:** 45–60 minutes. Read before or immediately after each coding session.

**The standard:** this is not reading to skim. Every module has a geometric object at its
centre, and the test of understanding is whether you can *draw* it. See
[`geometric-lens.md`](./geometric-lens.md) — it sets what "understood" means here, and the
plan is subordinate to it.

---

## How This Folder Is Organised

| File | Contents |
|---|---|
| [`library.md`](./library.md) | The ten texts, what each is for, and the citation verification status |
| [`shelf-audit.md`](./shelf-audit.md) | Two-stage checklist for verifying the library and settling disputed citations |
| [`plan.md`](./plan.md) | Master reading plan — phase-by-phase, with per-module guides |
| [`geometric-lens.md`](./geometric-lens.md) | **How to read it.** The geometric object at the centre of each module, the physics reading of it, the "draw this" checkpoints, and where texts go algebra-heavy |
| [`notes/`](./notes/) | One note file per module, following the three-question protocol |
| `texts/` | Local PDFs (MacKay, ESL, Prince, J&M). **Gitignored** — see [`texts/README.md`](./texts/README.md) for fetch commands |

The theory documents in [`../`](../) are a different thing and serve a different reader.
Those explain the architectures to anyone reading the code. These explain the *reading* to
me.

---

## Reading Notes Protocol

Each session gets three questions. This is deliberately more durable than comprehensive
notes — comprehensive notes do not get written.

1. **What did I read?** — Book, chapter, pages. One sentence on the main argument.
2. **What connects to the code?** — One specific thing in the reading that maps to a
   method, class, or design decision in NeuralAscent. Write the connection explicitly.
3. **What question did it open?** — The best reading sessions produce questions, not just
   answers. Write the question down. Chase it next session.

See [`notes/TEMPLATE.md`](./notes/TEMPLATE.md).

---

## Current Status

The plan covers the full six-module arc. The implementation does not yet.

| Phase | Module | Implementation | Reading notes |
|---|---|---|---|
| 0 | Pre-flight foundations | `Core/` complete | Not started |
| 1 | Perceptron | Complete | Not started |
| 2 | MLP | Scaffold only | Not started |
| 3 | RNN | Scaffold only | Not started |
| 4 | CNN | Scaffold only | Not started |
| 5 | Attention | Scaffold only | Not started |
| 6 | Transformer | Scaffold only | Not started |

Empty note files are the honest state of work not yet done. They are committed as empty
rather than omitted so the shape of the plan is visible from the start.

**A known consequence:** the parallel model can only be honoured for phases 0–1 today.
Phases 2–6 have no implementation to read alongside. Reading ahead is possible but breaks
the premise the plan is built on.

---

## Citation Audit — Complete

Every chapter assignment in the plan was checked against the actual text, either on the
shelf or in the free electronic edition. **Ten disputes, all resolved. Eight were wrong.**

The corrections are applied in [`plan.md`](./plan.md) with the original wording struck
through rather than deleted — the errors are part of the record. Full findings in
[`library.md`](./library.md#citation-verification); method and results in
[`shelf-audit.md`](./shelf-audit.md).

Both coverage gaps the audit opened are now closed — one from books already on the list,
one by adding Prince (2023):

- ~~**Phase 2 has no numerical-analysis source.**~~ **Closed** — GBC Ch. 4 and Ch. 8, two
  chapters the plan never assigned from a book it already used.
- ~~**Module 6 rests on one survey chapter.**~~ **Closed** — Prince, *Understanding Deep
  Learning* (2023) Ch. 12 is now module 6's primary text, verified section by section. Its
  Ch. 11 and Ch. 20 also supply two prerequisites the plan referenced but never sourced.
