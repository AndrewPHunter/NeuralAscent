# Source Texts

Local copies of the freely available texts, plus a link to the one that has no legal
electronic copy. **Everything in this folder except this README is gitignored** — the books
are free to obtain but not mine to redistribute, so the repo carries the instructions and
not the files.

Run the commands below from the repository root to populate the folder.

---

## MacKay — *Information Theory, Inference, and Learning Algorithms* (CUP, 2003)

Free from the author's own site. Cambridge's notice on every page permits on-screen
viewing but not printing.

```bash
curl -o "docs/learning/texts/mackay-itila.pdf" http://www.inference.org.uk/itprnn/book.pdf
```

- Homepage: <https://www.inference.org.uk/mackay/itila/>
- 11.7 MB · SHA-256 `868adc5f0ef6630366b122d88d691acfbe8339978b4ec3f38fca5e231f135791`

---

## Hastie, Tibshirani & Friedman — *The Elements of Statistical Learning* (Springer, 2009)

2nd edition, **12th printing with corrections and table of contents, Jan 2017** — newer
than most print copies. Springer has agreed to keep the book on the web; the download page
redirects to Google Drive.

```bash
curl -L -o "docs/learning/texts/esl-2nd-print12.pdf" \
  "https://drive.google.com/uc?export=download&id=1--Wo5Hcl2y_v3DL-tGgcJHRPdtjiVYjS"
```

- Download page: <https://hastie.su.domains/ElemStatLearn/download.html>
- 13.4 MB · 764 pp. · SHA-256 `8d098d65cf53925ba0fc13a52a2790d48a32433223cbd876d0a527cd1afe2e0f`

---

## Goodfellow, Bengio & Courville — *Deep Learning* (MIT Press, 2016)

**No PDF exists, by contract.** The authors state it plainly in their FAQ:

> Can I get a PDF of this book? No, our contract with MIT Press forbids distribution of too
> easily copied electronic formats of the book.
>
> Why are you using HTML format? This format is a sort of weak DRM required by our contract
> with MIT Press.

The free HTML edition is the only authorised electronic form. Unofficial PDFs circulate;
they are unauthorised redistribution and are not used here.

- Read online: <https://www.deeplearningbook.org/>
- `Deep Learning (Goodfellow) — read online.webloc` in this folder opens it directly.

---

## Prince — *Understanding Deep Learning* (MIT Press, 2023)

Free PDF from the author's own GitHub, distributed as **versioned releases** — pin the
version rather than tracking `latest`, so a citation stays valid.

```bash
curl -L -o "docs/learning/texts/prince-udl-v5.0.3.pdf" \
  "https://github.com/udlbook/udlbook/releases/download/v5.0.3/UnderstandingDeepLearning_02_09_26_C.pdf"
```

- Homepage: <https://udlbook.github.io/udlbook/> · Releases: <https://github.com/udlbook/udlbook/releases>
- **v5.0.3** · 21 MB · 541 pp. · SHA-256 `f8237d393163900fa8e43210e680a3f987b45ccac7750b372e156fae3df0bf32`

---

## Jurafsky & Martin — *Speech and Language Processing*, 3rd ed. (draft)

Free from Stanford. **This is a living draft and chapters are renumbered between
releases** — the authors' own page records that the former Ch. 8 (Transformers) was merged
into Ch. 7. Always cite the dated file, never "the current draft".

```bash
curl -L -o "docs/learning/texts/jurafsky-martin-slp3-aug26.pdf" \
  "https://web.stanford.edu/~jurafsky/slp3/ed3book_aug26.pdf"
```

- Homepage: <https://web.stanford.edu/~jurafsky/slp3/>
- **Aug 2026 draft** · 25 MB · 646 pp. · SHA-256 `88d0362c3bcb62a0cd09403fb80fd15e778dd53566943912ab1047cda3ff5c79`

---

## Geometric Lens — Free Sources

Added to support a geometry-first reading of the arc. See
[`../geometric-lens.md`](../geometric-lens.md).

### Bronstein, Bruna, Cohen & Veličković — *Geometric Deep Learning: Grids, Groups, Graphs, Geodesics, and Gauges* (2021)

```bash
curl -L -o "docs/learning/texts/bronstein-geometric-deep-learning.pdf" "https://arxiv.org/pdf/2104.13478"
```

- arXiv: <https://arxiv.org/abs/2104.13478> · 43 MB · 160 pp.
- SHA-256 `dcf8212ed37db9ac154ac975b8f9c7d36831cf56b75261679b04ab9814985fc2`

### Blum, Hopcroft & Kannan — *Foundations of Data Science*

```bash
curl -L -o "docs/learning/texts/blum-hopcroft-kannan-fods.pdf" "https://www.cs.cornell.edu/jeh/book.pdf"
```

- Hosted by Hopcroft at Cornell: <https://www.cs.cornell.edu/jeh/book.pdf> · 2.4 MB · 479 pp.
- SHA-256 `7412c43877d8f460ba73739e0e5da8d5a3d8b0262475d10bb4897fe569b449f8`

### Web-only (`.webloc` shortcuts in this folder)

| Resource | URL |
|---|---|
| 3Blue1Brown — *Essence of Linear Algebra* | <https://www.3blue1brown.com/topics/linear-algebra> |
| Olah — *Neural Networks, Manifolds, and Topology* | <https://colah.github.io/posts/2014-03-NN-Manifolds-Topology/> |
| Elhage et al. — *A Mathematical Framework for Transformer Circuits* | <https://transformer-circuits.pub/2021/framework/index.html> |

