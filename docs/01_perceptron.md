# The Perceptron

> *"The perceptron is a device which is capable of learning to classify objects as members or non-members of a class."*
> — Frank Rosenblatt, 1958

---

## Historical Context

**Who:** Frank Rosenblatt, Cornell Aeronautical Laboratory
**When:** 1957 (described); 1960 (hardware: the Mark I Perceptron)
**Problem:** Can a machine learn to recognise patterns without being explicitly programmed?

The Perceptron was inspired by McCulloch and Pitts' 1943 model of the biological neuron. Rosenblatt's contribution was not the neuron model itself but the *learning algorithm* — the idea that a machine could adjust its own parameters based on whether its output was correct or not.

The Mark I Perceptron was physically implemented in hardware: 400 photocells arranged in a 20×20 grid, with connections to 512 "association units" and then to 8 response units. The weights were implemented as potentiometers adjusted by electric motors. It could be trained to distinguish simple shapes.

This was not a toy. It was a genuine demonstration that learning from data was possible.

---

## Core Intuition

The Perceptron makes a binary decision: is the input in class 1 or class 0?

It computes a *weighted sum* of the inputs, adds a bias, and applies a step function:

- If the sum is above the threshold, output 1
- Otherwise, output 0

The weights represent the "importance" of each input feature. Learning adjusts these weights so that the boundary between the two classes — the *decision boundary* — ends up in the right place.

The decision boundary of a Perceptron is always a hyperplane: a line in 2D, a plane in 3D, a flat subspace in higher dimensions. This is both its strength (simple, guaranteed convergence for linearly separable data) and its fundamental limitation.

---

## Key Mathematics

**Forward pass:**

```
net = w · x + b = Σᵢ wᵢxᵢ + b
ŷ   = step(net) = 1 if net ≥ 0, else 0
```

**Learning rule (Perceptron update):**

```
error = y − ŷ
wᵢ ← wᵢ + η · error · xᵢ    for all i
b  ← b  + η · error
```

Where `η` (eta) is the *learning rate*, a small positive constant controlling step size.

**Interpretation:** If the prediction is correct (`error = 0`), weights do not change. If the output is too high (`error = -1`), weights are pushed in the direction that reduces the net input. If too low (`error = +1`), weights are pushed to increase it.

**Convergence theorem:** If the data is linearly separable, the Perceptron learning algorithm is guaranteed to converge in a finite number of steps, regardless of initial weights.

---

## Limitations

**The XOR problem.** XOR assigns output 1 to inputs (0,1) and (1,0), and output 0 to (0,0) and (1,1). No single straight line can separate these four points into the correct two groups. The Perceptron will loop indefinitely on XOR, never converging.

Minsky and Papert's 1969 book *Perceptrons* proved this limitation formally and generalisedly, showing that many interesting functions are not linearly separable. The book contributed to a significant reduction in neural network research funding through the 1970s — the first "AI winter."

**No gradient signal.** The step function has zero derivative almost everywhere and undefined derivative at zero. This means gradient descent cannot be applied. The Perceptron update rule is a *mistake-driven* rule, not a gradient-based one. When we move to the MLP, we switch to differentiable activations specifically to enable backpropagation.

---

## Implementation Notes

See `Networks/01_Perceptron/Perceptron.cs`.

Key things to look for in the code:
- The forward pass uses `Matrix.Dot` — the weight-input dot product is the same operation that appears at every layer of every deeper network
- The update rule is directly encoded: `weights[j] += learningRate * error * inputs[i][j]`
- The runner (`PerceptronRunner.cs`) trains on AND, OR, and XOR — demonstrating convergence on the first two and failure on the third

The XOR failure is not a bug; it is the lesson.

---

## References

1. Rosenblatt, F. (1958). *The perceptron: A probabilistic model for information storage and organization in the brain.* Psychological Review, 65(6), 386–408.
2. Minsky, M., & Papert, S. (1969). *Perceptrons: An Introduction to Computational Geometry.* MIT Press.
3. Novikoff, A.B.J. (1963). *On convergence proofs on perceptrons.* Symposium on Mathematical Theory of Automata.
