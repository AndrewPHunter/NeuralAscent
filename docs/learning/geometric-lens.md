# The Geometric Lens

*If you can draw it, you understand it.*

---

## Why This Document Exists

The reading plan says what to read. This says **how to read it**.

The goal of this arc is not working code with adequate explanation attached — it is
understanding what these architectures actually *do to space*. Every module here has a
geometric object at its centre. The algebra is how we compute with that object; it is not
the object.

**The working method:**

1. **Name the picture before the derivation.** What is the geometric claim?
2. **Do the algebra.**
3. **Check the algebra against the picture.** If they disagree, one of them is wrong and
   finding out which is the session's real work.
4. **Draw it.** Literally. A page with the object on it, by hand.

When a text hands you a manipulation with no picture attached, that is a **flag** — go find
the picture elsewhere. It is not permission to move on.

> **Every chapter reference in this document has been verified against the book it names.**
> See the [verification record](#verification-queue) at the end. Nothing here is recalled
> from memory — the original plan had eight of ten citations wrong, so predictions are
> checked before they are written down.

---

## The Spine

| Module | The object | The claim | Draw this |
|---|---|---|---|
| **0** Foundations | A matrix as a map of space | A matrix sends the unit sphere to a hyperellipse. Singular values are its axis lengths; eigenvectors are the directions that survive unrotated; the determinant is volume scaling. | The unit circle and its image under a 2×2 matrix, with both axes marked |
| **1** Perceptron | A hyperplane and its normal | Learning rotates the plane. Convergence is the weight vector entering a feasible cone. XOR fails because no such plane exists. | The four XOR points and the pencil of lines that cannot separate them |
| **2** MLP | A change of coordinates | The hidden layer *warps input space* until the problem is linearly separable. ReLU nets fold space into polytopes; depth multiplies folds. | XOR's four points before and after the hidden layer, in hidden-unit coordinates |
| **3** RNN | A flow in phase space | The hidden state traces a trajectory. Fixed points, attractors, basins. The Jacobian's eigenvalues contract or expand along eigendirections. | The phase portrait of the recurrence, with fixed points classified |
| **4** CNN | Equivariance under translation | Weight sharing is not parameter thrift — it is a *symmetry constraint*. The map commutes with translation. | A feature detector and its translate, producing translated output |
| **5** Attention | The simplex and the sphere | Softmax over dot products is similarity on a sphere. The output is a convex combination — a point inside the simplex spanned by the value vectors. | Three value vectors, their simplex, and where the attention output sits inside it |
| **6** Transformer | Subspaces of a residual stream | Heads read from and write to subspaces of one shared vector space. LayerNorm is a projection onto a hyperplane ∩ sphere. Positional encoding puts tokens on a helix. | The residual stream as a wide arrow, with heads reading and writing narrow bands |

---

## Two Ideas That Run Through Everything

These are not module-specific. They are the reason the geometric view pays off.

### 1. Backpropagation is the pullback of a covector

**The gradient is not a vector.** For `f : M → ℝ`, the *differential* `df` is a **covector** —
basis-independent, living in the cotangent space. The *gradient* `∇f` exists only once an
inner product is chosen:

```
⟨∇f, v⟩ = df(v)
```

The metric is what converts one into the other. This is not pedantry; it explains the
algorithm:

| | |
|---|---|
| **Reverse mode (backprop)** | Pulls a covector *back* through the composition |
| **Forward mode** | Pushes tangent vectors *forward* |
| **Why reverse mode wins** | The loss maps to ℝ, so there is exactly **one** covector at the output to pull back — one sweep. Forward mode needs one sweep per input parameter. |

The chain rule is `d(g∘f) = dg ∘ df` — composition of differentials. The expression
`∂L/∂W = δ · aᵀ` in [`../02_mlp.md`](../02_mlp.md) is a pullback. `MLP.cs` will implement
one whether or not it is described that way.

**Source:** Lee, *Introduction to Smooth Manifolds*, **2nd ed. 2012** ✅ —
**Ch. 3 *Tangent Vectors*** (the differential / pushforward), then
**Ch. 11 *The Cotangent Bundle*** (covectors and 1-forms).
**Ch. 13 *Riemannian Metrics*** is what converts a covector into a gradient — see below.

### 2. Ill-conditioning is a mismatch of metrics

Gradient descent `w ← w − η∇L` silently assumes the **Euclidean metric** on parameter
space. Nothing justifies that choice.

| Method | What it really is |
|---|---|
| Plain gradient descent | Steepest descent under the Euclidean metric |
| Preconditioning | Choosing a different metric |
| Newton's method | Using the Hessian as the metric |
| Natural gradient (Amari) | Using the Fisher information metric |

Phase 2's whole optimisation agenda — why loss oscillates, why conditioning matters, why
learning rates are finicky — collapses into **one** idea rather than a list of tricks. But
stating it requires the covector/metric distinction above.

**Source:** Lee ISM **Ch. 13 *Riemannian Metrics*** ✅ — the metric is precisely what turns
the differential `df` (a covector) into the gradient `∇f` (a vector). Without it, "gradient
descent" is not even well defined; with it, the whole list above is one choice made four
ways.

This is the geometric content of GBC Ch. 4 (*Numerical Computation*) and Ch. 8
(*Optimization for Training Deep Models*), which those chapters present algebraically.

---

## Per-Module Geometry

### Phase 0 — What a matrix does to space

**The one fact:** every matrix maps the unit sphere to a hyperellipse. Singular values are
the axis lengths. That single picture is what a weight matrix is doing at every layer of
every architecture in this repo.

| Source | Role |
|---|---|
| **3Blue1Brown — *Essence of Linear Algebra*** | The direct geometric route. Linear maps, determinant as volume scaling, eigenvectors as invariant directions. Watch before opening either textbook. |
| **Larson Ch. 7** ✅ | Eigenvalues and eigenvectors, worked and illustrated |
| **Schneider & Barker Ch. 1–6** ⚠︎ | Reference only — see the warnings below |

**Checkpoint:** draw the image of the unit circle under **two** matrices and compare.

| | |
|---|---|
| `[[3,1],[1,2]]` | **Symmetric.** Eigenvectors and singular directions *coincide*. |
| `[[1,1],[0,1]]` | **A shear.** One repeated eigenvalue (λ=1) with only **one** eigendirection, `(1,0)` — the matrix is not diagonalisable. Yet the unit circle still maps to a clean ellipse, with axes `φ` and `1/φ` along two perpendicular singular directions. |

The shear is the instructive one. Determinant 1, so area is preserved — nothing is created
or destroyed — but space is stretched by the golden ratio in one direction and compressed by
its reciprocal in another. And the directions that *stretch* are not the direction that
*survives unrotated*.

**Know why eigen ≠ singular.** Eigenvectors answer "which directions are preserved?"
Singular directions answer "which directions are stretched most?" Those are different
questions, and they only give the same answer for symmetric matrices. Every weight matrix in
this repo is non-symmetric.

### Phase 1 — Hyperplanes and cones

The weight vector is the **normal** to the decision hyperplane. Learning rotates it. The
convergence proof is geometric: Novikoff bounds the number of updates by `(R/γ)²` — the
data radius over the margin. Both quantities are distances.

| Source | Role |
|---|---|
| **HKP Ch. 5** ✅ *Simple Perceptrons* | Primary — geometric by construction |
| **MacKay Ch. 40** ✅ *Capacity of a Single Neuron* | Capacity as *counting dichotomies* — how many of the 2^N labellings of N points in d dimensions are linearly realisable. Pure geometry. |
| **Novikoff (1963)** | The margin/radius proof |

**Checkpoint:** the four XOR points, and an argument — not a citation — for why no line
separates them.

### Phase 2 — Warping space, and the limits of warping

This is the richest module geometrically, and the one where topology earns its place.

**The claim:** the hidden layer applies a change of coordinates that makes XOR separable.
**The limit:** a layer with an invertible weight matrix and a monotonic activation is a
**homeomorphism** — and homeomorphisms preserve topological invariants. So warping alone
*cannot* separate every dataset. Extra dimensions or non-invertible maps are required.

That is why hidden layers need width, stated as a theorem rather than a heuristic.

| Source | Role |
|---|---|
| **Olah — *Neural Networks, Manifolds, and Topology*** | The picture. Short, free, and the clearest statement of the claim. Read first. |
| **Munkres Ch. 3** ✅ *Connectedness and Compactness* | The proof behind Olah's picture. Connectedness is the invariant being preserved — and the same chapter carries compactness, so one chapter serves both needs below. |
| **Munkres Ch. 3** ✅ *(compactness half)* | Universal approximation is density in `C(K)` for **compact** `K`. Without compactness the theorem does not state. |
| **Munkres Ch. 7** ✅ *Complete Metric Spaces and Function Spaces* | Makes universal approximation a statement about the *topology of a function space* rather than a magic result. This is the chapter that connects to Royden. |
| **Royden & Fitzpatrick Ch. 18** ✅ *(5th ed.)* — Hahn–Banach | The machinery Cybenko's proof actually uses. **Riesz is distributed across the book** rather than sitting in one chapter — the one Cybenko needs is the representation of `C(X)*` as measures (Riesz–Markov–Kakutani), in the measure-meets-topology material, *not* the Hilbert-space or `Lᵖ`-dual versions. |
| **Munkres Part II** ✅ *(opens with the fundamental group)* / Lee ITM | Where "linked rings cannot be unlinked by a homeomorphism" becomes rigorous. Olah's hardest example is really π₁. |
| **Prince Ch. 3–4** ✅ | Draws nets folding space into polytopes. The picture for ReLU networks specifically. |
| **ESL §3.4** ✅ | Weight decay geometrically: the L2 ball intersecting elliptical contours |

**Checkpoint:** XOR's four points plotted in hidden-unit coordinates after training, showing
the separating line that did not exist in input space. Then: construct a 2-D dataset a
2-unit hidden layer *cannot* separate, and say which invariant obstructs it.

### Phase 3 — Flows, fixed points, and contraction

**The claim:** the vanishing gradient is not a numerical accident. It is repeated
contraction along the Jacobian's eigendirections — a statement about a dynamical system.

| Source | Role |
|---|---|
| **Strogatz Ch. 10** ✅ *One-Dimensional Maps* | **The most directly applicable chapter in the module.** An RNN recurrence is a *discrete-time map*, not a flow — so its fixed-point stability condition is `\|λ\| < 1`, which **is** the vanishing-gradient condition. Read this before the flow material. |
| **Strogatz Ch. 5** ✅ *Linear Systems* *(2nd ed. 2015)* | Eigenvalue classification of fixed points, drawn. Then the phase-plane material for trajectories and basins. |
| **Boyce & DiPrima Ch. 7 + Ch. 9** ✅ *(9th ed.)* | *Systems of First Order Linear Equations* and *Nonlinear Differential Equations and Stability*. **Paired deliberately** — solve the same systems Strogatz draws. Seeing the portrait and computing the solution are different acts; doing both on one equation is where the geometry stops being decoration. Note these are **flows**, so the stability condition is `Re(λ) < 0` — the continuous analogue, not the RNN's own condition. |
| **HKP Ch. 7** | Recurrent networks as dynamical systems, attractors |
| **Prince §11.3** ✅ | Exploding gradients in residual networks |
| **Schneider & Barker Ch. 6 / Larson Ch. 7** ✅ | Eigenvalues, re-read against the recurrence Jacobian |

**Checkpoint:** the phase portrait of your trained recurrence, fixed points classified by
eigenvalue. Then predict the gradient decay rate from the eigenvalues *before* measuring it
in code.

### Phase 4 — Symmetry as the design principle

**The claim:** weight sharing is not an efficiency trick. It is the statement that the
architecture should **commute with translation** — an equivariance constraint. The
parameter saving is a consequence, not the motivation.

| Source | Role |
|---|---|
| **Bronstein et al. §5.1–5.2** ✅ | CNNs and group-equivariant CNNs *derived from* the translation group |
| **Bronstein et al. §3.1** ✅ | Symmetries, representations, invariance — the general frame |
| **GBC Ch. 9** | The algebra and the engineering |

**Checkpoint:** show your 1-D kernel commuting with a shift — translate the input, and the
output translates identically.

### Phase 5 — High-dimensional geometry

**The claim:** `√d` is not a fudge factor. In high dimensions, dot products of random
vectors concentrate; without rescaling, softmax saturates and gradients die. This is
concentration of measure, and it is a geometric fact about spheres.

**The second claim:** attention output is a **convex combination** of value vectors — a
point in their simplex. Attention cannot leave that hull.

| Source | Role |
|---|---|
| **Blum, Hopcroft & Kannan Ch. 2** ✅ | *The Geometry of High Dimensions*, *Properties of the Unit Ball*, *Gaussians in High Dimension*, *Johnson–Lindenstrauss*. Why random vectors are nearly orthogonal. This is the `√d` explanation. |
| **Bronstein et al. §5.4** ✅ | *Deep Sets, Transformers, and Latent Graph Inference* — attention as a **permutation-equivariant set operation**. This answers module 5's own key question from the symmetry side. |
| **Pierce Ch. 3–5** ✅ / **MacKay Ch. 2–4** ✅ | The information-theoretic lens. Not geometric — and that is fine, it is the right lens for softmax-as-distribution. |

**Checkpoint:** sample random vectors in 2, 10, and 1000 dimensions and plot the
distribution of pairwise dot products. Watch it concentrate. Then show what softmax does to
the un-scaled version.

### Phase 6 — Subspaces of a shared stream

**The claim:** the residual stream is a vector space that every block reads from and writes
to. Heads operate in **subspaces**. LayerNorm is a projection — onto the intersection of a
hyperplane (zero mean) and a sphere (fixed norm), then rescaled.

| Source | Role |
|---|---|
| **Prince Ch. 12** ✅ | Self-attention derived, with figures throughout |
| **Prince Ch. 11** ✅ | Residual connections and normalisation — the prerequisite |
| **Elhage et al. — *A Mathematical Framework for Transformer Circuits*** | The residual-stream-as-vector-space view, stated explicitly. Advanced, and the most geometric account of transformers available. |
| **Bronstein et al. §5.4** ✅ | Positional encoding as *breaking* permutation symmetry — the clean framing of why it is needed at all |
| **Prince Ch. 20** ✅ | Overparameterisation and generalisation |

**Checkpoint:** draw the residual stream with each head's read and write subspaces marked.
Then: why does positional encoding have to be *added* to the stream rather than concatenated?

---

## Where the Texts Will Fight You

Named so you know to go looking rather than assuming the picture does not exist.

| Text | Problem | Compensate with |
|---|---|---|
| **Schneider & Barker** | Dover formalism. Determinants developed algebraically, eigenvalues arriving as a computation at Ch. 6. Machinery without the picture, at the moment the picture matters most. **This is phase 0's assigned primary and the worst mismatch in the plan.** | 3Blue1Brown first; Larson as the lead text; S&B as reference |
| **GBC** | An engineering text. Ch. 6 backprop is computation-graph and algorithmic; Ch. 4 and 8 present conditioning algebraically. Correct, and it will not give you the geometry. | Prince alongside, every time |
| **Pierce, MacKay** | Information theory is probabilistic and verbal, not geometric. | Not a defect — the right lens for module 5. Do not expect pictures. |
| **Dielman** | Statistical and algebraic throughout. | ESL §3.4 for the constraint-region picture |
| **Royden, Munkres** | Rigorous and picture-light by discipline. Real analysis and point-set topology are *about* pathology. | Read them **for** the theorems Olah and Cybenko need, not as general background |

**Where you are already well served:** Prince draws everything. HKP thinks in energy
landscapes and weight space. ESL §3.4 has the canonical constraint geometry. Strogatz is
geometric by construction. Bronstein is geometry as the organising principle.

---

## Reading Order

Not a schedule — a dependency graph. These are ordered because reading them out of order
wastes the insight, not because of time.

```
point-set topology  (continuity · homeomorphism · connectedness · compactness)
        │
        ├──→ Olah  ──→  module 2: "warping has limits"
        │
        ├──→ compactness ──→ Royden (Hahn–Banach, Riesz) ──→ universal approximation
        │
        └──→ Lee ISM: manifolds → tangent spaces → differentials → cotangent bundle
                     │
                     ├──→ backprop as pullback of a covector   ──→ module 2 code
                     │
                     └──→ metric → gradient → Newton → natural gradient
                                  │
                                  └──→ ill-conditioning as metric mismatch  ──→ phase 2
```

Lee's tangent-space material assumes point-set topology. Starting there is not optional.

Bronstein and Blum/Hopcroft/Kannan are independent of this chain and can be read whenever
their module comes up.

---

## Verification Queue

Recalled from memory, **not** checked against the shelf. Same loop as the citation audit:
prediction below, TOC line back, record.

**Complete — 2026-09-03.** All items verified against the shelf.

| ID | Book | Result |
|---|---|---|
| **G1 · G2** | Munkres, *Topology* | **Ch. 3** *Connectedness and Compactness* — one chapter serves both |
| **G3** | Munkres | **Ch. 7** — complete metric spaces and function spaces |
| **G4** | Munkres | **Part II opens with the fundamental group** |
| **G7** | Royden & Fitzpatrick, **5th ed.** | **Ch. 18** Hahn–Banach. **Riesz is distributed through the book**, not one chapter — the version Cybenko needs is `C(X)*` as measures, not the Hilbert or `Lᵖ` forms |
| **G8** | Strogatz, **2nd ed. 2015** | **Ch. 5** *Linear Systems* |
| **G10** | Strogatz | **Ch. 10** *One-Dimensional Maps* — **the priority chapter for module 3** |
| **G9** | Boyce & DiPrima, **9th ed.** | **Ch. 7** systems · **Ch. 9** nonlinear stability |
| — | Lee, *Introduction to Smooth Manifolds* | **2nd ed. 2012 confirmed** |

| **G5** | Lee ISM (2nd ed.) | **Ch. 3** *Tangent Vectors* — the differential / pushforward |
| **G6** | Lee ISM | **Ch. 11** *The Cotangent Bundle* — covectors, 1-forms |
| **G11** | Lee ISM | **Ch. 13** *Riemannian Metrics* — converts covector to gradient |

**All ten geometric references verified.** Every chapter number in this document has been
checked against the book it names.
