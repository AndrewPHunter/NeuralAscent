# NeuralAscent — The Full Arc

Six architectures. One through-line. Each step a response to a failure of the previous.

---

## Why This Sequence?

The history of deep learning is not a sequence of independent discoveries — it is a sequence of *problems and responses*. Each architecture in this list was motivated by a specific, documented failure of the one before it:

| Architecture | Problem It Solved | Limitation It Left |
|---|---|---|
| Perceptron | Learning from examples | Cannot solve XOR (non-linear problems) |
| MLP | Non-linear decision boundaries | Cannot handle sequential/temporal data |
| RNN | Sequential data with memory | Vanishing gradients — forgets long-range context |
| CNN | Spatial structure, weight sharing | No attention — every position treated equally |
| Attention | Selective focus, any-to-any relationships | Recurrent bottleneck in encoder-decoder |
| Transformer | Parallel attention, no recurrence | (current frontier) |

The arc is not decorative. It is the argument.

---

## Stop 1: The Perceptron (1957)

Frank Rosenblatt's Perceptron was the first demonstration that a machine could *learn* a linear classifier from data, rather than having the classifier programmed in by hand. The learning rule is elegant: update weights by the signed error, scaled by the input.

The Perceptron convergence theorem guarantees that if the data is linearly separable, training will terminate. The problem is that most interesting problems are not linearly separable. Minsky and Papert's 1969 book *Perceptrons* proved this formally for XOR, among others, and the field largely stalled.

**What the Perceptron gives us:** the idea of gradient-like local weight updates. Everything after it is, in some sense, an extension.

---

## Stop 2: The MLP and Backpropagation (1986)

The key insight of the MLP is: stack linear layers with non-linear activations between them and you get a function capable of approximating *any* continuous mapping (the universal approximation theorem). The key engineering achievement is backpropagation — an efficient algorithm for computing the gradient of the loss with respect to every weight in the network, via the chain rule.

Rumelhart, Hinton, and Williams' 1986 paper made backprop practical. The XOR problem that defeated the Perceptron is trivially solved by a two-layer network with sigmoid activations.

**What the MLP gives us:** universal function approximation and a principled training algorithm. The era of deep learning begins here, conceptually, even if the hardware to make it practical arrived decades later.

---

## Stop 3: The RNN (1986)

Once you can approximate functions, the next question is: what about *sequences*? Language, audio, time series — data where order matters and where earlier inputs should influence later outputs.

The RNN introduces a hidden state: a vector that is updated at each time step and carries information forward. The hidden state is the network's "memory". Backpropagation through time (BPTT) unrolls the network across time steps and computes gradients by the chain rule, just as in the MLP.

The problem is that gradients flowing backwards through many time steps either vanish (exponentially small) or explode (exponentially large). In practice, RNNs struggle to learn dependencies separated by more than 10–20 time steps. LSTMs and GRUs (later) partially address this with gated architectures, but the fundamental limitation remains.

**What the RNN gives us:** sequential processing with memory. **What it cannot give us:** reliable long-range context.

---

## Stop 4: The CNN (1989)

Vision is different from sequences: spatial structure matters, but the *same pattern* can appear at any location in the image. A dog-detector should fire whether the dog is in the top-left or bottom-right of the frame.

The CNN's answer is *weight sharing*: the same learned kernel is convolved across the entire input. This simultaneously reduces the number of parameters (one kernel serves all positions) and builds in translation equivariance. Pooling layers reduce spatial resolution and build in coarser invariance.

LeCun et al.'s LeNet (1989, 1998) demonstrated this on handwritten digit recognition. AlexNet (2012) demonstrated it at scale.

**What the CNN gives us:** efficient spatial feature extraction with far fewer parameters than a dense network. **What it cannot give us:** relationships between distant positions — every convolution is local.

---

## Stop 5: Attention (2015)

The encoder-decoder RNN architecture (Sutskever et al., 2014) compressed an entire input sequence into a single fixed-length vector, then decoded from it. For long sequences, this bottleneck was severe.

Bahdanau et al. (2015) proposed attention: instead of compressing to a single vector, let the decoder *attend to all encoder states*, with learned weights determining how much attention to pay to each. The attention mechanism computes a weighted sum of values (encoder states), where the weights are derived from the compatibility of the decoder's current query with each encoder key.

This is the Query-Key-Value formulation that Vaswani et al. later formalised and scaled.

**What attention gives us:** any-to-any relationships, no distance penalty, interpretable alignment.

---

## Stop 6: The Transformer (2017)

"Attention Is All You Need." Vaswani et al. removed the recurrence entirely. If attention can capture any relationship between any two positions, why maintain the sequential computation of an RNN at all?

The Transformer encodes position via sinusoidal positional embeddings (not recurrence), uses multi-head attention to capture different types of relationships in parallel, and stacks identical encoder blocks. The result is massively parallelisable — training on modern hardware becomes feasible for large corpora — and the architecture generalises across language, vision, audio, and code.

Every large language model in production today is a Transformer variant.

**What the Transformer gives us:** the architecture that ended the era of task-specific models and began the era of foundation models.

---

## Navigating the Repo

Each network has two files under `Networks/NN_Name/`:
- **`Name.cs`** — the core class implementing the math
- **`NameRunner.cs`** — the `INetwork` implementation wiring the class to the CLI

Theory notes for each network live in `docs/0N_name.md`.

The `Core/` layer provides the shared primitives: matrix operations, activation functions, and utilities. Networks 01 and above use these directly — no framework abstractions in between.
