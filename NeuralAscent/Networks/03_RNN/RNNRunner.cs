using NeuralAscent.UI;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the RNN module.
///
/// TODO: Implement after RNN.cs is complete:
/// - Train on sine wave next-value prediction (Data/Sequences.cs)
/// - Demonstrate that the RNN learns short-term dependencies but struggles with long-term ones
/// - Show gradient magnitude per time step (vanishing gradient visualisation)
/// - Render loss curve via ConsoleUI.ShowLossCurve
/// </summary>
public sealed class RNNRunner : INetwork
{
    public string Name        => "RNN";
    public string Description => "Memory. Sequences, hidden state, and the vanishing gradient problem.";
    public string Era         => "1986 — Rumelhart, Hinton & Williams";
    public string KeyEquation => "h_t = tanh(W_hh·h_{t-1} + W_xh·x_t + b_h)";

    public void Run() => ConsoleUI.ShowComingSoon(this);
}
