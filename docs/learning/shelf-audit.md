# Shelf Audit

A two-stage check to put the reading plan's citations on solid ground.

**Stage 1** confirms the books are on the shelf and identifies *which edition*.
**Stage 2** asks one question per disputed book — enough to settle the citation.

---

## ✅ Complete — 2026-09-03

**All ten disputes resolved.** Four settled from the free electronic editions (MacKay, ESL,
GBC), six from the shelf (V1, V4, V5, V6, V9, V10), plus the Russell & Norvig edition check.

**Every prediction in this audit was confirmed.** Eight citations were wrong; two —
MacKay Ch. 2–4 and GBC §12.4.5.1 — were right.

| | Verdict |
|---|---|
| **V1** Nilsson Ch. 4–5 | ❌ Void. *Principles of AI* (1980) Ch. 4 *Predicate Calculus*, Ch. 5 *Resolution Refutation*. *Learning Machines* (1965) not owned. |
| **V2** GBC Ch. 12 + "Epilogue" | ❌ No Epilogue; book ends Ch. 20. Zero Transformer content. |
| **V3** MacKay Ch. 41–43 | ❌ 42–43 are Hopfield/Boltzmann. → **Ch. 39–41 + 44**, plus Ch. 28. |
| **V4** HKP Ch. 1 | ❌ Ch. 1 is the introduction. → **Ch. 5 *Simple Perceptrons*** (1991 ed.). |
| **V5** Pierce Ch. 1–4 | ❌ Entropy is **Ch. 5**. → **Ch. 3–5** (Dover 1980). |
| **V6** Pierce Ch. 8–10 | ❌ → **Ch. 6–8**: *Language and Meaning*, *Efficient Encoding*, *The Noisy Channel*. |
| **V7** GBC §10.7 | ❌ §10.7 is *Long-Term Dependencies*; ESNs are **§10.8**. |
| **V8** ESL Ch. 18 | ❌ Chapter is *p ≫ N*; the overparameterisation framing is not in it. |
| **V9** Schneider & Barker Ch. 1–4 | ❌ Ch. 1–4 end at *Determinants*; **eigenvalues are Ch. 6**. → **Ch. 1–6**. |
| **V10** Cohen Ch. 3 | ❌ Ch. 3 is *Series*, not gradient methods. **No replacement found.** |
| — Russell & Norvig | ✅ 4th ed. confirmed: Ch. 21 / 24 / 25 as expected. |
| — Goodfellow print copy | ✅ Owned (2016). Does not change V2 — the book has no Transformer content in any format. |

**Two residual questions**, neither blocking:

1. **Cohen** — does *any* chapter cover optimisation or gradient descent? If not, phase 2
   permanently loses its numerical-analysis angle.
2. **Schneider & Barker Ch. 5** — title not recorded. Cosmetic; the corrected Ch. 1–6 range
   spans it either way.

Results are folded into [`library.md`](./library.md) and [`plan.md`](./plan.md). This file
is retained as the record of how the citations were checked.

---

## Stage 1 — Do I have it, and which edition?

Walk the shelf. Tick the box, note the edition. Edition matters more than title here:
chapter numbering moves between editions, which is what most of the disputes hinge on.

| ☐ | Author / Title | Edition to look for | How to tell at a glance |
|---|---|---|---|
| ☐ | **Hertz, Krogh & Palmer** — *Introduction to the Theory of Neural Computation* | Addison-Wesley, 1991 | Santa Fe Institute Studies series, Vol. I. Only one edition — low risk. |
| ✅ | **Goodfellow, Bengio & Courville** — *Deep Learning* | MIT Press, 2016 | **HTML edition verified online** (no PDF exists by contract). One edition only. |
| ✅ | **Hastie, Tibshirani & Friedman** — *ESL* | Springer, **2nd ed. 2009** | **PDF obtained** (12th printing, 2017) — newer than most print copies. Shelf copy still worth confirming. |
| ✅ | **Nilsson** — *Principles of Artificial Intelligence* | Tioga, **1980** — confirmed | ✅ **Resolved.** *Learning Machines* (1965) is **not** owned; that is the book the plan actually needed. |
| ☐ | **Pierce** — *An Introduction to Information Theory: Symbols, Signals and Noise* | Dover, **2nd revised ed. 1980** | The 1961 Harper original has different chapter numbering. |
| ☐ | **Russell & Norvig** — *Artificial Intelligence: A Modern Approach* | Pearson, **4th ed. 2021** | 3rd ed. (2010) has no deep learning chapters at all. Spine colour differs. |
| ☐ | **Schneider & Barker** — *Matrices and Linear Algebra* — **prep** | Dover, 2nd ed. 1989 (orig. Holt, 1968) | Thin Dover paperback. |
| ☐ | **Cohen** — *Numerical Approximation Methods* — **prep** | Springer, 2011 | Subtitle is the "π ≈ 355/113" one. |
| ☐ | **Rosen** — *Discrete Mathematics and Its Applications* — **prep** | Any edition (7th/8th typical) | Large red hardback. Used in zero phases — ownership only. |
| ✅ | **MacKay** — *Information Theory, Inference, and Learning Algorithms* | CUP, 2003 | **Confirmed.** PDF in `texts/`, verified against the plan. |

