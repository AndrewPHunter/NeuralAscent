namespace NeuralAscent.Core;

/// <summary>
/// Activation functions and their exact derivatives.
/// Every function here has a corresponding derivative — the derivative is what
/// the backpropagation algorithm multiplies through the chain rule.
///
/// Convention: derivative methods accept the *pre-activation* value x (not the
/// activation output), matching the form used in forward-pass code.
/// Where the derivative is more naturally expressed in terms of the output
/// (e.g. Sigmoid), the function re-computes σ(x) internally.
/// </summary>
public static class Activations
{
    // ── Sigmoid ──────────────────────────────────────────────────────────────
    // σ(x) = 1 / (1 + e^(-x))
    // Range: (0, 1) — historically used in binary classification output layers.
    // Suffers from vanishing gradients for large |x|.

    /// <summary>
    /// Sigmoid activation: σ(x) = 1 / (1 + e^(−x)).
    /// </summary>
    public static double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));

    /// <summary>
    /// Sigmoid derivative: σ'(x) = σ(x) · (1 − σ(x)).
    /// The derivative is maximised at x=0 (value 0.25) and approaches 0 at both extremes.
    /// </summary>
    public static double SigmoidDerivative(double x)
    {
        double s = Sigmoid(x);
        return s * (1.0 - s);
    }

    // ── ReLU ─────────────────────────────────────────────────────────────────
    // f(x) = max(0, x)
    // Introduced widespread adoption in deep learning (Nair & Hinton 2010).
    // Solves the vanishing gradient problem for positive activations.
    // Suffers from "dying ReLU" when neurons get stuck in the zero region.

    /// <summary>
    /// Rectified Linear Unit: f(x) = max(0, x).
    /// </summary>
    public static double ReLU(double x) => x > 0.0 ? x : 0.0;

    /// <summary>
    /// ReLU derivative: f'(x) = 1 if x > 0, else 0.
    /// Technically undefined at x=0; we return 0 by convention.
    /// </summary>
    public static double ReLUDerivative(double x) => x > 0.0 ? 1.0 : 0.0;

    // ── Leaky ReLU ───────────────────────────────────────────────────────────
    // f(x) = x > 0 ? x : αx  (α ≈ 0.01)
    // Addresses the dying ReLU problem by allowing a small gradient for x < 0.

    /// <summary>
    /// Leaky ReLU: f(x) = x > 0 ? x : α·x. Default α = 0.01.
    /// </summary>
    public static double LeakyReLU(double x, double alpha = 0.01) =>
        x > 0.0 ? x : alpha * x;

    /// <summary>
    /// Leaky ReLU derivative: f'(x) = 1 if x > 0, else α.
    /// </summary>
    public static double LeakyReLUDerivative(double x, double alpha = 0.01) =>
        x > 0.0 ? 1.0 : alpha;

    // ── Tanh ─────────────────────────────────────────────────────────────────
    // tanh(x) = (e^x - e^(-x)) / (e^x + e^(-x))
    // Range: (-1, 1) — zero-centred, preferred over Sigmoid for hidden layers.

    /// <summary>
    /// Hyperbolic tangent: tanh(x) = (e^x − e^(−x)) / (e^x + e^(−x)).
    /// </summary>
    public static double Tanh(double x) => Math.Tanh(x);

    /// <summary>
    /// Tanh derivative: tanh'(x) = 1 − tanh²(x).
    /// </summary>
    public static double TanhDerivative(double x)
    {
        double t = Math.Tanh(x);
        return 1.0 - t * t;
    }

    // ── Softmax ──────────────────────────────────────────────────────────────
    // σ(z)_j = e^(z_j) / Σ_k e^(z_k)
    // Converts a vector of real numbers into a probability distribution.
    // Used in multi-class classification output layers.
    // Numerically stabilised by subtracting max(z) before exponentiation.

    /// <summary>
    /// Softmax: converts logits into a probability distribution.
    /// σ(z)_j = e^(z_j − max(z)) / Σ_k e^(z_k − max(z))
    /// Numerically stable (subtracts max before exp).
    /// </summary>
    public static double[] Softmax(double[] z)
    {
        double max = z.Max();
        double[] exps = z.Select(v => Math.Exp(v - max)).ToArray();
        double sum = exps.Sum();
        return exps.Select(e => e / sum).ToArray();
    }

    // ── Step (Heaviside) ─────────────────────────────────────────────────────
    // The original Perceptron activation (Rosenblatt 1958).
    // f(x) = 1 if x ≥ threshold, else 0.
    // Non-differentiable — cannot be used with gradient descent.

    /// <summary>
    /// Step/Heaviside activation: f(x) = 1 if x ≥ threshold, else 0.
    /// This is the original Perceptron activation — not differentiable,
    /// so it cannot be trained with gradient-based methods.
    /// </summary>
    public static double Step(double x, double threshold = 0.0) =>
        x >= threshold ? 1.0 : 0.0;

    // ── Linear (Identity) ────────────────────────────────────────────────────
    // f(x) = x — used in regression output layers.

    /// <summary>
    /// Linear/identity activation: f(x) = x.
    /// Used in regression output layers.
    /// </summary>
    public static double Linear(double x) => x;

    /// <summary>Linear derivative: f'(x) = 1.</summary>
    public static double LinearDerivative(double x) => 1.0;
}
