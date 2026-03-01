using NeuralAscent.Networks;
using Spectre.Console;

namespace NeuralAscent.UI;

/// <summary>
/// All Spectre.Console rendering lives here.
/// Nothing outside this class should write directly to the console
/// (except AsciiChart, which produces plain strings for embedding in panels).
/// </summary>
public static class ConsoleUI
{
    private const string Version = "v0.1.0";

    // ── Color palette ─────────────────────────────────────────────────────────
    // Deliberately narrow: steel-blue/cyan on dark for the "sharp tool" aesthetic.
    private const string AccentColor = "steelblue1";
    private const string DimColor = "grey46";
    private const string HighlightColor = "cyan1";
    private const string WarnColor = "yellow";
    private const string ErrorColor = "red1";

    // ── Header ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Renders the full launch header: ASCII title, tagline, version, arc line.
    /// </summary>
    public static void ShowHeader()
    {
        AnsiConsole.Clear();

        var art = new string[]
        {
            @"  ███╗   ██╗███████╗██╗   ██╗██████╗  █████╗ ██╗",
            @"  ████╗  ██║██╔════╝██║   ██║██╔══██╗██╔══██╗██║",
            @"  ██╔██╗ ██║█████╗  ██║   ██║██████╔╝███████║██║",
            @"  ██║╚██╗██║██╔══╝  ██║   ██║██╔══██╗██╔══██║██║",
            @"  ██║ ╚████║███████╗╚██████╔╝██║  ██║██║  ██║███████╗",
            @"  ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝",
            @"",
            @"    █████╗ ███████╗ ██████╗███████╗███╗   ██╗████████╗",
            @"   ██╔══██╗██╔════╝██╔════╝██╔════╝████╗  ██║╚══██╔══╝",
            @"   ███████║███████╗██║     █████╗  ██╔██╗ ██║   ██║",
            @"   ██╔══██║╚════██║██║     ██╔══╝  ██║╚██╗██║   ██║",
            @"   ██║  ██║███████║╚██████╗███████╗██║ ╚████║   ██║",
            @"   ╚═╝  ╚═╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝",
        };

        foreach (var line in art)
            AnsiConsole.MarkupLine($"[{AccentColor}]{Markup.Escape(line)}[/]");

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"  [{DimColor}]From Perceptron to Transformer — one gradient at a time.[/]");
        AnsiConsole.MarkupLine($"  [{DimColor}]{Version}[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine(
            $"  [{DimColor}][[ [{AccentColor}]Perceptron[/] [{DimColor}]→[/] [{AccentColor}]MLP[/] [{DimColor}]→[/] [{AccentColor}]RNN[/] [{DimColor}]→[/] [{AccentColor}]CNN[/] [{DimColor}]→[/] [{AccentColor}]Attention[/] [{DimColor}]→[/] [{AccentColor}]Transformer[/] [{DimColor}]]][/][/]");
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Rule().RuleStyle(DimColor));
        AnsiConsole.WriteLine();
    }

    // ── Main menu ─────────────────────────────────────────────────────────────

    /// <summary>
    /// Renders and evaluates the main selection menu.
    /// Returns the chosen network name, "about", or "quit".
    /// </summary>
    public static string ShowMainMenu(IReadOnlyList<INetwork> networks)
    {
        if (!AnsiConsole.Profile.Capabilities.Interactive)
        {
            AnsiConsole.MarkupLine($"  [{ErrorColor}]Non-interactive terminal — run without piped stdin.[/]");
            return "quit";
        }

        var choices = new List<string>();
        foreach (var n in networks)
            choices.Add($"[{AccentColor}]{Markup.Escape(n.Name)}[/]  [{DimColor}]— {Markup.Escape(n.Description)}[/]");
        choices.Add($"[{WarnColor}]About[/]  [{DimColor}]— What is NeuralAscent?[/]");
        choices.Add($"[{ErrorColor}]Quit[/]");

        var prompt = new SelectionPrompt<string>()
            .Title($"  [{HighlightColor}]Select a network to explore:[/]")
            .PageSize(12)
            .HighlightStyle(new Style(Color.SteelBlue1))
            .AddChoices(choices);

        string selected = AnsiConsole.Prompt(prompt);

        if (selected.Contains("Quit")) return "quit";
        if (selected.Contains("About")) return "about";

        // Match by position (choices list order mirrors networks list order).
        int idx = choices.IndexOf(selected);
        return idx >= 0 && idx < networks.Count ? networks[idx].Name : "quit";
    }

    // ── Network preamble ──────────────────────────────────────────────────────

    /// <summary>
    /// Displays the theory panel shown before a network's Run() is called.
    /// </summary>
    public static void ShowNetworkPreamble(INetwork network)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Rule($"[{AccentColor}]{Markup.Escape(network.Name)}[/]").RuleStyle(DimColor));
        AnsiConsole.WriteLine();

        var content = new Markup(
            $"[{DimColor}]Era:[/]          [{HighlightColor}]{Markup.Escape(network.Era)}[/]\n\n" +
            $"[{DimColor}]Problem:[/]      {Markup.Escape(network.Description)}\n\n" +
            $"[{DimColor}]Key equation:[/] [{WarnColor}]{Markup.Escape(network.KeyEquation)}[/]");

        AnsiConsole.Write(new Panel(content)
            .Header($"[{DimColor}] theory [/]")
            .BorderStyle(new Style(Color.Grey46))
            .Padding(1, 0));

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"  [{DimColor}]Press any key to begin...[/]");
        Console.ReadKey(intercept: true);
        AnsiConsole.WriteLine();
    }

    // ── Coming soon panel ─────────────────────────────────────────────────────

    /// <summary>
    /// Shown in place of Run() for skeleton networks not yet implemented.
    /// </summary>
    public static void ShowComingSoon(INetwork network)
    {
        AnsiConsole.WriteLine();

        var content = new Markup(
            $"[{AccentColor}]{Markup.Escape(network.Name)}[/] [{DimColor}]— {Markup.Escape(network.Era)}[/]\n\n" +
            $"[{DimColor}]This module is not yet implemented.\n" +
            $"The scaffold and theory notes are in place; the math is coming next.[/]\n\n" +
            $"[{WarnColor}]{Markup.Escape(network.KeyEquation)}[/]");

        AnsiConsole.Write(new Panel(content)
            .Header($"[{WarnColor}] · · · coming soon · · · [/]")
            .BorderStyle(new Style(Color.Grey46))
            .Padding(1, 0));

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"  [{DimColor}]Press any key to return to the menu...[/]");
        Console.ReadKey(intercept: true);
    }

    // ── Training progress ─────────────────────────────────────────────────────

    /// <summary>
    /// Prints a single epoch progress line.
    /// Call this once per epoch from inside a network's training loop.
    /// </summary>
    /// <param name="epoch">Current epoch (1-based).</param>
    /// <param name="totalEpochs">Total number of epochs.</param>
    /// <param name="loss">Current loss value.</param>
    public static void ShowEpochProgress(int epoch, int totalEpochs, double loss)
    {
        const int barWidth = 20;
        double fraction = (double)epoch / totalEpochs;
        int filled = (int)Math.Round(fraction * barWidth);
        filled = Math.Clamp(filled, 0, barWidth);

        string bar = new string('█', filled) + new string('░', barWidth - filled);
        int pct = (int)(fraction * 100);

        AnsiConsole.MarkupLine(
            $"  [{DimColor}]Epoch[/] [{AccentColor}]{epoch:D4}[/] │ " +
            $"[{DimColor}]Loss:[/] [{HighlightColor}]{loss:F4}[/] │ " +
            $"[{AccentColor}]{bar}[/] [{DimColor}]{pct,3}%[/]");
    }

    // ── Loss curve ────────────────────────────────────────────────────────────

    /// <summary>
    /// Renders an ASCII loss curve inside a Spectre.Console panel.
    /// </summary>
    public static void ShowLossCurve(IReadOnlyList<double> losses)
    {
        if (losses.Count == 0) return;

        string chart = AsciiChart.Render(losses);
        AnsiConsole.Write(new Panel(new Markup($"[{DimColor}]{Markup.Escape(chart)}[/]"))
            .Header($"[{DimColor}] training curve [/]")
            .BorderStyle(new Style(Color.Grey46))
            .Padding(0, 0));
        AnsiConsole.WriteLine();
    }

    // ── Generic info panel ────────────────────────────────────────────────────

    /// <summary>
    /// Renders a titled panel with arbitrary markup content.
    /// </summary>
    public static void ShowPanel(string title, string content)
    {
        AnsiConsole.Write(new Panel(new Markup(content))
            .Header($"[{DimColor}] {Markup.Escape(title)} [/]")
            .BorderStyle(new Style(Color.Grey46))
            .Padding(1, 0));
        AnsiConsole.WriteLine();
    }

    // ── About screen ──────────────────────────────────────────────────────────

    /// <summary>
    /// Renders the About screen.
    /// </summary>
    public static void ShowAbout()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Rule($"[{AccentColor}]About NeuralAscent[/]").RuleStyle(DimColor));
        AnsiConsole.WriteLine();

        var content = new Markup(
            $"[{HighlightColor}]NeuralAscent[/] [{DimColor}]is a .NET 9 / C# 13 console application and learning journal\n" +
            $"that traces the full arc of neural network history from the Perceptron\n" +
            $"through to the Transformer.[/]\n\n" +
            $"[{DimColor}]Each module implements a real, working network — no toy wrappers,\n" +
            $"no framework black boxes. The math is in the code.[/]\n\n" +
            $"[{AccentColor}]The Journey:[/]\n" +
            $"[{DimColor}]  Perceptron[/]  [{DimColor}]1957 — Linear threshold units. The beginning.[/]\n" +
            $"[{DimColor}]  MLP        [/]  [{DimColor}]1986 — Backprop. Deep learning's engine.[/]\n" +
            $"[{DimColor}]  RNN        [/]  [{DimColor}]1986 — Memory and sequences.[/]\n" +
            $"[{DimColor}]  CNN        [/]  [{DimColor}]1989 — Vision and weight sharing.[/]\n" +
            $"[{DimColor}]  Attention  [/]  [{DimColor}]2015 — The key insight. Query, Key, Value.[/]\n" +
            $"[{DimColor}]  Transformer[/]  [{DimColor}]2017 — The architecture that changed everything.[/]\n\n" +
            $"[{DimColor}]GitHub:[/]  [{AccentColor}]https://github.com/AndrewPHunter/NeuralAscent[/]\n" +
            $"[{DimColor}]License:[/] MIT © 2025 Andrew P Hunter");

        AnsiConsole.Write(new Panel(content)
            .BorderStyle(new Style(Color.Grey46))
            .Padding(1, 0));

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"  [{DimColor}]Press any key to return...[/]");
        Console.ReadKey(intercept: true);
    }

    // ── Result display ────────────────────────────────────────────────────────

    /// <summary>
    /// Displays a test result row: input → expected → actual → pass/fail.
    /// </summary>
    public static void ShowPrediction(double[] input, double expected, double actual, bool correct)
    {
        string status = correct
            ? $"[green]✓ pass[/]"
            : $"[{ErrorColor}]✗ fail[/]";

        AnsiConsole.MarkupLine(
            $"  input [{DimColor}]{Markup.Escape(string.Join(", ", input.Select(x => x.ToString("F0"))))}[/]" +
            $"  expected [{WarnColor}]{expected:F0}[/]" +
            $"  got [{HighlightColor}]{actual:F4}[/]" +
            $"  {status}");
    }

    /// <summary>
    /// Pauses execution and prompts the user to press any key.
    /// </summary>
    public static void PauseForKey(string message = "Press any key to continue...")
    {
        AnsiConsole.MarkupLine($"\n  [{DimColor}]{Markup.Escape(message)}[/]");
        Console.ReadKey(intercept: true);
        AnsiConsole.WriteLine();
    }
}
