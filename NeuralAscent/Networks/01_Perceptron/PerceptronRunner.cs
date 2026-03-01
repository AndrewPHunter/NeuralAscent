using NeuralAscent.Data;
using NeuralAscent.Networks._01_Perceptron;
using NeuralAscent.UI;
using Spectre.Console;

namespace NeuralAscent.Networks;

/// <summary>
/// Runner for the Perceptron module.
/// Demonstrates:
///   1. Training on AND — should converge perfectly.
///   2. Training on OR  — should converge perfectly.
///   3. Training on XOR — will not converge (motivates the MLP).
/// </summary>
public sealed class PerceptronRunner : INetwork
{
    public string Name        => "Perceptron";
    public string Description => "The origin. A single neuron with a step function — learns any linearly separable problem.";
    public string Era         => "1957 — Frank Rosenblatt";
    public string KeyEquation => "ŷ = step(w·x + b)   |   w ← w + η(y − ŷ)x";

    public void Run()
    {
        RunGate("AND",  LogicGates.And.Inputs,  LogicGates.And.Targets);
        RunGate("OR",   LogicGates.Or.Inputs,   LogicGates.Or.Targets);
        RunGate("XOR",  LogicGates.Xor.Inputs,  LogicGates.Xor.Targets);
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    private static void RunGate(string gateName, double[][] inputs, double[] targets)
    {
        const int maxEpochs = 100;
        const double learningRate = 0.1;

        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Rule($"[steelblue1]Perceptron on {gateName}[/]").RuleStyle("grey46"));
        AnsiConsole.WriteLine();

        var perceptron = new Perceptron(inputSize: inputs[0].Length, learningRate);
        var lossHistory = new List<double>();

        for (int epoch = 1; epoch <= maxEpochs; epoch++)
        {
            int errors = perceptron.TrainEpoch(inputs, targets);
            double loss = (double)errors / inputs.Length;
            lossHistory.Add(loss);

            // Print every 10th epoch plus the final one.
            if (epoch % 10 == 0 || epoch == maxEpochs || errors == 0)
                ConsoleUI.ShowEpochProgress(epoch, maxEpochs, loss);

            if (errors == 0)
            {
                AnsiConsole.MarkupLine($"\n  [green]Converged at epoch {epoch}.[/]\n");
                break;
            }

            if (epoch == maxEpochs)
                AnsiConsole.MarkupLine($"\n  [yellow]Did not converge in {maxEpochs} epochs.[/]\n");
        }

        ConsoleUI.ShowLossCurve(lossHistory);

        // Show per-sample predictions.
        AnsiConsole.MarkupLine("  [grey46]Predictions:[/]");
        for (int i = 0; i < inputs.Length; i++)
        {
            double pred = perceptron.Predict(inputs[i]);
            bool correct = Math.Abs(pred - targets[i]) < 0.5;
            ConsoleUI.ShowPrediction(inputs[i], targets[i], pred, correct);
        }

        // Show learned weights. Markup.Escape is required: weight values contain brackets
        // and decimals that Spectre would otherwise try to parse as color/style names.
        string weightStr = Markup.Escape(
            $"[{string.Join(", ", perceptron.Weights.Select(w => w.ToString("F4")))}]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine(
            $"  [grey46]Learned weights:[/] {weightStr}  [grey46]bias:[/] {perceptron.Bias:F4}");

        if (gateName == "XOR")
        {
            AnsiConsole.WriteLine();
            ConsoleUI.ShowPanel(
                "XOR — Why the Perceptron Fails",
                "[grey46]XOR is not linearly separable: no single line can divide\n" +
                "the four input points into the correct two classes.\n\n" +
                "Minsky & Papert formalised this limitation in [steelblue1]Perceptrons[/] (1969),\n" +
                "stalling neural network research for over a decade.\n\n" +
                "The solution: [cyan1]multiple layers[/] — the MLP, next on the journey.[/]");
        }

        ConsoleUI.PauseForKey();
    }
}
