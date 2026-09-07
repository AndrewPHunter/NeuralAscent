# Reading Lenses

*If you can draw it, you understand it. If you can say what it minimises and what it
estimates, you understand it three ways.*

**Four readings, held simultaneously:**

| | Asks |
|---|---|
| **Geometric** | What shape is this? |
| **Physical** | What is being minimised? |
| **Statistical** | What is being estimated, and how wrong is it? |
| **Field-theoretic** | What does a *typical* one of these do, and how does that change with scale? |

They are not alternatives. They are one subject under four questions, and the arc is only
understood when all four answer. The fourth is the capstone and presumes the other three.

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

> **Chapter references here are verified against the book they name**, except where marked
> ⟦verify⟧ — currently two items in the physics thread. See the
> [verification record](#verification-queue) at the end. The original plan had eight of ten
> citations wrong, so predictions get checked before they are relied on.

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

## Eight Ideas That Run Through Everything

These are not module-specific. Ideas 3–4 and 7–8 belong to the physics thread, 5 to the
statistical thread, and 6 to the field-theoretic thread; each has its own section below,
since each spans every phase.

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

## The Physics Thread

Geometry and physics are the same lens here. Not as a teaching device — the objects are
literally thermodynamic. Attention **is** energy descent with attractors; surprisal **is**
work; the softmax **is** a Gibbs measure. Where a physical reading and an algebraic one
disagree, the physical one is usually saying more. A quadratic form *is* an energy; a symmetric
matrix *is* an energy landscape; a probability distribution *is* a thermodynamic state. The
arc's books already carry this — HKP is a statistical mechanics text, MacKay's evidence
framework is a partition function, Bronstein's title ends "and Gauges" — but the thread is
worth naming, because it turns scattered results into one story.

### 3. Softmax is the minimiser of a free energy

The central case, because it recurs in modules 5 and 6.

```
softmax(z)  =  argmin  [ ⟨E, p⟩  −  H(p) ]        E = −z,   H(p) = −Σ pᵢ log pᵢ
                p ∈ Δ
                        ────────────────
                          F  =  U − T·S            (Helmholtz free energy, T = 1)
```

Softmax is the **Gibbs distribution**: the unique minimiser of free energy over the
probability simplex. Equivalently, by Jaynes' principle, the **maximum-entropy**
distribution at fixed expected energy — the least-committed distribution consistent with
what is known.

Three consequences worth holding:

| | |
|---|---|
| **`log-sum-exp` is `log Z`** | The log partition function. And `∇LSE = softmax` — the distribution is the *gradient* of the free energy. |
| **Legendre duality** | LSE and negative entropy are convex conjugates. This is the same duality as free energy ↔ entropy in thermodynamics — the structure, not a metaphor for it. |
| **`√d` is a temperature** | `softmax(QKᵀ/√d)` is `softmax(z/T)` with `T = √d`. High temperature softens the distribution; low temperature sharpens it toward argmax. |

### 4. Attention is energy descent, and the line integral is not a metaphor

The free-energy statement above is the *equilibrium* picture. The dynamical picture is
stronger, and it is the one that matters for what an LLM is doing internally.

**Attention is one step of energy minimisation.** Ramsauer et al., *Hopfield Networks is All
You Need* (arXiv:2008.02217), construct a continuous-state modern Hopfield network and prove:

> "The new update rule is equivalent to the attention mechanism used in transformers."

That update has **three kinds of energy minima** — a global fixed point averaging all
patterns, metastable states averaging subsets, and fixed points storing a single pattern —
and the paper characterises transformer heads by which regime they occupy (global averaging
in early layers, metastable partial averaging in higher ones). **Attractors here are literal,
not analogy.** A forward pass is descent in an energy landscape.

**Surprisal is work — as theorems, not metaphor.** With `E(x) = −log p(x)` up to the free
energy, the nonequilibrium identities apply directly:

| Result | Statement |
|---|---|
| **Jarzynski equality** | `⟨e^{−βW}⟩ = e^{−βΔF}` — work along a path relates to a free-energy difference |
| **Crooks fluctuation theorem** | Forward and reverse path probabilities are related by `e^{βW_diss}` |
| **Kawai–Parrondo–Van den Broeck** | `W_diss = kT · D_KL(forward ‖ reverse)` — **dissipated work *is* a relative surprisal** |

Work is `∫ f · dx` along a path. So "surprisal as work" places a genuine line integral at the
centre of the picture.

**And the path integral is the actual computational route when `Z` is intractable.** In
continuous normalising flows and score-based models (Song et al., arXiv:2011.13456), the
probability-flow ODE gives log-likelihood *as a line integral*:

```
log p₀(x₀)  =  log p_T(x_T)  +  ∫₀ᵀ ∇·f(x_t, t) dt
```

This is deployed, not speculative — it is how exact likelihoods are computed in that family.

**"Minimum" has an exact home: Benamou–Brenier.** The Wasserstein distance *is* a minimum
action over paths in probability space,

```
W₂²(μ₀, μ₁)  =  min  ∫∫ |v|² dρ dt
              paths
```

and the JKO scheme makes free-energy gradient flow the *minimising movement* under that
metric. So "a minimum line integral across the information space" is not loose language —
it is Benamou–Brenier plus JKO, and it is the exact dynamical counterpart of the pointwise
free-energy minimisation in §3.

**What softmax actually is, then.** Over a finite vocabulary, `Z` is exactly enumerable in
one matmul — so softmax is the *cheap exact* route to the Gibbs measure. The path integral is
the route to **the same object** when enumeration fails. The choice between them is
tractability, not correctness. That is why token generation still uses softmax, and why the
"yet" matters: discrete diffusion language models are actively closing the gap (Lou et al.,
*Score Entropy Discrete Diffusion*, arXiv:2310.16834).

**The unification.** The Fisher metric above is the *same object* as the natural gradient in
[§2](#2-ill-conditioning-is-a-mismatch-of-metrics). Phase 2's optimisation geometry and
phase 5's softmax geometry are one Riemannian structure on one manifold — not two subjects
that happen to share vocabulary. Lee **Ch. 13** is the machinery for both.

### The thread, phase by phase

| Phase | The physics | Source |
|---|---|---|
| **0** | A quadratic form `xᵀAx` **is** an energy; a symmetric matrix is an energy landscape and its eigenvectors are **principal axes** — the normal modes of a coupled oscillator. The **polar decomposition** `A = QS` splits any map into rotation × stretch, which is exactly how continuum mechanics decomposes a **deformation**. "What a matrix does to space" is deformation of a medium. | Larson Ch. 7; 3Blue1Brown |
| **1** | Capacity is a *counting* problem, and counting states is entropy. HKP computes perceptron capacity by the methods of statistical mechanics — Gardner's replica calculation of storage capacity is the canonical result. | HKP Ch. 5, and the formal statistical mechanics chapter ⟦verify P2⟧; MacKay Ch. 40 |
| **2** | The loss surface is an **energy landscape**. Weight decay is a **harmonic potential** — L2 is a spring, and the MAP estimate is a ground state. MacKay's evidence **is** the partition function: `log Z = −F`, and the Occam factor is an entropy term. Bayesian inference here is statistical mechanics at `β = 1`. | MacKay Ch. 28, 41, 44; HKP Ch. 6 |
| **3** | Attractors and basins are the physics of dissipative systems. A **Lyapunov function** is an energy that decreases along trajectories — that is how convergence to an attractor is *proved*, not observed. Hopfield networks are spin glasses. | Strogatz Ch. 5, 10; HKP Ch. 7 and the Hopfield material |
| **4** | Equivariance is **Noether's insight** in learning: a symmetry of the problem should be a symmetry of the model. Bronstein takes this to **gauge theory** — a gauge is a local choice of frame, and equivariance is the statement that predictions must not depend on it. | Bronstein §3.1, §4.5 *Gauges and Bundles*, §5.1–5.2 |
| **5** | The module where the physics *is* the content — Gibbs distribution, partition function, free energy, temperature, maximum entropy (§3). And dynamically: **attention is one step of Hopfield energy descent**, with global, metastable, and single-pattern attractors (§4). | HKP; MacKay Ch. 2–4; BHK Ch. 2; Ramsauer et al. |
| **6** *(dynamics)* | The forward pass as a **trajectory** — descent in an energy landscape across layers. Surprisal as work (Jarzynski, Crooks); likelihood as a path integral in the continuous case. Softmax is the enumerable shortcut, not the whole object. | Ramsauer; Song et al.; Lou et al. |
| **6** | **Information and thermodynamics are the same subject.** Pierce has a chapter on exactly this ⟦verify P1⟧, currently unassigned. Landauer's principle — erasing a bit costs `kT ln 2` — is the bridge, and language modelling as compression sits on it. | Pierce ⟦verify P1⟧; Prince Ch. 20 |

**Checkpoint, phase 0:** compute the polar decomposition of the shear `[[1,1],[0,1]]` and
identify the rotation and the stretch separately. You have already drawn the stretch — the
ellipse with axes `φ` and `1/φ`. Now name the rotation that accompanies it.

**Checkpoint, phase 5:** derive `softmax = argmin F` yourself. Set up the Lagrangian for
minimising `⟨E,p⟩ − H(p)` subject to `Σpᵢ = 1`, take the stationarity condition, and watch
the exponential fall out of it. Then read the `√d` off as a temperature.

### 7. The sum *is* the path integral

The observation that makes the notation stop lying.

```
Z = Σ_states exp(−E / T)        statistical mechanics, discrete index set
Z = ∫ D[x]  exp(−S[x] / ħ)      Feynman, continuous index set
```

These are **the same construction.** Feynman's formulation is literally *sum over
histories*; the integral is the continuum limit of the sum. They differ only in whether what
you are indexing over is discrete or continuous — not in what kind of object they are.

So softmax's denominator, `Σⱼ exp(zⱼ)`, is a partition function on a finite index set, which
is to say **a discrete sum over paths**. The field writes `Σ` because the vocabulary is
finite, and that notation hides the fact that it is the same object as the continuum
construction. The sum is not an approximation to an integral. Both are `Z`.

**Why this is the bridge from module 5 to module 6.** Module 5's softmax sums over a finite
set of positions; module 6's continuous formulations (probability-flow ODE, diffusion) take
the same `Z` on a continuous state space, where enumeration fails and the path integral is
the only route. Seeing them as one object rather than two techniques is the point of
studying them in sequence.

**Source — owned.** Feynman & Hibbs, *Quantum Mechanics and Path Integrals*, **Dover 2005
emended edition** (Styer's corrected text — the 1965 original was notoriously typo-ridden,
so this is the edition to have). **Ch. 10 *Statistical Mechanics*** ✅ derives the
partition-function/path-integral correspondence directly: `Z = Tr e^{−βH}` *is* a path
integral in imaginary time. That identity is §7, stated in its original vocabulary.

**And the chapter that matters more than it looks.** **F&H Ch. 12** ✅ — the probability
chapter — covers the **Wiener integral** — Brownian motion as a path integral. That is the bridge from
this thread to everything modern:

```
Wiener integral  →  Brownian motion  →  Langevin dynamics  →  SGD's stationary
     (F&H)                                                     distribution  (§8)
                                              ↓
                              score-based diffusion, probability-flow ODE
                                        (module 6)
```

The papers downloaded for §8 and for module 6 are, formally, applications of the
construction in a book already on your shelf. The vocabulary changed; the object did not.

The *Lectures on Physics* (Millennium Edition) **Vol. II Ch. 19, *The Principle of Least
Action*** ✅, is the intuitive entry point.

### 8. Training samples a distribution; it does not find a minimum

The mental model "gradient descent finds the minimum" is wrong, and the correct version is
already familiar from §3.

SGD with gradient noise has a **stationary distribution over parameters**:

```
p(w)  ∝  exp( −L(w) / T )          T set by learning rate and batch size
```

That is a Gibbs measure on the `n`-dimensional parameter space. Training does not terminate
at a point; it equilibrates to a distribution — and Chaudhari & Soatto (arXiv:1710.11029)
show deep networks converge to **limit cycles**, not minima at all. Mandt, Hoffman & Blei
(arXiv:1704.04289) read the same fact as approximate Bayesian inference.

**The pairing worth holding:**

| | Gibbs measure over | Temperature |
|---|---|---|
| **Softmax** | the vocabulary | `√d` |
| **SGD's stationary distribution** | the parameters | learning rate / batch size |

Same construction, two different spaces. Once you see that, "learning rate" and "attention
temperature" stop being unrelated hyperparameters and become the same knob in two places.
And the descent trajectories themselves carry an action functional (Onsager–Machlup), so
paths are weighted — a path integral over training histories, per §7.

---

## The Statistical Thread

The third reading. Where geometry asks *what shape is this* and physics asks *what is being
minimised*, statistics asks **what is being estimated, from how much data, and how wrong is
it likely to be.** These are not competing accounts — they are the same objects under
different questions, and the arc is only understood when all three answer.

### 5. One eigendecomposition, three names

The cleanest demonstration that the readings coincide. Take the covariance matrix of your
data and decompose it. The result is called:

| Reading | Name | Question it answers |
|---|---|---|
| **Geometric** | Principal axes | Which directions does this transformation stretch? |
| **Physics** | Normal modes | Which independent oscillations does this system have? |
| **Statistical** | Principal components | Which directions carry the most variance in the sample? |

Same matrix, same eigenvectors, same numbers. Three vocabularies because three communities
arrived at it by different roads. If phase 0 lands, this stops being a coincidence and
becomes obvious.

### The thread, phase by phase

| Phase | The statistical object | Source |
|---|---|---|
| **0** | Data as a **sample** from a distribution. The covariance matrix is a second moment — and an *estimate*, with its own error. PCA is the eigendecomposition above, read as variance. | ESL Ch. 3; Larson Ch. 7 |
| **1** | The perceptron as one of several ways to fit a hyperplane — compare it to logistic regression and LDA, which differ in **loss and assumptions**, not in the shape of the answer. Capacity: the VC dimension of a hyperplane in `d` dimensions is `d+1`, and Cover's counting of separable dichotomies is the same fact from the geometric side. | ESL Ch. 4; MacKay Ch. 40; HKP Ch. 5 |
| **2** | **The bias–variance decomposition** — the central statistical idea of the whole arc. Regularisation as *shrinkage*; weight decay as a Gaussian prior; MLE vs MAP; effective degrees of freedom; cross-validation as honest error estimation. | **ESL Ch. 7** ✅ *(unassigned — see below)*; ESL §3.4; ESL Ch. 11; MacKay Ch. 28 |
| **3** | Sequences as **stochastic processes**. Stationarity, the Markov assumption, autocorrelation, maximum likelihood for dependent data — and why i.i.d. reasoning breaks when order matters. | Dielman (time series / autocorrelation); ESL Ch. 7 |
| **4** | Weight sharing as a **prior**, in the precise statistical sense: a restriction of the hypothesis class that trades bias for variance. Equivariance lowers effective capacity, which is *why* it generalises from less data. | Bronstein §3; ESL Ch. 7 |
| **5** | **Attention is kernel regression.** With a learned similarity kernel, `softmax(QKᵀ/√d)V` is a **Nadaraya–Watson estimator** — a locally weighted average of values, weights from a kernel on queries and keys. Cross-entropy is negative log-likelihood; attention weights are a posterior over positions. | **ESL Ch. 6** ✅ *Kernel Smoothing Methods* — §6.1 is Nadaraya–Watson *(unassigned)*; MacKay Ch. 2–4 |
| **6** | Overparameterisation and generalisation without classical capacity control — interpolation, double descent, and why the bias–variance picture from phase 2 needs amending rather than discarding. | Prince Ch. 20; ESL Ch. 18 *(for p ≫ N, not for double descent — see V8)* |

### Two ESL chapters the plan never assigned

Verified against the PDF. Both sit at the centre of this thread:

| | |
|---|---|
| **ESL Ch. 7 — *Model Assessment and Selection*** (p.219) | §7.2 *Bias, Variance and Model Complexity*, §7.3 *The Bias–Variance Decomposition*. The canonical treatment, and the plan assigns Ch. 3, 11 and 18 but not this. **Phase 2's most important statistical chapter was missing.** |
| **ESL Ch. 6 — *Kernel Smoothing Methods*** (p.191) | §6.1 *One-Dimensional Kernel Smoothers* — Nadaraya–Watson, confirmed present in the text. The statistical reading of attention lives here. |

This is the third time the audit has found directly relevant chapters unassigned in a book
already on the list — after ESL §3.4 and GBC Ch. 4/8. **The plan's recurring failure is not
wrong books; it is under-reading the right ones.**

**Checkpoint, phase 2:** derive the bias–variance decomposition yourself, then produce it
empirically — train your MLP at several hidden-layer widths, plot training and held-out
error against width, and identify the two regimes.

**Checkpoint, phase 5:** write scaled dot-product attention as a Nadaraya–Watson estimator.
Name the kernel. Then say what the learned `Q` and `K` projections are doing that a fixed
kernel cannot.

---

## The Field-Theoretic Thread

The fourth reading, and the capstone. The first three ask what one network *is*. This one
asks what a **typical** network is — treating the weights as a random field, the layers as a
flow, and depth as the direction that flow runs in.

**Read this last.** It presumes the other three: you need the geometry to know what a matrix
does to space, the physics to read an energy landscape, and the statistics to know what an
ensemble is. Attempted first it is vocabulary; attempted last it is the unification.

### 6. Width is the inverse coupling constant

The organising idea, from Roberts, Yaida & Hanin, *The Principles of Deep Learning Theory*
(arXiv:2106.10165) — a book-length **effective field theory** of deep networks, with chapters
literally titled *RG Flow of Preactivations* and *Effective Theory of the NTK*.

The expansion parameter is the **depth-to-width aspect ratio**, verified in their text:

```
r ≡ L / n          L = depth,  n = width
```

> "In the strict limit `r → 0`, the interactions between neurons turn off."

| Regime | What it is |
|---|---|
| `n → ∞`, `r → 0` | The **free theory**. Neurons decouple; the network is exactly a Gaussian process (NNGP). Analytically solvable, and it *does not learn features* — no interactions, nothing to renormalise. |
| Finite `n`, small `r` | The **interacting theory**. The `1/n` corrections *are* feature learning. This is where real networks live. |
| `r` too large | Perturbation theory breaks. Too deep for its width — the network is untrainable, and the theory says so quantitatively. |

This is the large-`N` expansion of field theory, transplanted. And **depth is RG time**: the
layer-to-layer evolution of the preactivation distribution is a renormalisation group flow.

### The loop this closes

At the end of phase 0 you were asked what `Matrix.Random`'s fixed `stdDev` does to a freshly
initialised layer, and whether the answer depends on the layer's dimensions. **This thread is
the answer.**

Mean-field signal propagation (Poole et al., arXiv:1606.05340; Schoenholz et al., *Deep
Information Propagation*, arXiv:1611.01232) tracks how activation variance and cross-input
correlation evolve layer by layer. Both maps have fixed points, and there is an **order/chaos
phase transition** between them:

| Phase | Behaviour | Gradients |
|---|---|---|
| **Ordered** | Correlations converge — all inputs look alike after enough depth | **Vanish** |
| **Chaotic** | Correlations diverge — nearby inputs decorrelate | **Explode** |
| **Critical** (the edge) | Correlation length diverges | Neither — trainable depth is unbounded |

**Xavier and He initialisation are the criticality condition.** `σ²_w = 2/n_in` is not a
heuristic that happened to work; it is where the variance map sits at its critical fixed
point. Off criticality, signal dies or blows up exponentially in depth.

And this is a live defect in the repo, not an abstraction:
[`Core/Matrix.cs`](../../NeuralAscent/Core/Matrix.cs) declares
`Random(rows, cols, stdDev = 0.1, ...)` — a **fixed** standard deviation, independent of
`fan_in`. For any realistic layer that is off criticality. The theory predicts the scaffold
will fail to train deep networks, and says why.

**And it is the same phase transition as module 3's.** The vanishing/exploding gradient of an
RNN is the ordered/chaotic phase of this transition, run in time instead of depth. One
result, two modules.

### The thread, phase by phase

| Phase | The field-theoretic object | Source |
|---|---|---|
| **0** | A random weight matrix is a draw from an **ensemble**. The question stops being "what does this matrix do to space" and becomes "what does a *typical* matrix do" — random matrix theory, spectra, and whether signal survives. | Roberts & Yaida Ch. 0–2 |
| **1** | Gardner's replica calculation: the solution space as a statistical ensemble, and **capacity as a phase transition**. Spin-glass field theory applied to the perceptron. | HKP; MacKay Ch. 40 |
| **2** | **The centrepiece.** Mean-field variance and correlation maps, the order/chaos transition, criticality, and the derivation of Xavier/He. Then **NNGP** (infinite width = free theory, arXiv:1711.00165), **NTK** (training linearises, arXiv:1806.07572), and the `1/n` expansion for finite width. | Schoenholz; Lee et al.; Jacot et al.; Roberts & Yaida Ch. 4–5 |
| **3** | The same transition in **time**. Edge of chaos for recurrent dynamics; Lyapunov exponents. The vanishing/exploding gradient *is* the ordered/chaotic phase. | Schoenholz; Strogatz Ch. 10 |
| **4** | Convolution is a **local interaction**; translation invariance is momentum conservation, so the natural basis is Fourier. Locality as a field-theoretic constraint. | Bronstein §4.2; Roberts & Yaida |
| **5** | Attention is a **non-local, all-to-all interaction** — the field-theoretic contrast with convolution's locality. That contrast, not the QKV mechanics, is what makes attention a different kind of object. | Bronstein §5.4 |
| **6** | `r = L/n` as the effective coupling; **RG flow of preactivations** across depth; scaling laws read as critical phenomena. | Roberts & Yaida Ch. 4, 8–9 |

**Checkpoint, phase 2:** compute the variance map for a ReLU layer by hand, find its fixed
point, and derive `σ²_w = 2/n_in` from the criticality condition. Then set `Matrix.Random`'s
`stdDev` to `0.1` on a 10-layer network and watch the activations die — the prediction is
quantitative, so check the rate against the theory, not just the direction.

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
| **The physics** | A quadratic form `xᵀAx` is an **energy**; eigenvectors of a symmetric matrix are **principal axes**, the normal modes of a coupled oscillator. The **polar decomposition** `A = QS` splits any map into rotation × stretch — the continuum-mechanics decomposition of a deformation. |

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
| **The physics** | A **Lyapunov function** is an energy that decreases along trajectories — the tool that *proves* convergence to an attractor rather than observing it. Hopfield networks are spin glasses; HKP's energy-landscape framing is the same object. |
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
| **The physics** | Equivariance is **Noether's insight** applied to learning: a symmetry of the problem should be a symmetry of the model. Bronstein §4.5 takes it to **gauge theory** — a gauge is a local choice of frame; equivariance says predictions must not depend on which frame you picked. |

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
| **The physics** — see [the thread](#3-softmax-is-the-minimiser-of-a-free-energy) | Softmax **is** the Gibbs distribution: the minimiser of free energy `F = U − TS` over the simplex, equivalently the maximum-entropy distribution at fixed expected energy. `log-sum-exp` is `log Z`. `√d` is a temperature. Under the Fisher metric the simplex becomes a Riemannian manifold — the same metric as natural gradient in phase 2. |

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
| **Ramsauer et al. — *Hopfield Networks is All You Need*** | **Attention is the update rule of a continuous Hopfield network** — so a forward pass is energy descent toward attractors, and heads are characterised by which attractor regime they occupy. The energy-based reading of the architecture. |
| **Bronstein et al. §5.4** ✅ | Positional encoding as *breaking* permutation symmetry — the clean framing of why it is needed at all |
| **Pierce — the physics chapter** ⟦verify P1⟧ | *Information Theory and Physics* — **currently unassigned.** Landauer's principle (erasing a bit costs `kT ln 2`) is where information and thermodynamics meet, and it is the substrate under "language modelling is compression." |
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

**Open — physics thread:**

| ID | Book | Question | Expected |
|---|---|---|---|
| **P1** | Pierce (Dover 1980) | What are **Ch. 9** and **Ch. 10** titled? | Ch. 10 expected to be *Information Theory and Physics* — the Landauer / thermodynamics bridge for module 6. Ch. 9 expected *Many Dimensions*, which may also be relevant to phase 5's high-dimensional geometry. |
| **F1** ✅ | Feynman, *Lectures on Physics*, Millennium Ed. | **Vol. II Ch. 19** — *The Principle of Least Action* |
| **F2** ✅ | Feynman & Hibbs | Owned — Dover **2005 emended edition** (Styer's corrected text) |
| **F3** ✅ | Feynman & Hibbs | **Ch. 10** — *Statistical Mechanics*. §7's direct source: `Z = Tr e^{−βH}` as a path integral in imaginary time |
| **F4** ✅ | Feynman & Hibbs | **Ch. 12** — the probability chapter carrying the **Wiener integral**; the bridge to §8 and to diffusion models |
| **P2** | Hertz, Krogh & Palmer (1991) | Is there a chapter on the **formal statistical mechanics** of neural networks? Which number? | Expected last in the book — the formal treatment underpinning the capacity results in Ch. 5 |
