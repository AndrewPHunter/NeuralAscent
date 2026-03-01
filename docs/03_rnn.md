# The Recurrent Neural Network (RNN)

> *"The key idea is to use backpropagation through time to train the recurrent connections."*
> — Rumelhart, Hinton & Williams, 1986

---

## Historical Context

**Who:** Rumelhart, Hinton & Williams (BPTT); Jordan (1986), Elman (1990) (architectures)
**When:** 1986–1990
**Problem:** The MLP takes a fixed-size vector as input. Language, audio, and time series have variable length and sequential structure. How do we train a network on data where order matters?

The RNN introduces a *recurrence*: the network's output (or some internal state) at time step `t` is fed back as an additional input at step `t+1`. This gives the network a form of memory — earlier inputs influence later outputs through the hidden state.

Jeff Elman's 1990 paper "Finding Structure in Time" popularised the simple recurrent architecture now known as the Elman RNN, demonstrating that such networks could learn grammatical structure from sequence data.

---

## Core Intuition

At each time step, the RNN receives:
- The current input `x_t`
- The hidden state from the previous step `h_{t-1}`

It produces:
- An updated hidden state `h_t` (the "memory" carried forward)
- An output `y_t`

The hidden state is a fixed-size vector that accumulates a compressed summary of everything the network has seen so far in the sequence. The same weight matrices are reused at every time step — this weight sharing across time is what makes the network capable of handling variable-length sequences.

---

## Key Mathematics

**Hidden state update:**

```
h_t = tanh(W_hh · h_{t-1} + W_xh · x_t + b_h)
```

**Output:**

```
y_t = W_hy · h_t + b_y
```

**Backpropagation Through Time (BPTT):**

Unroll the network for T steps. The gradient with respect to `W_hh` accumulates across all time steps:

```
∂L/∂W_hh = Σ_t ∂L_t/∂W_hh
```

Each `∂L_t/∂W_hh` involves a product of Jacobians through time:

```
∂h_t/∂h_k = Π_{i=k+1}^{t} ∂h_i/∂h_{i-1}
```

This product is what causes vanishing or exploding gradients.

---

## Limitations

**Vanishing gradients.** The product of many Jacobians (each involving `tanh'`, which is at most 1) shrinks exponentially as the gap between `t` and `k` grows. In practice, standard RNNs have difficulty learning dependencies separated by more than 10–20 time steps.

**Exploding gradients.** If the Jacobian product is greater than 1, gradients can grow exponentially. Gradient clipping (capping the gradient norm) is the standard remedy, but it does not solve the underlying issue.

**Sequential computation.** Processing a sequence of length T requires T sequential steps — no parallelism. This makes RNNs slow to train on long sequences with modern hardware, which is optimised for parallel computation.

**Solutions (not covered in this module):** LSTMs (Hochreiter & Schmidhuber, 1997) and GRUs (Cho et al., 2014) introduce *gating* mechanisms that give the network explicit control over what to remember and what to forget, substantially improving long-range memory. These are not dead ends — they remained state-of-the-art for sequence modelling until the Transformer.

---

## Implementation Notes

See `Networks/03_RNN/RNN.cs` (scaffold — to be implemented).

Key implementation details to get right:
- The hidden state `h_0` is initialised to zeros
- `W_hh` must be initialised carefully — too large and gradients explode immediately
- Gradient clipping: compute the global norm of all gradients; if it exceeds a threshold, scale all gradients down proportionally
- The vanishing gradient demo: log the magnitude of `∂h_0/∂h_T` as T increases — watch it collapse toward zero

---

## References

1. Rumelhart, D.E., Hinton, G.E., & Williams, R.J. (1986). *Learning representations by back-propagating errors.* Nature, 323, 533–536.
2. Elman, J.L. (1990). *Finding structure in time.* Cognitive Science, 14(2), 179–211.
3. Hochreiter, S., & Schmidhuber, J. (1997). *Long short-term memory.* Neural Computation, 9(8), 1735–1780.
