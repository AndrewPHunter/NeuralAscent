using NeuralAscent.UI;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the Multi-Layer Perceptron module.
///
/// TODO: Implement this runner after MLP.cs is complete:
/// - Train a 2→4→1 network on XOR (showing what the Perceptron could not do)
/// - Print epoch/loss progress via ConsoleUI.ShowEpochProgress
/// - Render the loss curve via ConsoleUI.ShowLossCurve
/// - Show per-sample predictions and final weights
/// - Visual: ASCII approximation of the learned decision boundary
/// </summary>
public sealed class MLPRunner : INetwork
{
    public string Name        => "MLP";
    public string Description => "Backprop. Multiple layers unlock non-linear decision boundaries.";
    public string Era         => "1986 — Rumelhart, Hinton & Williams";
    public string KeyEquation => "z = Wx + b   |   a = σ(z)   |   δ = (∂L/∂a)(∂a/∂z)";

    public void Run() => ConsoleUI.ShowComingSoon(this);
}
