# Attention Mechanisms

> *"We propose a novel approach... which learns to align and translate jointly."*
> — Bahdanau, Cho & Bengio, 2015

---

## Historical Context

**Who:** Dzmitry Bahdanau, Kyunghyun Cho, Yoshua Bengio (additive attention, 2015);
Minh-Thang Luong et al. (multiplicative/dot-product attention, 2015);
Vaswani et al. (scaled dot-product, used in Transformer, 2017)
**When:** 2015
**Problem:** Encoder-decoder RNNs compress an entire input sequence into a single fixed-size vector. For long sequences — long sentences in machine translation — this bottleneck is severe. Information is lost.

The fix is: instead of compressing to a single vector, let the decoder look at *all* encoder states, and learn to *weight* them differently depending on what it is currently generating.

This is attention. And it turns out to be one of the most important ideas in the history of the field.

---

## Core Intuition

Think of a dictionary. You have a query (what you are looking for) and a set of key-value pairs (what is available). You match the query against each key to get a score, normalise the scores into weights with softmax, and take a weighted sum of the values.

In neural network attention:
- **Query (Q):** the decoder's current state — "what am I looking for right now?"
- **Keys (K):** representations of the encoder states — "what does each input position offer?"
- **Values (V):** the actual content to retrieve — "given the match, what information do I pull?"

The dot product `Q·Kᵀ` measures compatibility. Softmax turns these into a probability distribution. Multiplying by V yields the attended representation.

Every output position can attend to every input position. There is no distance penalty. A network can learn that the word "bank" in the output depends on the word "river" 20 positions earlier in the input, if that dependency exists in the data.

---

## Key Mathematics

**Scaled dot-product attention:**

```
Attention(Q, K, V) = softmax(Q · Kᵀ / √d_k) · V
```

Where `d_k` is the dimension of the key vectors.

**Why √d_k?** The dot product `Q·Kᵀ` grows in magnitude with `d_k`. For large `d_k`, the pre-softmax values can be very large, pushing softmax into regions where the gradient is near zero. Scaling by `1/√d_k` keeps the magnitudes stable.

**Projections:**

```
Q = X · W_Q     (shape: [seq_len × d_k])
K = X · W_K     (shape: [seq_len × d_k])
V = X · W_V     (shape: [seq_len × d_v])
```

The weight matrices `W_Q`, `W_K`, `W_V` are learned — they project the input into a space where relevant relationships are easier to measure by dot product.

**Attention weights:**

```
A = softmax(Q · Kᵀ / √d_k)     (shape: [seq_len × seq_len])
```

`A[i, j]` is "how much position `i` attends to position `j`". This matrix is interpretable and interesting to visualise.

**Output:**

```
O = A · V     (shape: [seq_len × d_v])
```

---

## Limitations

**Quadratic complexity.** The attention weight matrix `A` is `[seq_len × seq_len]`. For long sequences, this becomes prohibitively expensive — both in memory and computation. Sparse attention, linear attention, and other approximations are active research areas.

**No recurrence, no built-in position.** Pure attention has no notion of position. If you permute the input, the output permutes identically. Positional information must be added explicitly — either via sinusoidal encodings (Transformer) or learned positional embeddings. This is addressed in the next module.

**Attention is not explanation.** Attention weights are sometimes interpreted as "what the model focuses on", but this is not strictly true — the weights are part of the computation, not necessarily a faithful map of importance. Use with care.

---

## Implementation Notes

See `Networks/05_Attention/Attention.cs` (scaffold — to be implemented).

When implementing, the most instructive demo is a visualisation of the attention weight matrix `A`:
- Rows represent output positions
- Columns represent input positions
- Bright (high-weight) cells show which input positions each output position attended to

A "copy" or "reverse" task makes this concrete: train a network to copy or reverse a short sequence, then visualise the attention weights — you should see a diagonal or anti-diagonal pattern emerge.

---

## References

1. Bahdanau, D., Cho, K., & Bengio, Y. (2015). *Neural machine translation by jointly learning to align and translate.* ICLR 2015.
2. Luong, M.T., Pham, H., & Manning, C.D. (2015). *Effective approaches to attention-based neural machine translation.* EMNLP 2015.
3. Vaswani, A., et al. (2017). *Attention is all you need.* NeurIPS 2017.
