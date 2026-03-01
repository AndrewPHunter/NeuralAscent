using NeuralAscent.UI;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the Transformer module.
///
/// TODO: Implement after Transformer.cs is complete:
/// - Walk through positional encoding: show the sin/cos wave pattern for a short sequence
/// - Show multi-head attention: illustrate that each head attends to different relationships
/// - Show residual streams: why skip connections enable training deep networks
/// - Train on a character-level language modelling task (predict next character)
/// - Render attention heatmaps for each head
/// - Render loss curve via ConsoleUI.ShowLossCurve
/// </summary>
public sealed class TransformerRunner : INetwork
{
    public string Name        => "Transformer";
    public string Description => "The architecture that changed everything. Attention, all the way down.";
    public string Era         => "2017 — Vaswani, Shazeer et al.";
    public string KeyEquation => "MultiHead(Q,K,V) = Concat(head_1,...,head_h)W_O   FFN(x) = max(0,xW₁+b₁)W₂+b₂";

    public void Run() => ConsoleUI.ShowComingSoon(this);
}
