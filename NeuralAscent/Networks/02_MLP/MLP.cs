namespace NeuralAscent.Networks._02_MLP;

/// <summary>
/// Multi-Layer Perceptron — Rumelhart, Hinton &amp; Williams, 1986.
///
/// TODO: Implement MLP with:
/// - Configurable hidden layers and neuron counts (layer sizes passed as int[])
/// - Weight initialisation: Xavier uniform for sigmoid, He for ReLU
/// - Forward pass:  for each layer: z = W·a_prev + b,  a = σ(z)
/// - Backward pass: δ_output = (ŷ − y) ⊙ σ'(z_output)
///                  δ_hidden = (Wᵀ·δ_next) ⊙ σ'(z_hidden)
///                  ∂L/∂W = δ · aᵀ
///                  ∂L/∂b = δ
/// - Gradient descent weight update: W ← W − η·∂L/∂W
/// - Loss: Mean Squared Error for regression, Binary Cross-Entropy for classification
/// - Training on XOR (4 samples, converges to near-zero loss)
/// </summary>
public sealed class MLP
{
    // TODO: fields — layer weight matrices, bias vectors, layer size config, activation fn

    /// <summary>Placeholder constructor. Replace when implementing.</summary>
    public MLP(int[] layerSizes, double learningRate = 0.01)
    {
        throw new NotImplementedException("MLP is not yet implemented. See TODO above.");
    }
}