---

## Stage 2 — One question per book

**Four** questions remaining across three books, plus one edition check. (Questions 1 and 2
are resolved and kept below as a record.) Each is a table-of-contents
lookup — nothing needs reading. **Expected** is my prediction; contradicting it is the
useful outcome.

---

### 1 · Nilsson — `V1` · ✅ **RESOLVED — 2026-09-02**

**Owned:** *Principles of Artificial Intelligence*, Nils J. Nilsson, Tioga, **1980**.
**Ch. 4** = *The Predicate Calculus in AI* · **Ch. 5** = *Resolution Refutation Systems*.

**Verdict:** confirmed void. No perceptron content. The convergence proof the plan
described is in Nilsson's *Learning Machines* (1965) / *The Mathematical Foundations of
Learning Machines* (1990) — **not owned**. Module 1's primary reading, and phase 0's
"Nilsson Ch. 1–2", are both struck.

**Consequence:** `V4` is now the critical path. See the replacement decision in
[`plan.md`](./plan.md) under Phase 1.

---

### 2 · Hertz, Krogh & Palmer — `V4` · ✅ **RESOLVED — 2026-09-02**

**Owned:** *Introduction to the Theory of Neural Computation*, Hertz, Krogh & Palmer,
Addison-Wesley, **1991** (copyright confirmed). **Ch. 5 = *Simple Perceptrons***.

**Verdict:** the plan's Ch. 1 was the introduction. All three module-1 citations move
**Ch. 1 → Ch. 5**. Phase 0's separate "HKP Ch. 1" assignment stays correct.

**Consequence:** module 1 has a primary text again. Nilsson's removal (V1) is covered.

---

### 3 · Pierce — `V5` **and** `V6` · *one lookup settles both*

**John R. Pierce**
*An Introduction to Information Theory: Symbols, Signals and Noise*
Dover, **2nd revised ed., 1980** · standard Dover paperback.
Originally *Symbols, Signals and Noise: The Nature and Process of Communication*,
Harper & Brothers, 1961.

**Ask** → Titles of **Ch. 5, 6, 7, 8**.

**Expected** → 5 *Entropy* · 6 *Language and Meaning* · 7 *Efficient Encoding* ·
8 *The Noisy Channel*.

**Decides** → Two disputes at once. **V5**: module 5 is assigned Ch. 1–4 for entropy, but
entropy looks to be Ch. 5. **V6**: module 6 is assigned Ch. 8–10 for redundancy, but the
"language modelling is compression" material looks to be Ch. 6–7.

⚠︎ **Edition matters here.** If it's the 1961 Harper hardback rather than the Dover 2nd,
the numbering differs — say which one you have.

---

### 4 · Schneider & Barker — `V9` · **prep**

**Hans Schneider & George Phillip Barker**
*Matrices and Linear Algebra*
Dover, **2nd ed., 1989** · thin Dover paperback.
Originally Holt, Rinehart & Winston, 1968.

**Ask** → Which chapter **first introduces eigenvalues**? And what are **Ch. 1–4** titled?

**Expected** → Eigenvalues at **Ch. 6 or later** — they depend on determinants and the
characteristic polynomial, which usually come first.

**Decides** → Phase 0 assigns "Ch. 1–4 — vectors, matrices, eigenvalues, rank". If
eigenvalues arrive later, the range stops short of the material it claims to cover, and
phase 0 needs extending — which also matters for phase 3, where the vanishing gradient is
posed as an eigenvalue problem.

---

### 5 · Cohen — `V10` · **prep**

**Harold Cohen**
*Numerical Approximation Methods*
Springer, New York, **2011** · the edition whose subtitle features π ≈ 355/113.

