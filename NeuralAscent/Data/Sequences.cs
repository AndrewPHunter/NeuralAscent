namespace NeuralAscent.Data;

/// <summary>
/// Sequence datasets for the RNN and Attention modules.
/// All sequences are deterministic given their parameters.
/// </summary>
public static class Sequences
{
    /// <summary>
    /// Generates a normalised sine wave sampled at <paramref name="length"/> evenly-spaced points.
    /// Values are in [0, 1] (shifted and scaled from the natural [-1, 1] range).
    /// </summary>
    /// <param name="length">Number of samples to generate.</param>
    /// <param name="frequency">Cycles per unit interval (default 1.0).</param>
    public static double[] SineWave(int length, double frequency = 1.0)
    {
        var values = new double[length];
        for (int i = 0; i < length; i++)
        {
            double t = (double)i / length;
            values[i] = (Math.Sin(2.0 * Math.PI * frequency * t) + 1.0) / 2.0;
        }
        return values;
    }

    /// <summary>
    /// Generates a sliding-window dataset from a sequence for next-value prediction.
    /// Given a sequence [x_0, x_1, ..., x_n], produces:
    ///   Input:  [x_0, ..., x_{w-1}]   →   Target: x_w
    ///   Input:  [x_1, ..., x_w]       →   Target: x_{w+1}
    ///   ...
    /// </summary>
    /// <param name="sequence">Source sequence.</param>
    /// <param name="windowSize">Number of time steps in each input window.</param>
    public static (double[][] Inputs, double[] Targets) SlidingWindow(
        double[] sequence, int windowSize)
    {
        int count = sequence.Length - windowSize;
        if (count <= 0)
            throw new ArgumentException(
                $"Sequence length ({sequence.Length}) must exceed windowSize ({windowSize}).");

        var inputs = new double[count][];
        var targets = new double[count];

        for (int i = 0; i < count; i++)
        {
            inputs[i] = sequence[i..(i + windowSize)];
            targets[i] = sequence[i + windowSize];
        }

        return (inputs, targets);
    }

    /// <summary>
    /// Generates the first <paramref name="length"/> numbers of the Fibonacci sequence,
    /// normalised to [0, 1] by dividing by the maximum value.
    /// </summary>
    public static double[] Fibonacci(int length)
    {
        if (length <= 0) return [];

        var values = new double[length];
        double a = 0, b = 1;
        for (int i = 0; i < length; i++)
        {
            values[i] = a;
            (a, b) = (b, a + b);
        }

        double max = values.Max();
        if (max > 0.0)
            for (int i = 0; i < length; i++)
                values[i] /= max;

        return values;
    }

    /// <summary>
    /// Generates a square wave: alternates between 0.0 and 1.0 every <paramref name="period"/> steps.
    /// Useful for testing whether an RNN can learn periodic patterns.
    /// </summary>
    public static double[] SquareWave(int length, int period = 4)
    {
        var values = new double[length];
        for (int i = 0; i < length; i++)
            values[i] = (i / period) % 2 == 0 ? 0.0 : 1.0;
        return values;
    }
}
