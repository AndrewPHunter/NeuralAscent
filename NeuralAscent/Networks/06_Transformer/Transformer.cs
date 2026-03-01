namespace NeuralAscent.Networks._06_Transformer;

/// <summary>
/// Transformer — Vaswani et al., "Attention Is All You Need", 2017.
///
/// TODO: Implement a minimal encoder-only Transformer block:
/// - Positional encoding: PE(pos, 2i) = sin(pos / 10000^(2i/d_model))
///                        PE(pos, 2i+1) = cos(pos / 10000^(2i/d_model))
/// - Multi-head attention: split d_model into h heads, each with d_k = d_model/h
///   run scaled dot-product attention in parallel, concatenate and project
/// - Add &amp; Norm: residual connection + layer normalisation after each sub-layer
/// - Feed-Forward: FFN(x) = max(0, xW₁ + b₁)W₂ + b₂  (d_ff typically 4 × d_model)
/// - Stack N encoder blocks
/// - Train on a toy character-level sequence modelling task
/// </summary>
public sealed class Transformer
{
    // TODO: fields — embedding, positional encoding, N encoder blocks (each: MHA + FFN + LN)

    /// <summary>Placeholder constructor. Replace when implementing.</summary>
    public Transformer(int dModel, int numHeads, int numLayers, int dFF)
    {
        throw new NotImplementedException("Transformer is not yet implemented. See TODO above.");
    }
}