**Ask** → Is there a chapter on **optimisation, gradient descent, or steepest descent**?
Which number? And what is **Ch. 3** titled?

**Expected** → Suspected **no such chapter**. The book appears to be root-finding,
quadrature, function approximation and ODEs — approximation rather than optimisation.

**Decides** → Phase 2 assigns "Cohen Ch. 3 (gradient methods)" as the tool for diagnosing
why training loss oscillates or converges slowly. If there is no optimisation chapter, that
exercise has no source and phase 2 loses its numerical-analysis angle entirely.

---

### 6 · Russell & Norvig — sanity check · **now load-bearing**

**Stuart J. Russell & Peter Norvig**
*Artificial Intelligence: A Modern Approach*, **4th ed.**, Pearson, **2021**
Very large hardback. The 3rd ed. (2010) has **no deep learning chapters at all**.

**Ask** → Confirm it is the 4th ed., and that **Ch. 21**, **Ch. 24**, **Ch. 25** are
*Deep Learning*, *Deep Learning for Natural Language Processing*, and *Computer Vision*.

**Expected** → As stated.

**Decides** → Low risk, but this stopped being optional. With GBC struck from module 6
(V2), **R&N Ch. 24 is now the only text in the library that covers the Transformer.** If
this is the 3rd edition, module 6 has no book behind it whatsoever.

---

### Already settled — no shelf needed

| ID | Result |
|---|---|
| **V2** | ✅ **Confirmed wrong.** GBC runs Ch. 1–20, no Epilogue; Ch. 12 has zero mentions of Transformer/self-attention/Vaswani. Module 6 has no GBC source. |
| **V3** | ✅ **Confirmed wrong.** MacKay Ch. 42–43 are Hopfield/Boltzmann. Correct range: Ch. 39–41 + 44, plus Ch. 28. |
| **V7** | ✅ **Confirmed wrong.** GBC §10.7 is *The Challenge of Long-Term Dependencies*; Echo State Networks is §10.8. |
| **V8** | ✅ **Confirmed wrong.** ESL Ch. 18 is *High-Dimensional Problems: p ≫ N*, with zero mentions of double descent or overparameterisation. |
| — | ✅ MacKay Ch. 2–4 and GBC §12.4.5.1 both **verified correct**. |

Four of ten resolved from the free electronic editions. Details in
[`library.md`](./library.md#citation-verification).

---

## New items raised by the prep books

The original audit covered the six "core" and "historical" texts but skipped the three math
references. Adding them surfaced two suspected problems — both **unverified**, both listed
above:

- **V9 — Schneider & Barker "Ch. 1–4 … eigenvalues, rank."** Most linear algebra texts
  introduce eigenvalues well after chapter 4 — typically 6 or later, since they depend on
  determinants and characteristic polynomials first. If that holds here, phase 0's range is
  too short and stops before the material the plan says it covers. Confidence this is a
  real problem: moderate.
- **V10 — Cohen "Ch. 3 (gradient methods)."** *Numerical Approximation Methods* is, on its
  face, about approximating numbers, functions, integrals, and differential equations —
  root-finding and quadrature rather than optimisation. Gradient descent may not be a
  chapter in it at all. If not, phase 2 loses its numerical-analysis angle and the
  "diagnose why your loss oscillates" exercise has no source. Confidence this is a real
  problem: moderate.

Rosen raises nothing — it appears in no phase, so there is nothing to verify beyond
ownership.

---

## Recording results

Fill in and hand back. Answers fold into `library.md`, and the matching `⚠︎[Vn]` markers
come out of `plan.md`.

```
V1   ✅ DONE — Principles of AI (1980).
       Ch.4 = The Predicate Calculus in AI
       Ch.5 = Resolution Refutation Systems
       Verdict: void. Learning Machines (1965) not owned.

V4   ✅ DONE — HKP (1991), Ch.5 = Simple Perceptrons

V5   Pierce — edition (Dover 1980 / Harper 1961) ........
V6   Pierce — Ch.5 = ....................................
                Ch.6 = ....................................
                Ch.7 = ....................................
                Ch.8 = ....................................

V9   Schneider & Barker — eigenvalues first appear in Ch. ....
                          Ch. 1–4 titles = ..............

V10  Cohen — optimisation/gradient chapter? (y/n, which) ....
             Ch. 3 title = ..............................

--   Russell & Norvig — edition ........................
                        Ch.21 / 24 / 25 as expected? ....
```
