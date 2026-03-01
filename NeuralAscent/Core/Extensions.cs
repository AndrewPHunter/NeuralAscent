namespace NeuralAscent.Core;

/// <summary>
/// Utility extensions for sequences, arrays, and console formatting.
/// Kept deliberately small — only what is actively used elsewhere in Core and Networks.
/// </summary>
public static class Extensions
{
    // ── Numeric helpers ───────────────────────────────────────────────────────

    /// <summary>
    /// Clamps a value to [min, max].
    /// </summary>
    public static double Clamp(this double value, double min, double max) =>
        Math.Max(min, Math.Min(max, value));

    /// <summary>
    /// Returns the index of the maximum element in a sequence.
    /// Useful for argmax classification (e.g. reading a Softmax output).
    /// </summary>
    public static int ArgMax(this IEnumerable<double> source)
    {
        int maxIdx = 0;
        int idx = 0;
        double maxVal = double.NegativeInfinity;
        foreach (double v in source)
        {
            if (v > maxVal) { maxVal = v; maxIdx = idx; }
            idx++;
        }
        return maxIdx;
    }

    /// <summary>
    /// Computes the mean of a sequence.
    /// </summary>
    public static double Mean(this IEnumerable<double> source)
    {
        double sum = 0.0;
        int count = 0;
        foreach (double v in source) { sum += v; count++; }
        return count == 0 ? 0.0 : sum / count;
    }

    // ── Array helpers ─────────────────────────────────────────────────────────

    /// <summary>
    /// Returns a new array that is a copy of <paramref name="source"/> with each element
    /// mapped through <paramref name="f"/>.
    /// </summary>
    public static double[] Map(this double[] source, Func<double, double> f)
    {
        var result = new double[source.Length];
        for (int i = 0; i < source.Length; i++)
            result[i] = f(source[i]);
        return result;
    }

    /// <summary>
    /// Zips two same-length arrays element-wise using <paramref name="f"/>.
    /// </summary>
    public static double[] ZipWith(this double[] a, double[] b, Func<double, double, double> f)
    {
        if (a.Length != b.Length)
            throw new ArgumentException($"Array lengths must match: {a.Length} ≠ {b.Length}.");
        var result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
            result[i] = f(a[i], b[i]);
        return result;
    }

    // ── Pretty-print helpers ──────────────────────────────────────────────────

    /// <summary>
    /// Formats a double[] as a bracketed row: [0.12  0.88  0.00].
    /// </summary>
    public static string ToVectorString(this double[] v, int decimals = 4) =>
        "[" + string.Join("  ", v.Select(x => x.ToString($"F{decimals}"))) + "]";

    /// <summary>
    /// Formats a double[][] as a grid (one row per line, indented by two spaces).
    /// </summary>
    public static string ToMatrixString(this double[][] m, int decimals = 4)
    {
        var rows = m.Select(row => "  " + row.ToVectorString(decimals));
        return string.Join(Environment.NewLine, rows);
    }

    /// <summary>
    /// Normalises a double[] to the range [0, 1].
    /// Returns the original array unchanged if all values are equal.
    /// </summary>
    public static double[] Normalise(this double[] v)
    {
        double min = v.Min();
        double max = v.Max();
        double range = max - min;
        if (range == 0.0) return v.ToArray();
        return v.Map(x => (x - min) / range);
    }

    // ── Training helpers ──────────────────────────────────────────────────────

    /// <summary>
    /// Shuffles an array in-place using the Fisher-Yates algorithm.
    /// <paramref name="rng"/> must be provided by the caller to keep randomness explicit.
    /// </summary>
    public static void Shuffle<T>(this T[] array, Random rng)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
