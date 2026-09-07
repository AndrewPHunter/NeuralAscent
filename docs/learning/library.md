# The Library

Ten texts assessed for this arc.

---

## Core Trilogy — Read Cover to Cover (for the relevant modules)

| Text | Role |
|---|---|
| **Hertz, Krogh & Palmer (1991)** — *Introduction to the Theory of Neural Computation* | The statistical physics framing of neural networks. Unusual and durable. Primary reference for modules 0–3, and the theoretical backbone for understanding energy landscapes, convergence, and generalisation. |
| **Goodfellow, Bengio & Courville (2016)** — *Deep Learning* | The modern engineering bible. Chapters 6–12 map closely to the NeuralAscent module sequence. The most directly applicable text to the implementation work. **Note its horizon:** published 2016, so it predates the Transformer entirely. |
| **Hastie, Tibshirani & Friedman (2009)** — *The Elements of Statistical Learning* | ESL. Treats neural networks as statistical models — a different and more durable perspective than most ML literature. Essential for understanding what generalisation actually means. |

## Historical Depth — Targeted Reading

| Text | Role |
|---|---|
| **Nilsson (1980)** — *Principles of Artificial Intelligence* | ❌ **Removed from the reading plan** (see **V1**): this book is search, predicate calculus, resolution, and planning — it has no perceptron content, and the convergence proof attributed to it is in Nilsson's *Learning Machines* (1965), which is not in the library. **Retained for context, not assignment:** as a 1980 snapshot it is a primary source on what mainstream AI was doing *during* the neural winter that Minsky & Papert triggered — useful background for the arc's narrative between modules 1 and 2, but not module reading. |
| **Pierce (1980)** — *An Introduction to Information Theory: Symbols, Signals and Noise* | Shannon's framework made readable. Pull this off the shelf for module 5 (Attention). Entropy, mutual information, and channel capacity are the theoretical substrate of softmax, cross-entropy loss, and why attention weights mean what they mean. |
| **Russell & Norvig (2021)** — *AI: A Modern Approach*, 4th ed. | ✅ **Edition and chapters verified**: Ch. 21 *Deep Learning*, Ch. 24 *Deep Learning for Natural Language Processing*, Ch. 25 *Computer Vision*. Breadth over depth. Most useful for modules 4–6. **Ch. 24 is the only text in this library that covers the Transformer at all** — with GBC struck (V2), it carries module 6 alone. |

## Math Reference — Use as Needed

| Text | Role |
|---|---|
| **Schneider & Barker** — *Matrices and Linear Algebra* | Keep open during module 0 and the early MLP work. The eigenvalue and vector space treatment clarifies what weight matrices are geometrically doing to input space. Also relevant to module 3, where the vanishing gradient is posed as an eigenvalue problem. |
| **Cohen** — *Numerical Approximation Methods* | More relevant than it looks. Gradient descent is a numerical method. Convergence properties, learning rate sensitivity, and oscillation are topics numerical analysis treats rigorously. Pull this during the MLP optimisation work. |
| **Rosen** — *Discrete Mathematics and Its Applications* | Least directly applicable to this arc. Combinatorics and graph theory are background rather than foreground here. Reference only — it appears in no phase of the reading plan. |
| **MacKay (2003)** — *Information Theory, Inference, and Learning Algorithms* | Bridges information theory, Bayesian inference, and neural networks in a single text. Supports MLP (Bayesian weight decay) and Attention (entropy framing). Complements Pierce directly: Pierce for intuition and history, MacKay for precision. |

---

## Obtaining the Texts

**MacKay — free and author-authorised.** David MacKay made the full book available at no
cost from his own site. Download:

```bash
curl -o docs/learning/texts/mackay-itila.pdf http://www.inference.org.uk/itprnn/book.pdf
```

- Book homepage: <https://www.inference.org.uk/mackay/itila/>
- Direct PDF: <http://www.inference.org.uk/itprnn/book.pdf> (11.7 MB)
- SHA-256: `868adc5f0ef6630366b122d88d691acfbe8339978b4ec3f38fca5e231f135791`

