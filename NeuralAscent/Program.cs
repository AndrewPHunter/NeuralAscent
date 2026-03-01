using NeuralAscent.Networks;
using NeuralAscent.UI;

// ── Network registry ──────────────────────────────────────────────────────────
// Add new runners here as modules are implemented.
// Order determines menu order — keep it chronological.
IReadOnlyList<INetwork> networks =
[
    new PerceptronRunner(),
    new MLPRunner(),
    new RNNRunner(),
    new CNNRunner(),
    new AttentionRunner(),
    new TransformerRunner(),
];

// ── Main loop ─────────────────────────────────────────────────────────────────
ConsoleUI.ShowHeader();

while (true)
{
    string choice = ConsoleUI.ShowMainMenu(networks);

    if (choice == "quit")
        break;

    if (choice == "about")
    {
        ConsoleUI.ShowAbout();
        ConsoleUI.ShowHeader();
        continue;
    }

    INetwork? network = networks.FirstOrDefault(n =>
        string.Equals(n.Name, choice, StringComparison.OrdinalIgnoreCase));

    if (network is null)
        continue;

    ConsoleUI.ShowHeader();
    ConsoleUI.ShowNetworkPreamble(network);
    network.Run();
    ConsoleUI.ShowHeader();
}
