namespace NeuralAscent.Networks._05_Attention;

/// <summary>
/// Scaled Dot-Product Attention — Bahdanau et al., 2015 (additive);
/// Luong et al., 2015 (dot-product); Vaswani et al., 2017 (scaled).
///
/// TODO: Implement scaled dot-product attention:
/// - Project inputs to Q, K, V:  Q = X·W_Q,  K = X·W_K,  V = X·W_V
/// - Attention weights:          A = softmax(Q·Kᵀ / √d_k)
/// - Output:                     O = A · V
/// - Demonstrate on a toy sequence-to-sequence copy task
/// - Visualise the attention weight matrix as an ASCII heatmap
/// - Explain why √d_k scaling prevents softmax saturation
/// </summary>
public sealed class Attention
{
    // TODO: fields — W_Q, W_K, W_V projection matrices, d_model, d_k

    /// <summary>Placeholder constructor. Replace when implementing.</summary>
    public Attention(int dModel, int dK)
    {
        throw new NotImplementedException("Attention is not yet implemented. See TODO above.");
    }
}
