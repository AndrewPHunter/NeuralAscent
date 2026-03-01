namespace NeuralAscent.Networks._04_CNN;

/// <summary>
/// Convolutional Neural Network — LeCun et al., 1989.
///
/// TODO: Implement a minimal 1-D CNN to illustrate the key ideas:
/// - Convolution layer: (x * k)[i] = Σ_j k[j] · x[i+j]  (valid padding)
/// - ReLU activation after convolution
/// - Max pooling: pool[i] = max(x[i·stride .. i·stride + poolSize])
/// - Flatten + Dense layer for classification
/// - Backprop through conv layer: gradient w.r.t. kernel = cross-correlation of input with δ
/// - Demonstrate weight sharing: same kernel reused across all positions
/// - Train on a toy 1-D sequence classification task (e.g., detect rising vs falling)
/// </summary>
public sealed class CNN
{
    // TODO: fields — kernels, biases, pooling config, dense layer weights

    /// <summary>Placeholder constructor. Replace when implementing.</summary>
    public CNN(int kernelSize, int numFilters)
    {
        throw new NotImplementedException("CNN is not yet implemented. See TODO above.");
    }
}
