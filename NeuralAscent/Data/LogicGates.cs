namespace NeuralAscent.Data;

/// <summary>
/// Static logic-gate datasets used by the Perceptron and MLP modules.
///
/// All datasets use the same shape convention:
///   Inputs[i]  — the i-th input sample (a double[])
///   Targets[i] — the expected scalar output for that sample
/// </summary>
public static class LogicGates
{
    /// <summary>
    /// AND gate: output is 1 only when both inputs are 1.
    /// Linearly separable — the Perceptron converges.
    /// </summary>
    public static class And
    {
        public static readonly double[][] Inputs =
        [
            [0.0, 0.0],
            [0.0, 1.0],
            [1.0, 0.0],
            [1.0, 1.0],
        ];

        public static readonly double[] Targets = [0.0, 0.0, 0.0, 1.0];
    }

    /// <summary>
    /// OR gate: output is 1 when at least one input is 1.
    /// Linearly separable — the Perceptron converges.
    /// </summary>
    public static class Or
    {
        public static readonly double[][] Inputs =
        [
            [0.0, 0.0],
            [0.0, 1.0],
            [1.0, 0.0],
            [1.0, 1.0],
        ];

        public static readonly double[] Targets = [0.0, 1.0, 1.0, 1.0];
    }

    /// <summary>
    /// NAND gate: output is 0 only when both inputs are 1.
    /// Linearly separable — the Perceptron converges.
    /// </summary>
    public static class Nand
    {
        public static readonly double[][] Inputs =
        [
            [0.0, 0.0],
            [0.0, 1.0],
            [1.0, 0.0],
            [1.0, 1.0],
        ];

        public static readonly double[] Targets = [1.0, 1.0, 1.0, 0.0];
    }

    /// <summary>
    /// XOR gate: output is 1 when inputs differ.
    /// NOT linearly separable — the Perceptron cannot converge.
    /// This is the classic motivating failure that led to the MLP.
    /// </summary>
    public static class Xor
    {
        public static readonly double[][] Inputs =
        [
            [0.0, 0.0],
            [0.0, 1.0],
            [1.0, 0.0],
            [1.0, 1.0],
        ];

        public static readonly double[] Targets = [0.0, 1.0, 1.0, 0.0];
    }
}