The PDF lands in `docs/learning/texts/`, which is **gitignored**. The book is free to
download but is not mine to redistribute, so the repo carries the link and not the file.
Cambridge University Press sells the print edition; the on-screen copy is permitted by the
copyright notice on every page.

**ESL — free and publisher-sanctioned.** Springer allows the authors to keep the book on
the web. The current file is the 2nd ed., **12th printing with corrections and table of
contents (Jan 2017)** — newer than most print copies.

```bash
curl -L -o docs/learning/texts/esl-2nd-print12.pdf \
  "https://drive.google.com/uc?export=download&id=1--Wo5Hcl2y_v3DL-tGgcJHRPdtjiVYjS"
```

- Download page: <https://hastie.su.domains/ElemStatLearn/download.html>
- 13.4 MB, 764 pp. · SHA-256 `8d098d65cf53925ba0fc13a52a2790d48a32433223cbd876d0a527cd1afe2e0f`

**GBC — HTML only, no PDF exists.** The authors' FAQ states their contract with MIT Press
forbids distributing "too easily copied electronic formats", and that the HTML edition is
"a sort of weak DRM required by our contract". Unofficial PDFs circulate; they are
unauthorised redistribution and are not used here.

- Read online: <https://www.deeplearningbook.org/>
- A `.webloc` shortcut sits in `texts/` alongside the PDFs.

See [`texts/README.md`](./texts/README.md) for the fetch commands in one place.

The remaining seven texts are print. No links.

---

## Later Additions — Surfaced After the Original Assessment

The original plan assessed ten texts. These were found on the wider shelf afterwards, when
the audit exposed gaps. None was in the plan; two of them are better than what they fill.

| Text | Where it lands |
|---|---|
| **Boyce & DiPrima** — *Elementary Differential Equations and Boundary Value Problems* | **Phase 3.** Not an optimisation book — a *dynamical systems* book, which is what module 3 actually needs. Systems of first-order linear equations give eigenvalue/eigenvector classification of equilibria; the nonlinear stability material gives phase portraits, fixed points, and attractors. This is the substrate under HKP Ch. 7's "recurrent networks as dynamical systems" and under the module-3 key question, *"the vanishing gradient is an eigenvalue problem."* The plan assigned nothing here. |
| **Larson** — *Elementary Linear Algebra* | **Phase 0 and phase 3.** A second, more pedagogical linear algebra text alongside the terse Schneider & Barker Dover. Carries linear transformations and eigenvalues/diagonalization with worked examples. Useful as the approachable route into phase 0, and as the eigenvalue reference in phase 3 next to DiPrima. ✅ **Ch. 7 *Eigenvalues and Eigenvectors* confirmed** — two chapters later than Schneider & Barker's Ch. 6, so cite the two books separately rather than interchangeably. |
| **Dielman** — *Applied Regression Analysis for Business and Economics*, 4th ed. | **Phase 2, supporting.** Its multicollinearity material is the conditioning half of Gap A made concrete — why badly scaled or correlated inputs wreck a fitted model. Reinforces ESL Ch. 11's "neural networks as statistical models" framing. **Caveat:** business-oriented regression texts do not reliably cover ridge regression; do not count on it for the weight-decay bridge. Use ESL §3.4 for that. |

### Also missed: chapters in books already assigned

The audit's clearest pattern is that the plan **under-uses the books it already names.** Three
directly relevant chapters were never assigned:

| | |
|---|---|
| **ESL §3.4 — *Shrinkage Methods*** ✅ verified | §3.4.1 *Ridge Regression* derives ridge as the **mode of the posterior under a Gaussian prior** (βⱼ ~ N(0, τ²)) — the same L2-equals-Gaussian-prior equivalence MacKay Ch. 41/44 makes, reached from the statistics side. This is the missing bridge between the plan's statistical and Bayesian framings of weight decay, and it sits in a book already on the shelf and already assigned two other chapters. |
| **GBC Ch. 4 — *Numerical Computation*** | Conditioning, poor conditioning, overflow/underflow, gradient-based optimisation. |
| **GBC Ch. 8 — *Optimization for Training Deep Models*** | Ill-conditioning, local minima, plateaus, saddle points, cliffs, learning-rate schedules. |

---

### Added to close Gap B

