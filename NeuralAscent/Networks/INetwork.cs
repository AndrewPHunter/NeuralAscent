namespace NeuralAscent.Networks;

/// <summary>
/// Contract that every network module must satisfy.
/// Each implementation is both a runnable demo and a self-contained study unit.
/// </summary>
public interface INetwork
{
    /// <summary>Short display name shown in the menu.</summary>
    string Name { get; }

    /// <summary>One-sentence description of the problem this architecture solves.</summary>
    string Description { get; }

    /// <summary>
    /// Era string: inventor and year.
    /// Example: "1957 — Rosenblatt"
    /// </summary>
    string Era { get; }

    /// <summary>
    /// The defining equation in plain text.
    /// Example: "ŷ = step(w·x + b)"
    /// </summary>
    string KeyEquation { get; }

    /// <summary>
    /// Runs the interactive demo for this network.
    /// Implementations are responsible for their own console output via ConsoleUI.
    /// </summary>
    void Run();
}
