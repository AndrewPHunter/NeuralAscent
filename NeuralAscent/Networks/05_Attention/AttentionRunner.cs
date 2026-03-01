using NeuralAscent.UI;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the Attention module.
///
/// TODO: Implement after Attention.cs is complete:
/// - Show a worked example: compute Q, K, V for a short sequence step by step
/// - Render the attention weight matrix as a labelled ASCII heatmap
/// - Explain alignment: "attending to position j when producing position i"
/// - Train on a toy copy/reverse task to show that attention solves long-range dependency
/// - Render loss curve via ConsoleUI.ShowLossCurve
/// </summary>
public sealed class AttentionRunner : INetwork
{
    public string Name        => "Attention";
    public string Description => "The key insight. Any position can attend to any other — no distance penalty.";
    public string Era         => "2015 — Bahdanau, Cho & Bengio";
    public string KeyEquation => "Attention(Q,K,V) = softmax(QKᵀ / √d_k) · V";

    public void Run() => ConsoleUI.ShowComingSoon(this);
}
