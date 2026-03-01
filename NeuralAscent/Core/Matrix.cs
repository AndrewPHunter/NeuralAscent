namespace NeuralAscent.Core;

/// <summary>
/// Hand-rolled matrix operations over jagged double arrays.
/// These implementations are deliberately pedagogical — no BLAS, no vectorisation,
/// just the mathematics laid bare so the reader can trace every multiply-accumulate.
/// </summary>
public static class Matrix
{
    /// <summary>
    /// Multiplies two matrices: C = A × B.
    /// A must be [m×k], B must be [k×n]; result is [m×n].
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when inner dimensions do not match.</exception>
    public static double[][] Multiply(double[][] a, double[][] b)
    {
        int m = a.Length;
        int k = a[0].Length;
        int n = b[0].Length;

        if (b.Length != k)
            throw new ArgumentException($"Inner dimensions must match: A is [{m}×{k}], B is [{b.Length}×{n}].");

        var result = Zeros(m, n);
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int p = 0; p < k; p++)
                    result[i][j] += a[i][p] * b[p][j];

        return result;
    }

    /// <summary>
    /// Transposes a matrix: B[j][i] = A[i][j].
    /// </summary>
    public static double[][] Transpose(double[][] m)
    {
        int rows = m.Length;
        int cols = m[0].Length;
        var result = Zeros(cols, rows);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j][i] = m[i][j];
        return result;
    }

    /// <summary>
    /// Element-wise addition: C[i][j] = A[i][j] + B[i][j].
    /// A and B must have identical dimensions.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when dimensions do not match.</exception>
    public static double[][] Add(double[][] a, double[][] b)
    {
        AssertSameDimensions(a, b, nameof(Add));
        int rows = a.Length;
        int cols = a[0].Length;
        var result = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i][j] = a[i][j] + b[i][j];
        return result;
    }

    /// <summary>
    /// Element-wise subtraction: C[i][j] = A[i][j] - B[i][j].
    /// A and B must have identical dimensions.
    /// </summary>
    public static double[][] Subtract(double[][] a, double[][] b)
    {
        AssertSameDimensions(a, b, nameof(Subtract));
        int rows = a.Length;
        int cols = a[0].Length;
        var result = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i][j] = a[i][j] - b[i][j];
        return result;
    }

    /// <summary>
    /// Scalar multiplication: B[i][j] = s × A[i][j].
    /// </summary>
    public static double[][] ScalarMultiply(double[][] m, double s)
    {
        int rows = m.Length;
        int cols = m[0].Length;
        var result = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i][j] = m[i][j] * s;
        return result;
    }

    /// <summary>
    /// Applies a function element-wise: B[i][j] = f(A[i][j]).
    /// Used for activation functions during the forward pass.
    /// </summary>
    public static double[][] Map(double[][] m, Func<double, double> f)
    {
        int rows = m.Length;
        int cols = m[0].Length;
        var result = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i][j] = f(m[i][j]);
        return result;
    }

    /// <summary>
    /// Vector dot product: result = Σ a[i] × b[i].
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when vectors have different lengths.</exception>
    public static double Dot(double[] a, double[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException($"Vector lengths must match: {a.Length} ≠ {b.Length}.");

        double sum = 0.0;
        for (int i = 0; i < a.Length; i++)
            sum += a[i] * b[i];
        return sum;
    }

    /// <summary>
    /// Element-wise multiplication (Hadamard product): C[i][j] = A[i][j] × B[i][j].
    /// Required for backpropagation delta calculations.
    /// </summary>
    public static double[][] Hadamard(double[][] a, double[][] b)
    {
        AssertSameDimensions(a, b, nameof(Hadamard));
        int rows = a.Length;
        int cols = a[0].Length;
        var result = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i][j] = a[i][j] * b[i][j];
        return result;
    }

    /// <summary>
    /// Creates a zero-initialised [rows × cols] matrix.
    /// </summary>
    public static double[][] Zeros(int rows, int cols)
    {
        var m = new double[rows][];
        for (int i = 0; i < rows; i++)
            m[i] = new double[cols];
        return m;
    }

    /// <summary>
    /// Creates a [rows × cols] matrix with values drawn from a Gaussian distribution.
    /// Mean 0, standard deviation <paramref name="stdDev"/>.
    /// Xavier/He initialisation is achieved by choosing stdDev appropriately at the call site.
    /// </summary>
    public static double[][] Random(int rows, int cols, double stdDev = 0.1, int? seed = null)
    {
        var rng = seed.HasValue ? new Random(seed.Value) : new Random();
        var m = Zeros(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                m[i][j] = NextGaussian(rng) * stdDev;
        return m;
    }

    /// <summary>
    /// Wraps a 1-D vector as a column matrix [n × 1].
    /// </summary>
    public static double[][] ColumnVector(double[] v)
    {
        var m = new double[v.Length][];
        for (int i = 0; i < v.Length; i++)
            m[i] = [v[i]];
        return m;
    }

    /// <summary>
    /// Extracts the first column of a matrix as a 1-D vector.
    /// </summary>
    public static double[] FlattenColumn(double[][] m)
    {
        var v = new double[m.Length];
        for (int i = 0; i < m.Length; i++)
            v[i] = m[i][0];
        return v;
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static void AssertSameDimensions(double[][] a, double[][] b, string op)
    {
        if (a.Length != b.Length || a[0].Length != b[0].Length)
            throw new ArgumentException(
                $"{op}: dimension mismatch. A is [{a.Length}×{a[0].Length}], B is [{b.Length}×{b[0].Length}].");
    }

    // Box-Muller transform for Gaussian samples.
    private static double NextGaussian(Random rng)
    {
        double u1 = 1.0 - rng.NextDouble();
        double u2 = 1.0 - rng.NextDouble();
        return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    }
}