---

## Energy-Based Reading — Papers

The energy-based account of the architecture: attention as energy descent, surprisal as
work, likelihood as a path integral. See
[`../geometric-lens.md`](../geometric-lens.md#4-attention-is-energy-descent-and-the-line-integral-is-not-a-metaphor).

```bash
curl -L -o "docs/learning/texts/ramsauer-hopfield-is-all-you-need.pdf"        "https://arxiv.org/pdf/2008.02217"
curl -L -o "docs/learning/texts/song-score-based-sde.pdf"                     "https://arxiv.org/pdf/2011.13456"
curl -L -o "docs/learning/texts/lou-score-entropy-discrete-diffusion.pdf"     "https://arxiv.org/pdf/2310.16834"
```

| Paper | arXiv | Why |
|---|---|---|
| Ramsauer et al., *Hopfield Networks is All You Need* | [2008.02217](https://arxiv.org/abs/2008.02217) | Proves the modern Hopfield update **is** transformer attention; three kinds of energy minima. 94 pp. |
| Song et al., *Score-Based Generative Modeling through SDEs* | [2011.13456](https://arxiv.org/abs/2011.13456) | Probability-flow ODE — log-likelihood as a line integral. 36 pp. |
| Lou et al., *Score Entropy Discrete Diffusion* | [2310.16834](https://arxiv.org/abs/2310.16834) | The "yet" — path-based generation reaching discrete language. 30 pp. |

---

## Field-Theoretic Reading — Papers

Deep networks as random fields: mean-field signal propagation, criticality, the infinite-width
limit, and the `1/n` expansion. See
[`../geometric-lens.md`](../geometric-lens.md#the-field-theoretic-thread).

```bash
curl -L -o "docs/learning/texts/roberts-yaida-principles-of-dl-theory.pdf"    "https://arxiv.org/pdf/2106.10165"
curl -L -o "docs/learning/texts/schoenholz-deep-information-propagation.pdf"  "https://arxiv.org/pdf/1611.01232"
curl -L -o "docs/learning/texts/jacot-neural-tangent-kernel.pdf"              "https://arxiv.org/pdf/1806.07572"
curl -L -o "docs/learning/texts/lee-dnn-as-gaussian-processes.pdf"            "https://arxiv.org/pdf/1711.00165"
```

| Source | arXiv | Why |
|---|---|---|
| **Roberts, Yaida & Hanin, *The Principles of Deep Learning Theory*** | [2106.10165](https://arxiv.org/abs/2106.10165) | **The primary text.** A book-length effective field theory — chapters on *RG Flow of Preactivations* and *Effective Theory of the NTK*. The `1/n` expansion, with `r = L/n` as the coupling. 471 pp. |
| Schoenholz et al., *Deep Information Propagation* | [1611.01232](https://arxiv.org/abs/1611.01232) | Order/chaos transition; criticality; where Xavier/He come from. 18 pp. |
| Jacot et al., *Neural Tangent Kernel* | [1806.07572](https://arxiv.org/abs/1806.07572) | Training dynamics in the infinite-width limit. 19 pp. |
| Lee et al., *Deep Neural Networks as Gaussian Processes* | [1711.00165](https://arxiv.org/abs/1711.00165) | The free theory: infinite width **is** a Gaussian process. 17 pp. |

Also relevant, not downloaded: Poole et al., *Exponential expressivity through transient
chaos* ([1606.05340](https://arxiv.org/abs/1606.05340)); Halverson, Maiti & Stoner, *Neural
Networks and Quantum Field Theory* ([2008.08601](https://arxiv.org/abs/2008.08601)).

---

## Descent as Sampling — Papers

Training does not find a minimum; it equilibrates to a Gibbs measure over parameters. See
[`../geometric-lens.md`](../geometric-lens.md#8-training-samples-a-distribution-it-does-not-find-a-minimum).

```bash
curl -L -o "docs/learning/texts/chaudhari-soatto-sgd-variational-inference.pdf" "https://arxiv.org/pdf/1710.11029"
curl -L -o "docs/learning/texts/mandt-sgd-approximate-bayesian.pdf"            "https://arxiv.org/pdf/1704.04289"
```

| Paper | arXiv | Why |
|---|---|---|
| Chaudhari & Soatto, *SGD performs variational inference, converges to limit cycles* | [1710.11029](https://arxiv.org/abs/1710.11029) | Deep networks converge to limit cycles, not minima. 20 pp. |
| Mandt, Hoffman & Blei, *SGD as Approximate Bayesian Inference* | [1704.04289](https://arxiv.org/abs/1704.04289) | The same fact read as inference. 35 pp. |

**Feynman**, for §7 (the sum is the path integral): *Quantum Mechanics and Path Integrals*
(with Hibbs, Dover) and *Statistical Mechanics: A Set of Lectures* — the latter derives the
partition-function/path-integral correspondence directly. The *Lectures on Physics* are free
at <https://www.feynmanlectures.caltech.edu/> (the site blocks automated fetches, so the
least-action chapter number is unverified — see F1).

---

## Everything else

The remaining seven texts are print only. See [`../library.md`](../library.md).
