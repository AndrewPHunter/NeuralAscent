# Master Reading Plan

Parallel model: reading tracks the active implementation module. Each phase shows primary
reading, the specific chapter focus, and a supplementary text for an alternative angle.

> **All ten citation disputes are resolved** — verified against the shelf or the free
> electronic editions. Markers link to
> [`library.md`](./library.md#citation-verification):
> **✅** verified correct, or corrected to the right chapter · **❌** verified *wrong*,
> original struck through and left visible.
>
> Struck text is kept deliberately. The errors are part of the record.

---

## Phase Table

| Phase | Module | Primary Reading | Chapters / Focus | Supporting |
|---|---|---|---|---|
| 0 | Pre-flight Foundations | Schneider & Barker | ~~Ch. 1–4~~ → **Ch. 1–6** ✅[V9] — matrices, linear equations, vector spaces, determinants … **eigenvalues (Ch. 6)** | HKP Ch. 1 (review) |
| 0 | Pre-flight Foundations | Hertz, Krogh & Palmer | Ch. 1 — introduction & statistical framing | ~~Nilsson Ch. 1–2~~ ❌[V1] — void |
| 0 | Pre-flight Foundations | **Larson** *Elementary Linear Algebra* 🆕 | Through **Ch. 7 *Eigenvalues and Eigenvectors*** ✅ — the approachable route alongside S&B | S&B Ch. 1–6 |
| 1 | Perceptron 1957 | **Hertz, Krogh & Palmer** ✅[V4] *(now primary)* | ~~Ch. 1~~ → **Ch. 5 *Simple Perceptrons***: learning rule, convergence, linear separability, geometric interpretation | MacKay Ch. 39–40; Novikoff 1963; S&B Ch. 2 (dot product) |
| 2 | MLP 1986 | Goodfellow, Bengio & Courville | Ch. 6 — feedforward networks, backprop derivation | HKP Ch. 6 |
| 2 | MLP 1986 | Hastie, Tibshirani & Friedman | Ch. 11 — neural networks as statistical models | ~~Cohen Ch. 3~~ ❌[V10] — Ch. 3 is *Series*; **no source** |
| 2 | MLP 1986 | Hertz, Krogh & Palmer | Ch. 6 — generalisation, weight decay, capacity | GBC Ch. 7 (regularisation) |
| 2 | MLP 1986 | MacKay | ~~Ch. 41–43~~ ❌[V3] → **Ch. 39–41 + 44**, plus **Ch. 28** (evidence framework) | **ESL §3.4** 🆕 (cross-reference) |
| 2 | MLP 1986 | **ESL §3.4** 🆕 *Shrinkage Methods* | **§3.4.1 Ridge Regression** — derived as posterior mode under a Gaussian prior | MacKay Ch. 41 / 44 |
| 2 | MLP 1986 | **GBC Ch. 4 + Ch. 8** 🆕 | *Numerical Computation* · *Optimization for Training Deep Models* — replaces void Cohen Ch. 3 | Dielman (multicollinearity) |
| 3 | RNN 1986 | Goodfellow, Bengio & Courville | Ch. 10 — BPTT, vanishing gradients, LSTM sketch | HKP Ch. 7 |
| 3 | RNN 1986 | Hertz, Krogh & Palmer | Ch. 7 — recurrent networks, attractors, dynamics | Russell & Norvig Ch. 21 (sequences) |
| 3 | RNN 1986 | **Boyce & DiPrima** 🆕 | Linear systems: eigenvalue classification of equilibria · nonlinear stability, phase portraits, attractors | **S&B Ch. 6** / **Larson Ch. 7** ✅ |
| 4 | CNN 1989 | Goodfellow, Bengio & Courville | Ch. 9 — convolution, pooling, weight sharing | ESL Ch. 11.7 |
| 4 | CNN 1989 | Russell & Norvig | Ch. 25 — deep learning for vision & perception | GBC Ch. 9 (supplementary) |
| 5 | Attention 2015 | Pierce | ~~Ch. 1–4~~ → **Ch. 3–5** ✅[V5] — *A Mathematical Model*, *Encoding and Binary Digits*, **Entropy (Ch. 5)** | MacKay Ch. 2–4 ✅ |
| 5 | Attention 2015 | MacKay | Ch. 2–4 ✅ — entropy, inference, Bayesian framing | HKP Ch. 9 |
| 5 | Attention 2015 | Goodfellow, Bengio & Courville | **§12.4.5.1** ✅ — *Using an Attention Mechanism…*, a subsection of §12.4.5 *Neural Machine Translation*, not a chapter | Bahdanau et al. 2015 (paper) |
| 6 | Transformer 2017 | **Prince** *Understanding Deep Learning* 🆕 *(primary)* | **Ch. 12 Transformers** ✅ — self-attention, multi-head, positional encoding, layer norm, encoder/decoder | Prince **Ch. 11** (batch norm, residuals) |
| 6 | Transformer 2017 | Russell & Norvig | Ch. 24 — *Deep Learning for NLP* (4th ed. verified) — survey framing | **J&M Ch. 7** 🆕 *Transformers and Pretraining* |
| 6 | Transformer 2017 | ~~GBC Ch. 12 + Epilogue~~ ❌[V2] | **Does not exist** — GBC predates the architecture | — |
| 6 | Transformer 2017 | Pierce | ~~Ch. 8–10~~ → **Ch. 6–8** ✅[V6] — *Language and Meaning*, *Efficient Encoding*, *The Noisy Channel* | Vaswani et al. 2017 (paper) |
| 6 | Transformer 2017 | **Prince Ch. 20** 🆕 *(replaces the ESL framing)* | **§20.4 generalization · §20.5 *Do we need so many parameters?*** — the overparameterisation argument ESL Ch. 18 ❌[V8] does not make | ESL Ch. 18 (read for p ≫ N statistics only) |

---

# Module Reading Guides

Detailed guidance for each module — what to read, what to look for in the code, and what
questions to bring back.

## Phase 0 — Pre-flight Foundations

Before writing a single network, establish the mathematical substrate. This is a short
phase — 3–5 sessions — not a prerequisite gauntlet.

| | |
|---|---|
| **Goal** | Refresh linear algebra intuition at the level needed for `Matrix.cs`. Review dot products, matrix multiplication, and eigenvalues as geometric operations, not just procedures. |
| **Schneider & Barker Ch. 1–6** ✅[V9] | **Corrected range.** Verified: Ch. 1 *Algebra of Matrices*, 2 *Linear Equations*, 3 *Vector Spaces*, 4 *Determinants* — and **eigenvalues do not arrive until Ch. 6**. The plan's original Ch. 1–4 stopped two chapters short of material it explicitly promised. Determinants (Ch. 4) are the prerequisite for the characteristic polynomial, so the run 1→6 is coherent. The key question: what does it mean for a matrix to transform a vector space? That is what every weight matrix in every network is doing. |
| **Larson — *Elementary Linear Algebra*** 🆕 | A second linear algebra text, more pedagogical than the terse Schneider & Barker Dover. Worked examples for linear transformations and eigenvalues. Use whichever route suits the session; S&B is the reference, Larson the explanation. ✅ **Eigenvalues are Ch. 7** — note that is *two chapters later* than Schneider & Barker's Ch. 6, so the two books' numbering does not line up. Read to the end of Larson Ch. 7 / S&B Ch. 6. |
| **HKP Ch. 1** | The introduction establishes their statistical mechanics framing. Dense but short. Sets up vocabulary used for the rest of the arc. |
| **Code connection** | Trace `Core/Matrix.cs` line by line. Every method maps to something in these chapters. `Multiply` is a linear transformation. `Hadamard` appears in backprop because it represents element-wise scaling of a gradient by an activation derivative. |

## Phase 1 — Perceptron (Module 01)

The Perceptron is simple enough to hold entirely in your head. Use that to build intuition
before anything gets complicated.

| | |
|---|---|
| **Goal** | Understand the perceptron convergence theorem — not just *that* it converges on linearly separable data, but *why*. Then watch it fail on XOR and understand geometrically why XOR cannot be linearly separated. |
| **HKP Ch. 5** ✅[V4] *(primary)* | **Verified: *Simple Perceptrons*** (1991 ed.). The plan's ~~Ch. 1~~ was the introduction. With Nilsson struck, this is now the module's primary text — the perceptron learning rule, convergence, and linear separability in one chapter. Pay attention to the weight vector as a normal to a decision hyperplane: that framing persists through every subsequent architecture. |
| **MacKay Ch. 39–40** *(supporting)* | Free, on disk, verified. §39.1–39.3 treat the single neuron as a binary classifier; **§40.2–40.3 ask how many patterns one neuron can separate** (capacity, counting threshold functions, Cover). The capacity framing is a sharper question than the plan originally asked. Caveat: MacKay trains by gradient descent and never covers Rosenblatt's mistake-driven rule — "perceptron" appears in this book only in the *multilayer* sense (Ch. 44). |
| **Novikoff (1963)** *(convergence backstop)* | The original convergence proof — short, and **already cited in `../01_perceptron.md` as reference 3**. Use it if HKP §5's proof turns out to be sketched rather than derived. |
| ~~**Nilsson Ch. 4–5**~~ ❌[V1] | **Struck — verified void.** The shelf copy is the 1980 *Principles of AI*, whose Ch. 4 is *The Predicate Calculus in AI* and Ch. 5 is *Resolution Refutation Systems*. There is no perceptron content. The convergence proof the plan described is in Nilsson's *Learning Machines* (1965), which is **not owned**. This module's designated primary reading does not exist. |
| **Code connection** | Run `PerceptronRunner` on AND and OR. Verify convergence. Then run on XOR with a high epoch cap. Plot the weights over time. Ask: is the weight vector converging, or oscillating? Why? |
| **Key question** ❌ *(premise corrected)* | *Original wording:* "The perceptron update rule and gradient descent on MSE loss produce identical weight updates. Is this a coincidence? (It isn't.)" **This premise is false as stated** — see `../01_perceptron.md`, which correctly notes the step function has zero derivative almost everywhere, so gradient descent cannot be applied. The updates coincide in *form* only for a **linear** output — that is Widrow–Hoff / Adaline, a different algorithm. The perceptron rule is subgradient descent on the perceptron criterion `max(0, −y(w·x))`. **Reframed question:** why do the two rules look identical, and exactly what breaks the equivalence? |

## Phase 2 — MLP (Module 02)

Where the most learning happens. Backpropagation is the chain rule applied to a composition
of functions — but the leap from knowing that to implementing it correctly is where most
people get stuck. Take your time here.

| | |
|---|---|
| **Goal** | Derive backpropagation yourself before reading it. Start from the loss function, apply the chain rule layer by layer, arrive at the weight update. Then read GBC Ch. 6 to check your derivation. |
| **GBC Ch. 6** (primary) | The canonical modern derivation. Read the backprop section twice — once forward for the algorithm, once in reverse asking "where does each delta term come from?" The computation graph framing (§6.5) is particularly valuable. |
| **ESL Ch. 11** | Reads the MLP as a statistical estimation problem. The bias–variance framing here is more useful for understanding why deep networks generalise than anything in GBC. |
| **HKP Ch. 6** | Weight decay, early stopping, and capacity from a statistical physics angle that makes the regularisation mechanisms feel principled rather than heuristic. |
| **ESL §3.4 — *Shrinkage Methods*** 🆕 ✅ | **The missing bridge**, verified in the PDF. §3.4.1 derives ridge regression as the **mode of the posterior under a Gaussian prior** (βⱼ ~ N(0, τ²)). This is the same L2-equals-Gaussian-prior result MacKay reaches from the Bayesian side — here it arrives from the statistics side. The plan assigns ESL Ch. 11 and Ch. 18 but never Ch. 3, so this connection was sitting unused in a book already on the list. Read it immediately before MacKay Ch. 41. |
| **GBC Ch. 4 + Ch. 8** 🆕 *(replaces Cohen)* | **Ch. 4 *Numerical Computation***: conditioning, poor conditioning, overflow/underflow, gradient-based optimisation. **Ch. 8 *Optimization for Training Deep Models***: ill-conditioning, local minima, plateaus, saddle points, cliffs, learning-rate schedules. Together these are the "why is my loss oscillating?" vocabulary the plan wanted from Cohen — in a book already assigned five other chapters. |
| **Dielman** 🆕 *(supporting)* | Multicollinearity and ill-conditioning made concrete: why correlated or badly scaled inputs wreck a fitted model. Do **not** rely on it for ridge — business-oriented regression texts often omit it; ESL §3.4 is the source for that. |
| ~~**Cohen Ch. 3**~~ ❌[V10] | **Struck — verified void.** Ch. 3 is *Series*, not gradient methods. Series expansions do sit behind optimisation theory (Taylor expansion underpins gradient and Newton methods), so the chapter is not useless — but it does not supply the "why is my loss oscillating?" vocabulary the plan wanted. **Phase 2 currently has no numerical-analysis source.** Open: whether any other chapter of Cohen covers optimisation. |
| **MacKay** ✅[V3] | The Bayesian interpretation of weight decay: L2 regularisation is exactly equivalent to a Gaussian prior on the weights — not a heuristic, but inference. **Corrected range: Ch. 39–41 + Ch. 44**, with **Ch. 28** (*Model Comparison and Occam's Razor*) for the evidence framework. Ch. 42–43 are Hopfield and Boltzmann networks — not weight decay. |
| **Code connection** | Implement backprop with delta values printed at each layer. Verify by numerical gradient checking: perturb each weight by ε, compute `(L(w+ε) − L(w−ε)) / 2ε`, confirm it matches the analytical gradient. **Note:** this requires a fixed RNG seed — `Matrix.Random` defaults to `seed: null` and is nondeterministic. |
| **Key question** | Why does XOR require a hidden layer? Construct the argument geometrically — what does the hidden layer do to the input space that makes XOR separable? |

## Phase 3 — RNN (Module 03)

| | |
|---|---|
| **Goal** | Understand BPTT as a special case of backprop on an unrolled computation graph. Then observe vanishing gradients empirically. |
| **GBC Ch. 10** (primary) | The definitive treatment of RNNs, BPTT, and the vanishing gradient problem. The echo state network section is worth reading even though you won't implement it — it shows the problem from a different angle. **Correction ✅[V7]: the plan cited §10.7, which is *The Challenge of Long-Term Dependencies*. Echo State Networks is §10.8.** Both are worth reading; §10.7 is arguably the more important of the two for this module. |
| **HKP Ch. 7** | Recurrent networks as dynamical systems. Attractors, fixed points, and stability — rare in modern ML texts and directly relevant to why vanishing gradients happen: the Jacobian of the recurrence map has eigenvalues less than 1. *(Note: attractor dynamics proper is largely HKP Ch. 2–3, the Hopfield material.)* |
| **Boyce & DiPrima** 🆕 *(new — dynamical systems)* | Not an optimisation text; a **dynamical systems** text, which is what this module actually needs. Systems of first-order linear equations give the eigenvalue/eigenvector classification of equilibria — directly the "eigenvalues below 1 means decay" intuition. The nonlinear stability material gives phase portraits, fixed points and attractors, which is the substrate under HKP Ch. 7's framing. **The plan assigned nothing here at all.** |
| **Missing assignment** ✅[V9] | The key question below is explicitly an eigenvalue problem, but no linear algebra reading is assigned to this phase. Now that eigenvalues are located: **Schneider & Barker Ch. 6 — or Larson Ch. 7** ✅ — **belongs here**, re-read against the recurrence Jacobian — not only skimmed in phase 0. With DiPrima added, phase 3 now has both the linear algebra and the dynamical-systems view of the same object. |
| **Code connection** | Train on the sine wave sequence dataset (`Data/Sequences.cs`). Deliberately use a long sequence. Inspect gradient magnitudes at each timestep during BPTT — they should decay exponentially toward the earliest timesteps. |
| **Key question** | The vanishing gradient is an eigenvalue problem. What property of the weight matrix would prevent it? (This motivates LSTM, which you won't implement but should understand in principle.) |

## Phase 4 — CNN (Module 04)

| | |
|---|---|
| **Goal** | Understand weight sharing as an inductive bias — the assumption that a feature detector useful in one spatial location is useful everywhere. This is the key insight, not the convolution operation itself. |
| **GBC Ch. 9** (primary) | Focus on §9.2 (motivation), §9.3 (pooling), §9.4 (convolution variants). The parameter efficiency argument is the one to internalise. |
| **Russell & Norvig Ch. 25** | Places CNNs in the context of perception and computer vision. Useful for understanding what problem CNNs were solving in the real world, not just mathematically. |
| **Code connection** | Implement a 1-D convolution kernel and verify it detects a pattern regardless of position. Then a simple 2-D convolution applied to a small binary image. **Blocked:** `Data/` currently has no image data — logic gates and 1-D sequences only. A dataset needs adding before this exercise can run. |

## Phase 5 — Attention (Module 05)

| | |
|---|---|
| **Goal** | Understand attention as a parameterised, differentiable lookup. The Query–Key–Value abstraction is the one to nail. Softmax as a distribution over relevance scores is where the information theory becomes directly relevant. |
| **Pierce Ch. 3–5** ✅[V5] | Read before touching the code. Entropy and mutual information are the theoretical language of softmax. **Corrected: the plan said Ch. 1–4, but verified Ch. 5 is *Entropy*** — the original range stopped one chapter short of the whole point. Ch. 3 *A Mathematical Model* and Ch. 4 *Encoding and Binary Digits* set it up. |
| **MacKay Ch. 2–4** ✅ | Verified correct. More formal than Pierce and directly Bayesian. The two are complementary: Pierce for intuition and history, MacKay for precision. |
| **GBC Ch. 12** ✅ | The attention mechanism in context. **Verified: this is §12.4.5.1, *Using an Attention Mechanism and Aligning Pieces of Data*, a subsection of §12.4.5 *Neural Machine Translation* — not a chapter on attention.** Short, and framed entirely as a fix for the encoder bottleneck. |
| **Bahdanau et al. 2015** | The original attention paper. Short. Read after Pierce and GBC to see how the mechanism was first motivated — as a fix for the RNN encoder bottleneck, not as a general architecture. |
| **On the √d scaling** | The original plan framed `exp(QKᵀ/√d)`'s divisor as a temperature parameter in the Boltzmann sense, attributed to Pierce. Two caveats: the Boltzmann framing is statistical mechanics — **HKP's** territory, not Pierce's — and Vaswani motivates √d as dot-product *variance control* (§3.2.1), not temperature. The temperature reading is a good intuition; it is not the authors' stated motivation. |
| **Code connection** | Implement scaled dot-product attention from scratch. Visualise the attention weights as a matrix — what patterns form on a synthetic sequence task? |
| **Key question** | Attention is a set operation — it has no notion of order. How does the Transformer handle sequence order? (Positional encoding — preview of module 6.) |

## Phase 6 — Transformer (Module 06)

| | |
|---|---|
| **Goal** | Assemble everything. The Transformer is a composition of mechanisms already understood: attention, layer normalisation, feedforward sublayers (MLP), and positional encoding. The novelty is the architecture, not the components. |
| **Vaswani et al. 2017** | Read the paper first. It is well-written and direct. Figure 1 is the architecture — spend time with it before reading the text. **Given V2, the paper and R&N Ch. 24 carry this module between them.** |
| **Prince Ch. 12** 🆕 ✅ *(primary)* | **Gap B closed.** Verified against the PDF: §12.2 *Dot-product self-attention* derives the mechanism; §12.3 adds multi-head, positional encoding and the √d scaling; §12.4 *Transformer layers* assembles the block with layer norm and residuals; §12.6–12.8 work through BERT, GPT3 and encoder-decoder translation. This is the first text in the library written **after** the architecture existed and aimed at derivation rather than survey. |
| **Prince Ch. 11** 🆕 | **The missing prerequisite.** §11.2 residual connections, **§11.4 batch normalization**, §11.3 exploding gradients. The plan described layer norm as "related to batch norm from CNN" — nothing in the repo or the library covered batch norm. This does. Read before Ch. 12. |
| **Prince Ch. 20** 🆕 | §20.4 *Factors that determine generalization*, **§20.5 *Do we need so many parameters?*** — the overparameterisation argument the plan wanted and wrongly attributed to ESL Ch. 18 ❌[V8]. |
| **J&M Ch. 7** 🆕 *(language side)* | *Transformers and Pretraining* — the NLP framing: tokenisation, embeddings, pretraining objectives. ⚠︎ Living draft; chapters get renumbered. Cite `ed3book_aug26.pdf`, not "the current draft". |
| **Russell & Norvig Ch. 24** ✅ *(context)* | *Deep Learning for Natural Language Processing* — 4th ed. confirmed. A survey treatment; now demoted from primary to framing, since Prince covers the mechanism properly. |
| **GBC** ❌[V2] | **Struck.** Verified: the book runs Ch. 1–20 and has no Epilogue; Ch. 12 (*Applications*) contains zero mentions of "Transformer", "self-attention", or "Vaswani". Attention appears only at §12.4.5.1, and only as the RNN-encoder fix. GBC has nothing to say about this module. |
| **ESL Ch. 18** ❌[V8] | **Framing struck, chapter kept.** Verified: Ch. 18 is *High-Dimensional Problems: p ≫ N* — diagonal LDA, nearest shrunken centroids, regularised classifiers, high-dimensional regression. Zero mentions of double descent, overparameterisation, or interpolation. Read it for the p ≫ N statistics; do not expect it to explain why large transformers generalise. |
| **Pierce Ch. 6–8** ✅[V6] | **Corrected, and the correction improves the module.** Verified: Ch. 6 *Language and Meaning*, Ch. 7 *Efficient Encoding*, Ch. 8 *The Noisy Channel*. The plan's Ch. 8–10 caught capacity but missed the language-and-redundancy material entirely — which is the part that actually maps onto "language modelling is compression". |
| **Note on layer norm** ✅ *(resolved)* | The plan described layer normalisation as "related to batch norm from CNN", but nothing in `../04_cnn.md` or the CNN module covers batch norm — the back-reference had no antecedent. **Prince §11.4 supplies it.** Either read that, or add batch norm to module 4 so the forward reference earns itself. |
| **Code connection** | Implement multi-head attention, positional encoding, and the encoder block. Run on a simple sequence-to-sequence task. Inspect the attention heads — do different heads attend to different structural patterns? **Blocked:** no seq2seq dataset exists; `Data/Sequences.cs` is scalar next-value prediction only. |

---

## Open Structural Items

Carried forward from the audit, not yet actioned:

1. **No test project exists.** Phase 2's numerical gradient check and phase 3's gradient
   magnitude inspection are tests. They currently have nowhere to live but throwaway
   console code.
2. **`Matrix.Random` is nondeterministic by default** (`seed: null`). Both verification
   exercises above require reproducible runs.
3. **Missing datasets** — no image data (phase 4), no seq2seq data (phase 6).
4. **No exit criteria.** Phase 0 has a session estimate (3–5); no other phase does, and no
   phase defines what "done" means.
5. **Library coverage gap — narrowed, not closed.** **Module 1 repaired**: HKP Ch. 5 (V4)
   replaces the void Nilsson (V1), with MacKay Ch. 39–40 and Novikoff 1963 supporting.
   **Module 6 repaired**: R&N 4th ed. Ch. 24 confirmed, carrying the module alongside the
   Vaswani paper now that GBC is struck (V2) — but it is a survey chapter, and it is the
   *only* Transformer coverage in the library. **Phase 2 regressed**: Cohen Ch. 3 is void
   (V10), **but GBC Ch. 4 and Ch. 8 replace it** — two chapters the plan never assigned from
   a book it already uses. ESL §3.4 additionally supplies the ridge-as-Gaussian-prior bridge
   to MacKay. The residual gap is narrow: no dedicated numerical-analysis treatment of
   iterative convergence, which GBC covers adequately for this purpose.
