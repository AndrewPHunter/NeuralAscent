# The Multi-Layer Perceptron (MLP)

> *"We describe a new learning procedure, back-propagation, for networks of neuron-like units."*
> — Rumelhart, Hinton & Williams, 1986

---

## Historical Context

**Who:** David Rumelhart, Geoffrey Hinton, Ronald J. Williams
**When:** 1986 (popularised); variations explored earlier by Werbos (1974), Parker (1985)
**Problem:** The Perceptron cannot learn non-linear functions. Can multiple layers with differentiable activations solve this?

The idea of stacked layers predates 1986 — Alexey Ivakhnenko and Valentin Lapa had explored deep networks in the 1960s, and Paul Werbos described the backpropagation algorithm in his 1974 thesis. But it was Rumelhart, Hinton, and Williams' 1986 Nature paper, "Learning representations by back-propagating errors," that made the algorithm widely known and sparked the modern era of neural network research.

The key insight is not the architecture — stacked layers are obvious — but the *algorithm*: an efficient method for computing how much each weight in an arbitrarily deep network contributes to the output error.

---

## Core Intuition

Stack linear layers with non-linear activations between them. Each layer learns a transformation of the previous layer's representation. With sufficient width and depth, the network can approximate any continuous function (the *universal approximation theorem*, Cybenko 1989, Hornik 1991).

The non-linearity is essential. Without it, any stack of linear layers collapses to a single linear transformation: `W₃(W₂(W₁x)) = (W₃W₂W₁)x`. The sigmoid, ReLU, and tanh activations break this collapse, giving each layer the ability to learn non-linear features.

The XOR problem is the canonical example: a 2→2→1 network with sigmoid activations trains to near-zero loss where the Perceptron loops forever.

---

## Key Mathematics

**Forward pass** (for one layer):

```
z⁽ˡ⁾ = W⁽ˡ⁾ · a⁽ˡ⁻¹⁾ + b⁽ˡ⁾      (pre-activation)
a⁽ˡ⁾ = σ(z⁽ˡ⁾)                    (activation)
```

**Loss** (Mean Squared Error for simplicity):

```
L = (1/n) Σᵢ (yᵢ − ŷᵢ)²
```

**Backward pass** (chain rule):

```
Output layer:   δ⁽ᴸ⁾ = (ŷ − y) ⊙ σ'(z⁽ᴸ⁾)
Hidden layers:  δ⁽ˡ⁾ = (W⁽ˡ⁺¹⁾ᵀ · δ⁽ˡ⁺¹⁾) ⊙ σ'(z⁽ˡ⁾)

∂L/∂W⁽ˡ⁾ = δ⁽ˡ⁾ · (a⁽ˡ⁻¹⁾)ᵀ
∂L/∂b⁽ˡ⁾ = δ⁽ˡ⁾
```

**Weight update** (gradient descent):

```
W⁽ˡ⁾ ← W⁽ˡ⁾ − η · ∂L/∂W⁽ˡ⁾
b⁽ˡ⁾ ← b⁽ˡ⁾ − η · ∂L/∂b⁽ˡ⁾
```

The `⊙` operator is element-wise multiplication (Hadamard product). `σ'` is the derivative of the activation function — this is why we need differentiable activations.

---

## Limitations

**Vanishing gradients.** The sigmoid derivative reaches a maximum of 0.25 at x=0 and shrinks towards zero as |x| grows. In a deep network, the chain rule multiplies these small values together. By the time the gradient reaches the early layers, it may be so small that learning effectively stops. This is the vanishing gradient problem. ReLU activations (Nair & Hinton, 2010) partially address this by having a derivative of 1 for positive inputs.

**No notion of sequence.** An MLP treats each input as an independent, fixed-length vector. It has no mechanism for handling inputs of variable length or for using the ordering of inputs as signal. For language or time series, we need something that understands sequence. That is the RNN.

---

## Implementation Notes

See `Networks/02_MLP/MLP.cs` (scaffold — to be implemented).

When implementing, key choices to make explicit:
- Weight initialisation: Xavier uniform for sigmoid (`√(6/(fan_in + fan_out))`), He for ReLU (`√(2/fan_in)`)
- Activation: sigmoid for the hidden layer XOR demo; note how swapping to ReLU changes convergence speed
- The `δ` (delta) computation is the crux — follow the chain rule step by step, do not collapse it

---

## References

1. Rumelhart, D.E., Hinton, G.E., & Williams, R.J. (1986). *Learning representations by back-propagating errors.* Nature, 323, 533–536.
2. Cybenko, G. (1989). *Approximation by superpositions of a sigmoidal function.* Mathematics of Control, Signals, and Systems, 2(4), 303–314.
3. Werbos, P. (1974). *Beyond regression: New tools for prediction and analysis in the behavioral sciences.* PhD thesis, Harvard University.