| Text | Role |
|---|---|
| **Prince (2023)** — *Understanding Deep Learning*, MIT Press | **Module 6 primary.** Free versioned PDF (pinned at **v5.0.3**). Ch. 12 derives the Transformer properly; Ch. 11 supplies the batch-norm/residual prerequisite; Ch. 20 supplies the overparameterisation argument. The only text in the library written after the architecture existed *and* aimed at derivation rather than survey. |
| **Jurafsky & Martin (3rd ed. draft)** — *Speech and Language Processing* | **Module 5–6 supporting.** Ch. 7 *Transformers and Pretraining*, Ch. 5 *Embeddings*, Ch. 14 *RNNs and LSTMs*. ⚠︎ **Living draft — chapters are renumbered between releases.** The authors merged the former Ch. 8 (Transformers) into Ch. 7. Cite the dated file (`ed3book_aug26.pdf`), never "the current draft". |

---

### Geometric Lens — Sources

Added to support a geometry-first reading. See [`geometric-lens.md`](./geometric-lens.md).

| Text | Role |
|---|---|
| **Bronstein, Bruna, Cohen & Veličković (2021)** — *Geometric Deep Learning: Grids, Groups, Graphs, Geodesics, and Gauges* | **The unifying frame.** ✅ Verified: §3 *Geometric Priors* (symmetries, invariance), §5.1 CNNs, §5.2 group-equivariant CNNs, §5.4 *Deep Sets, Transformers*, §5.7 RNNs. Derives the arc's architectures from symmetry groups. Free (arXiv). |
| **Blum, Hopcroft & Kannan** — *Foundations of Data Science* | **Module 5.** ✅ Verified Ch. 2: *The Geometry of High Dimensions*, *Properties of the Unit Ball*, *Gaussians in High Dimension*, *Johnson–Lindenstrauss*. Concentration of measure — why `√d` exists. Free (Cornell). |
| **3Blue1Brown** — *Essence of Linear Algebra* | **Phase 0.** Free video. The geometric antidote to Schneider & Barker's formalism. |
| **Olah** — *Neural Networks, Manifolds, and Topology* | **Module 2.** Free. The clearest statement that hidden layers warp space, and that warping has topological limits. |
| **Elhage et al.** — *A Mathematical Framework for Transformer Circuits* | **Module 6.** Free. The residual stream as a vector space; heads reading and writing subspaces. |

### Energy-Based Reading

| Paper | Role |
|---|---|
| **Ramsauer et al. (2020)** — *Hopfield Networks is All You Need* | **Modules 5–6.** ✅ Verified: "The new update rule is equivalent to the attention mechanism used in transformers." Attention is one step of energy descent in a continuous Hopfield network, with global, metastable, and single-pattern attractors. The energy-based reading of the architecture — attractors are literal here, not analogy. |
| **Song et al. (2021)** — *Score-Based Generative Modeling through SDEs* | **Module 6.** The probability-flow ODE computes log-likelihood as a **line integral** — the path formulation in deployed use, for when the partition function is not enumerable. |
| **Lou et al. (2023)** — *Score Entropy Discrete Diffusion* | **Module 6.** Path-based generation applied to discrete language — the active frontier where the line-integral route reaches token generation. |

### From the Wider Shelf — Geometric and Foundational

