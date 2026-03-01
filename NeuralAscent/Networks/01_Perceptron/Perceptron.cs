using NeuralAscent.Core;

namespace NeuralAscent.Networks._01_Perceptron;

/// <summary>
/// The Perceptron — Frank Rosenblatt, 1957.
///
/// The simplest possible learning machine: a single neuron with a step activation
/// and a weight-update rule driven by the sign of the error.
///
/// Forward pass:   ŷ = step(w·x + b)
/// Weight update:  w ← w + η(y − ŷ)x
/// Bias update:    b ← b + η(y − ŷ)
///
/// Guaranteed to converge on linearly separable data (Rosenblatt's convergence
/// theorem). Will loop forever on XOR — the limitation that motivated the MLP.
/// </summary>
public sealed class Perceptron
{
    private readonly double _learningRate;
    private double[] _weights;
    private double _bias;

    public Perceptron(int inputSize, double learningRate = 0.1)
    {
        _learningRate = learningRate;
        // Initialise weights near zero — sign matters more than magnitude here.
        _weights = new double[inputSize];
        _bias = 0.0;
    }

    /// <summary>
    /// Forward pass: computes the raw net input and applies the step function.
    /// Returns 1.0 if w·x + b ≥ 0, else 0.0.
    /// </summary>
    public double Predict(double[] input)
    {
        double net = Matrix.Dot(_weights, input) + _bias;
        return Activations.Step(net);
    }

    /// <summary>
    /// Trains the Perceptron for one epoch over the provided dataset.
    /// Returns the number of misclassified examples (0 = converged).
    /// </summary>
    public int TrainEpoch(double[][] inputs, double[] targets)
    {
        int errors = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            double prediction = Predict(inputs[i]);
            double error = targets[i] - prediction;

            if (error != 0.0)
            {
                errors++;
                // Perceptron learning rule: w ← w + η·error·x
                for (int j = 0; j < _weights.Length; j++)
                    _weights[j] += _learningRate * error * inputs[i][j];
                _bias += _learningRate * error;
            }
        }
        return errors;
    }

    /// <summary>Exposes the learned weight vector for inspection/visualisation.</summary>
    public IReadOnlyList<double> Weights => _weights;

    /// <summary>Exposes the learned bias for inspection/visualisation.</summary>
    public double Bias => _bias;
}
