namespace NeuralAscent.UI;

/// <summary>
/// Renders a simple ASCII loss curve to the console.
/// Output is self-contained text — no Spectre.Console markup, so it can be
/// written directly or wrapped in a Panel at the call site.
/// </summary>
public static class AsciiChart
{
    /// <summary>
    /// Renders a loss curve for the given series of loss values.
    /// </summary>
    /// <param name="losses">Loss value at each recorded epoch, in order.</param>
    /// <param name="width">Number of columns for the chart body (default 60).</param>
    /// <param name="height">Number of rows for the chart body (default 12).</param>
    /// <param name="title">Optional Y-axis label.</param>
    /// <returns>Multi-line string ready to print.</returns>
    public static string Render(
        IReadOnlyList<double> losses,
        int width = 60,
        int height = 12,
        string title = "Loss")
    {
        if (losses.Count == 0)
            return $"  {title}: (no data)";

        double minLoss = losses.Min();
        double maxLoss = losses.Max();
        double range = maxLoss - minLoss;

        // Avoid division by zero when loss is flat (rare but possible in stubs).
        if (range == 0.0) range = 1.0;

        // Bucket the losses into `width` columns by averaging within each bucket.
        double[] buckets = BucketLosses(losses, width);

        // Build the grid: [height rows × width cols], filled with spaces.
        char[][] grid = new char[height][];
        for (int r = 0; r < height; r++)
        {
            grid[r] = new char[width];
            Array.Fill(grid[r], ' ');
        }

        // Place a dot for each column's representative loss value.
        for (int col = 0; col < width; col++)
        {
            double normalised = (buckets[col] - minLoss) / range; // 0..1, 0=low, 1=high
            int row = height - 1 - (int)Math.Round(normalised * (height - 1));
            row = Math.Clamp(row, 0, height - 1);
            grid[row][col] = '·';
        }

        // Render the grid with Y-axis labels.
        var sb = new System.Text.StringBuilder();
        int labelWidth = 6;

        for (int r = 0; r < height; r++)
        {
            double yVal = maxLoss - (r / (double)(height - 1)) * range;
            string label = yVal.ToString("F3").PadLeft(labelWidth);
            sb.Append(label);
            sb.Append(" │ ");
            sb.Append(new string(grid[r]));
            sb.AppendLine();
        }

        // X-axis
        sb.Append(new string(' ', labelWidth));
        sb.Append(" └─");
        sb.Append(new string('─', width));
        sb.AppendLine();

        // X-axis label
        sb.Append(new string(' ', labelWidth + 3));
        string epochLabel = "Epoch 0";
        string epochEnd = $"Epoch {losses.Count}";
        int gap = width - epochLabel.Length - epochEnd.Length;
        sb.Append(epochLabel);
        if (gap > 0) sb.Append(new string(' ', gap));
        sb.Append(epochEnd);
        sb.AppendLine();

        return sb.ToString();
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static double[] BucketLosses(IReadOnlyList<double> losses, int width)
    {
        var buckets = new double[width];
        for (int col = 0; col < width; col++)
        {
            int startIdx = (int)((col / (double)width) * losses.Count);
            int endIdx = (int)(((col + 1) / (double)width) * losses.Count);
            if (endIdx > losses.Count) endIdx = losses.Count;
            if (startIdx >= endIdx) { buckets[col] = losses[^1]; continue; }

            double sum = 0.0;
            for (int i = startIdx; i < endIdx; i++) sum += losses[i];
            buckets[col] = sum / (endIdx - startIdx);
        }
        return buckets;
    }
}
