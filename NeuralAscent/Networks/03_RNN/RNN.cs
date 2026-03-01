namespace NeuralAscent.Networks._03_RNN;

/// <summary>
/// Recurrent Neural Network — Rumelhart, Hinton &amp; Williams, 1986.
///
/// TODO: Implement a simple Elman RNN (one hidden state, one output):
/// - Hidden state update: h_t = tanh(W_hh · h_{t-1} + W_xh · x_t + b_h)
/// - Output:             y_t = W_hy · h_t + b_y
/// - Backprop Through Time (BPTT): unroll for T steps, accumulate gradients
/// - Gradient clipping: clip gradient norm to prevent explosion
/// - Training on a sine wave prediction task (predict next value given previous T)
/// - Demonstrate vanishing gradient by inspecting gradient magnitudes at early time steps
/// </summary>
public sealed class RNN
{
    // TODO: fields — W_hh, W_xh, W_hy, biases, hidden state, sequence length

    /// <summary>Placeholder constructor. Replace when implementing.</summary>
    public RNN(int inputSize, int hiddenSize, int outputSize)
    {
        throw new NotImplementedException("RNN is not yet implemented. See TODO above.");
    }
}
