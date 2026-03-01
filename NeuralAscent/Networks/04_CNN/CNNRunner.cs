using NeuralAscent.UI;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the CNN module.
///
/// TODO: Implement after CNN.cs is complete:
/// - Show convolution visually: display the kernel sliding over a 1-D input
/// - Compare parameter count of CNN vs equivalent dense network (illustrate weight sharing)
/// - Train on a toy classification task
/// - Render loss curve via ConsoleUI.ShowLossCurve
/// </summary>
public sealed class CNNRunner : INetwork
{
    public string Name        => "CNN";
    public string Description => "Vision. Convolution and weight sharing reduce parameters without losing spatial structure.";
    public string Era         => "1989 — LeCun, Bottou, Bengio & Haffner";
    public string KeyEquation => "(x * k)[i] = Σ_j k[j] · x[i+j]";

    public void Run() => ConsoleUI.ShowComingSoon(this);
}
