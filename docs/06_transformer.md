# The Transformer

> *"We propose a new simple network architecture, the Transformer, based solely on attention mechanisms, dispensing with recurrence and convolutions entirely."*
> — Vaswani et al., "Attention Is All You Need", 2017

---

## Historical Context

**Who:** Ashish Vaswani, Noam Shazeer, Niki Parmar, Jakob Uszkoreit, Llion Jones, Aidan N. Gomez, Łukasz Kaiser, Illia Polosukhin (Google Brain / Research)
**When:** June 2017 (NeurIPS 2017)
**Problem:** The RNN's sequential computation prevents parallelism. Attention solves long-range dependencies but was typically bolted onto RNNs. Can attention do the entire job?

The answer was yes, and the consequences were staggering. The Transformer became the backbone of BERT (2018), GPT (2018, 2019, 2020, ...), T5, PaLM, LLaMA, Claude, and effectively every large language model in production today. It also spread into computer vision (ViT, 2020), protein structure prediction (AlphaFold2, 2021), and audio (Whisper, 2022).

The title "Attention Is All You Need" was a deliberate provocation. It was accurate.

---

## Core Intuition

The Transformer encoder processes a sequence of token embeddings in parallel. Each token attends to every other token simultaneously, with learned attention patterns determining what information flows where. Recurrence is gone. Position must be encoded explicitly.

Stacking identical encoder blocks — each containing multi-head attention, a feed-forward network, residual connections, and layer normalisation — builds up increasingly abstract representations with each layer.

The key engineering moves:
1. **Multi-head attention:** Run several attention operations in parallel with different learned projections. Each "head" can specialise in different types of relationships.
2. **Residual connections:** `output = LayerNorm(x + Sublayer(x))`. The residual stream ensures gradients flow cleanly through many layers.
3. **Layer normalisation:** Normalise across the feature dimension (not the batch dimension). Stabilises training.
4. **Parallel computation:** No step-by-step recurrence. The entire sequence is processed at once.

---

## Key Mathematics

**Positional encoding** (sinusoidal, fixed):

```
PE(pos, 2i)   = sin(pos / 10000^(2i / d_model))
PE(pos, 2i+1) = cos(pos / 10000^(2i / d_model))
```

Added to the input embeddings before the first encoder block. The sinusoidal form allows the model to generalise to sequence lengths not seen during training via linear combinations.

**Multi-head attention:**

```
head_j = Attention(Q·W_Q_j, K·W_K_j, V·W_V_j)
MultiHead(Q,K,V) = Concat(head_1, ..., head_h) · W_O
```

Where each `W_Q_j`, `W_K_j`, `W_V_j` is `[d_model × d_k]` with `d_k = d_model / h`.

**Position-wise feed-forward network:**

```
FFN(x) = max(0, x·W₁ + b₁) · W₂ + b₂
```

`W₁` is `[d_model × d_ff]`, `W₂` is `[d_ff × d_model]`. Typically `d_ff = 4 × d_model`.

Applied identically to each position — no interaction between positions in the FFN.

**Encoder block:**

```
x₁ = LayerNorm(x + MultiHeadAttention(x, x, x))
x₂ = LayerNorm(x₁ + FFN(x₁))
```

Stack N of these (N=6 in the original paper).

---

## Limitations

**Quadratic self-attention.** The attention matrix is `O(n²)` in sequence length `n`. For very long sequences (books, entire codebases, long audio), this is a serious constraint. Active research: sparse attention, linear attention, state-space models (Mamba, 2023).

**Fixed context window.** Standard Transformers have a maximum sequence length determined at training time. Extending to longer sequences requires architectural changes (RoPE, ALiBi, sliding window attention).

**Position encoding is non-trivial.** The sinusoidal encoding works but learned positional embeddings, relative position encodings (T5, Shaw et al.), and rotary position embeddings (RoPE, Su et al.) have all been proposed and studied extensively.

**Data hungry.** Large Transformers require large amounts of data to train well. The architecture itself does not encode much inductive bias — it learns from data. This is both its power (generalises across domains) and its cost (needs enormous training sets).

---

## Implementation Notes

See `Networks/06_Transformer/Transformer.cs` (scaffold — to be implemented).

The minimal encoder-only implementation here will:
1. Embed tokens and add positional encoding — visualise the resulting encoding as an ASCII heatmap
2. Implement one multi-head attention block with h=2 or h=4 heads
3. Show the attention weights for each head separately — note that different heads often learn different patterns
4. Include the FFN and Add & Norm steps
5. Train on a character-level language modelling task (predict next character from context)

The positional encoding visualisation is particularly instructive: plot PE(pos, i) for all positions and dimensions and observe the regular wave pattern — the "compass" the model uses to orient itself in the sequence.

---

## References

1. Vaswani, A., et al. (2017). *Attention is all you need.* NeurIPS 2017. [arXiv:1706.03762](https://arxiv.org/abs/1706.03762)
2. Devlin, J., Chang, M.W., Lee, K., & Toutanova, K. (2019). *BERT: Pre-training of deep bidirectional Transformers for language understanding.* NAACL 2019.
3. Radford, A., et al. (2018). *Improving language understanding by generative pre-training.* OpenAI blog.