Surfaced when the arc was re-framed around geometry. Chapter references are **unverified**
— see the [verification queue](./geometric-lens.md#verification-queue).

| Text | Role |
|---|---|
| **Strogatz (2nd ed. 2015)** — *Nonlinear Dynamics and Chaos* | **Module 3 primary.** ✅ **Ch. 10 *One-Dimensional Maps*** is the priority — an RNN recurrence is a discrete-time **map**, whose fixed-point stability condition `\|λ\| < 1` *is* the vanishing-gradient condition. **Ch. 5 *Linear Systems*** gives eigenvalue classification of fixed points. Geometric throughout; displaces DiPrima as primary. |
| **Munkres (2nd ed.)** — *Topology* | ✅ **Ch. 3 *Connectedness and Compactness*** · **Ch. 7 function spaces** · **Part II opens with the fundamental group**. |
| ~~**Munkres** — *Topology*~~ *(detail)* | **Module 2.** Continuity and homeomorphism give the vocabulary; **connectedness** is the invariant behind Olah's argument that warping has limits; **compactness** is what makes universal approximation state at all; function spaces and Ascoli make it a topology result. The fundamental group is where "linked rings cannot be unlinked" becomes rigorous. |
| **Lee (2nd ed. 2012)** — *Introduction to Smooth Manifolds* | **Module 2, structural.** ✅ **Ch. 3 *Tangent Vectors*** · **Ch. 11 *The Cotangent Bundle*** · **Ch. 13 *Riemannian Metrics***. Tangent spaces, differentials, and the cotangent bundle are the correct statement of what backprop computes: reverse-mode autodiff is the **pullback of a covector**. Also supplies the metric/gradient distinction that turns phase 2's optimisation material into one idea instead of a list. |
| **Lee** — *Introduction to Topological Manifolds* | **Optional.** An alternative route to the fundamental group and covering spaces, often better motivated than Munkres Part II. |
| **Royden & Fitzpatrick (5th ed.)** — *Real Analysis* | **Module 2, narrow.** ✅ **Ch. 18 Hahn–Banach.** Riesz is **distributed through the book** rather than in one chapter — the version Cybenko's proof needs is the representation of `C(X)*` as measures, not the Hilbert-space or `Lᵖ`-dual forms. One targeted use; measure theory otherwise does not earn a place in this arc. |

---

## Coverage Gaps — What the Arc Still Needs

Two capabilities the plan requires and the ten assessed texts do not supply. Stated as
requirements rather than titles, so they can be checked against the wider shelf.

### Gap A — Optimisation and training dynamics (phase 2)

Cohen Ch. 3 was the plan's only source here and is void (**V10**). What phase 2 actually
needs is the vocabulary to answer *"my training loss is oscillating — why?"*:

- Convergence rates of iterative methods; what determines them
- Step-size / learning-rate sensitivity — why too large oscillates or diverges
- **Condition number** and ill-conditioning — why badly scaled problems zigzag
- Local minima, saddle points, plateaus, cliffs
- First-order vs second-order methods (Newton, quasi-Newton) and why deep learning uses
  first-order anyway
- Stopping criteria and line search

**Which shelf:** numerical analysis / numerical methods, numerical optimisation, convex
optimisation, or scientific computing. A linear algebra text covering condition number and
conditioning also counts for part of it.

**Partially closed.** Dielman supplies the conditioning half concretely (multicollinearity),
and ESL §3.4 supplies the shrinkage/regularisation half. **The core is still open**: none of
these covers *iterative* optimisation dynamics — learning-rate sensitivity, convergence
rates, why loss oscillates or diverges. Regression solves least squares in closed form.

**Already in hand — possibly sufficient.** The plan assigns GBC Ch. 6, 7, 9, 10 and 12, but
**never assigns Ch. 4 or Ch. 8**, both of which are directly on point:

- **GBC Ch. 4 — *Numerical Computation***: conditioning, poor conditioning, overflow and
  underflow, gradient-based optimisation
- **GBC Ch. 8 — *Optimization for Training Deep Models***: ill-conditioning, local minima,
  plateaus and saddle points, cliffs, learning-rate schedules

That omission is independent of the Cohen error and worth fixing regardless.

### Gap B — Transformer coverage (module 6) · ✅ **CLOSED**

**Prince, *Understanding Deep Learning* (MIT Press, 2023), Ch. 12 — verified against the
PDF.** Every requirement below is met:

| Requirement | Where |
|---|---|
| Self-attention derived | §12.2 *Dot-product self-attention* |
| Multi-head, positional encoding, √d scaling | §12.3 *Extensions to dot-product self-attention* |
| Layer norm and residuals in the block | §12.4 *Transformer layers* |
| Encoder / decoder / encoder-decoder as composed units | §12.6 BERT · §12.7 GPT3 · §12.8 machine translation |
| Scaling behaviour | §12.9 *Transformers for long sequences* |

**Jurafsky & Martin, *Speech and Language Processing* 3rd ed., Ch. 7 *Transformers and
Pretraining*** joins as the language-side complement (Ch. 5 *Embeddings*, Ch. 14 *RNNs and
LSTMs* also map onto the arc).

**Prince also closes three unrelated holes the audit opened:**

| Hole | Prince |
|---|---|
| **B2** — module 6 referenced "batch norm from CNN" with no antecedent anywhere in the repo | **§11.4 *Batch normalization***, alongside §11.2 residual connections — the missing prerequisite for module 6's layer-norm discussion |
| **V8** — the overparameterisation argument wrongly attributed to ESL Ch. 18 | **§20.4 *Factors that determine generalization*** and **§20.5 *Do we need so many parameters?*** — the argument the plan wanted, in a book that actually makes it |
| Phase 3 exploding gradients | **§11.3 *Exploding gradients in residual networks*** |

Prince additionally covers Ch. 6 *Fitting models*, Ch. 7 *Gradients and initialization*,
Ch. 9 *Regularization*, and Ch. 10 *Convolutional networks* — overlapping phases 2 and 4.

---

#### Original requirement (for the record)

### Gap B — Transformer coverage (module 6)

With GBC struck (**V2**), R&N Ch. 24 is the only Transformer coverage among the ten, and it
is a survey chapter. What module 6 needs from a text rather than from the paper:

- Self-attention derived, not just described
- Multi-head attention — why multiple heads, what they buy
- Positional encoding — the sinusoidal scheme and its alternatives
- Layer normalisation and residual connections, and why they matter for trainability
- The encoder/decoder block as a composed unit
- Scaling behaviour

**Which shelf:** any deep learning or NLP text published **2019 or later**. Anything from
2016 or earlier cannot have it.

**Free and verifiable**, if nothing on the shelf fits: Prince, *Understanding Deep Learning*
(MIT Press, 2023) and Jurafsky & Martin, *Speech and Language Processing* 3rd ed. — both
released free by their authors, both with dedicated transformer chapters.

---

## Citation Verification

The chapter assignments in [`plan.md`](./plan.md) were audited against the contents of each
text — on the shelf, or in the free electronic edition where one exists. **All ten disputes
are resolved.** Eight assignments were wrong; the corrections are applied in `plan.md` with
the original struck through rather than deleted.

| ID | Plan's assignment | Issue | Status |
|---|---|---|---|
| **V1** | Nilsson, *Principles of AI*, Ch. 4–5 — "linear threshold units, perceptron convergence" | **Confirmed wrong.** Verified on the shelf: the 1980 *Principles of AI* is the copy owned, and **Ch. 4 is *The Predicate Calculus in AI*, Ch. 5 is *Resolution Refutation Systems*** — no perceptron content whatsoever. The convergence proof described belongs to Nilsson's ***Learning Machines*** (1965) / *The Mathematical Foundations of Learning Machines* (1990), which is **not** in the library. Module 1's designated primary reading does not exist. Phase 0's "Nilsson Ch. 1–2" is void for the same reason. | ✅ **Resolved** — replacement needed |
| **V2** | GBC Ch. 12 + "Epilogue" — Transformer, scaling behaviour | **Confirmed wrong.** Verified against the free HTML edition: the book runs Ch. 1–20, ending at *Deep Generative Models* → Bibliography. **There is no Epilogue.** Ch. 12 is *Applications*, and it contains **zero** occurrences of "Transformer", "self-attention", or "Vaswani" — GBC (2016) predates the architecture. Attention appears only at **§12.4.5.1** *Using an Attention Mechanism and Aligning Pieces of Data*, inside §12.4.5 *Neural Machine Translation*. | ✅ **Resolved** — module 6 has no GBC source |
| **V3** | MacKay Ch. 41–43 — Bayesian weight decay, evidence framework | **Confirmed wrong.** Verified against the PDF: Ch. 41 *Learning as Inference* (p.492) ✓, but Ch. 42 is *Hopfield Networks* (p.505) and Ch. 43 is *Boltzmann Machines* (p.522). The index places "weight decay" at pp. 479 and 529 — Ch. 39 and Ch. 44. Correct range: **Ch. 39–41 + 44**, with **Ch. 28** (*Model Comparison and Occam's Razor*, p.343) for the evidence framework. | ✅ **Resolved** |
| **V4** | Hertz/Krogh/Palmer Ch. 1 — "geometric interpretation, linear separability" (module 1, cited 3×) | **Confirmed wrong.** Verified on the shelf (Addison-Wesley, 1991): **Ch. 5 is *Simple Perceptrons***. Ch. 1 is the introduction — correct for phase 0's framing assignment, wrong for module 1's perceptron material. All three module-1 citations move **Ch. 1 → Ch. 5**. | ✅ **Resolved** — module 1 has a primary text again |
| **V5** | Pierce Ch. 1–4 — "entropy, mutual information" | **Confirmed wrong.** Verified on the shelf (Dover, 1980): **Ch. 5 is *Entropy***. Ch. 1–4 stop short of it. Corrected range for module 5: **Ch. 3–5** (*A Mathematical Model*, *Encoding and Binary Digits*, *Entropy*). | ✅ **Resolved** |
| **V6** | Pierce Ch. 8–10 — "channel capacity, redundancy & coding" | **Confirmed wrong.** Verified (Dover, 1980): **Ch. 6 *Language and Meaning*, Ch. 7 *Efficient Encoding*, Ch. 8 *The Noisy Channel***. Ch. 8 was right for capacity; 9–10 were not the redundancy material. Corrected range for module 6: **Ch. 6–8** — a markedly better fit for "language modelling is compression" than the original. | ✅ **Resolved** — corrected range is *better* than the original |
| **V7** | GBC §10.7 — echo state network | **Confirmed wrong.** Verified against the HTML edition: **§10.7 is *The Challenge of Long-Term Dependencies*; §10.8 is *Echo State Networks***. (§10.9 *Leaky Units…*, §10.10 *The Long Short-Term Memory and Other Gated RNNs*, §10.11 *Optimization for Long-Term Dependencies*.) Off by one. | ✅ **Resolved** — cite §10.8 |
| **V8** | ESL Ch. 18 — "why overparameterisation doesn't cause overfitting" | **Confirmed wrong.** Verified against the PDF: Ch. 18 is *High-Dimensional Problems: p ≫ N* (p.649). Its sections are diagonal LDA and nearest shrunken centroids, quadratic- and L1-regularised classifiers, classification without features, and high-dimensional regression. The chapter contains **zero** occurrences of "double descent", "overparameter", or "interpolat" — ESL (2009) predates that literature entirely. Worth reading; it does not make the argument attributed to it. | ✅ **Resolved** |
| **V9** | Schneider & Barker Ch. 1–4 — "vectors, matrices, eigenvalues, rank" (**prep**) | **Confirmed wrong.** Verified on the shelf: **Ch. 1 *Algebra of Matrices*, 2 *Linear Equations*, 3 *Vector Spaces*, 4 *Determinants* — eigenvalues are Ch. 6.** The plan's range stops two chapters short of material it explicitly claims to cover. Corrected: **Ch. 1–6**. (Ch. 5's title was not recorded; determinants in Ch. 4 are the prerequisite for Ch. 6, so the run is coherent.) | ✅ **Resolved** |
| **V10** | Cohen Ch. 3 — "gradient methods" (**prep**) | **Confirmed wrong.** Verified on the shelf: **Ch. 3 is *Series***, not gradient methods. The citation is void. Series expansions do underpin optimisation theory (Taylor expansion sits behind gradient and Newton methods), so the chapter is not irrelevant — but it is not what the plan claimed, and it does not supply the "diagnose why your loss oscillates" vocabulary. **Residual question:** whether *any* chapter of this book covers optimisation. Until answered, phase 2 has no numerical-analysis source. | ✅ **Resolved** — citation void; salvage still open |

**All ten disputes are now resolved.** Six were confirmed wrong (V1, V2, V3, V4, V7, V8),
four more on the shelf (V5, V6, V9, V10). Two assignments were confirmed *correct*:
MacKay Ch. 2–4 and GBC §12.4.5.1. Russell & Norvig's 4th edition and chapter numbering are
verified, and the Goodfellow print copy is confirmed owned.

**MacKay Ch. 2–4 for module 5 is confirmed correct** — verified against the PDF: Ch. 2
*Probability, Entropy, and Inference*, Ch. 3 *More about Inference*, Ch. 4 *The Source
Coding Theorem*.
