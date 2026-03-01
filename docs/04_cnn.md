# The Convolutional Neural Network (CNN)

> *"Gradient-based learning applied to document recognition."*
> — LeCun, Bottou, Bengio & Haffner, 1998

---

## Historical Context

**Who:** Yann LeCun, Léon Bottou, Yoshua Bengio, Patrick Haffner
**When:** 1989 (initial LeNet); 1998 (LeNet-5, definitive paper); 2012 (AlexNet — mainstream adoption)
**Problem:** Images have spatial structure. A fully connected network treats every pixel independently — it has no way to use the fact that nearby pixels are related, and it requires an enormous number of parameters to process high-resolution inputs.

LeCun's key insight was to borrow the idea of *convolution* from signal processing: instead of learning one weight per input-output connection, learn a small *kernel* (filter) and *slide it across the input*. The same kernel detects the same feature everywhere in the image. This is weight sharing, and it is what makes CNNs tractable.

The practical importance of CNNs became undeniable in 2012 when AlexNet (Krizhevsky, Sutskever, Hinton) won the ImageNet challenge by a margin that shocked the computer vision community and triggered the modern deep learning era.

---

## Core Intuition

**Convolution:** A kernel (small matrix of learned weights) is slid across the input, computing a dot product at each position. The result is a *feature map* — a new representation that encodes how much "like the kernel" each local region of the input is.

- A kernel trained to detect horizontal edges will produce high activations where horizontal edges are present, regardless of where in the image they appear.
- Multiple kernels detect multiple features simultaneously.

**Weight sharing:** The same kernel is reused at every position. A fully connected layer on a 224×224 image with 512 output neurons requires 224×224×512 ≈ 25.7 million weights for a single layer. A convolutional layer with a 3×3 kernel and 512 filters requires only 3×3×512 = 4,608 weights, regardless of image size.

**Pooling:** Max or average pooling reduces the spatial dimensions of the feature maps, building in translation invariance and reducing computation.

---

## Key Mathematics

**1-D convolution** (simpler to implement pedagogically):

```
(x * k)[i] = Σ_j k[j] · x[i + j]     (valid padding, no zero-padding)
```

**2-D convolution** (images):

```
(X * K)[i, j] = Σ_m Σ_n K[m, n] · X[i+m, j+n]
```

**Backprop through convolution:**

The gradient with respect to the kernel is the *cross-correlation* of the input with the output gradient:

```
∂L/∂K[m, n] = Σ_i Σ_j ∂L/∂Y[i, j] · X[i+m, j+n]
```

The gradient with respect to the input is the *full convolution* of the flipped kernel with the output gradient.

**Max pooling forward:**

```
pool[i] = max(x[i·stride .. i·stride + poolSize])
```

Backprop: gradient flows only through the position that achieved the maximum (the "argmax").

---

## Limitations

**Locality.** Convolutions are local — they compute relationships between nearby positions. Long-range relationships (e.g., matching a subject to a verb separated by many words, or correlating a face in one corner of an image with context in another) require many stacked layers for the receptive field to grow large enough.

**Fixed spatial structure.** Standard CNNs assume grid-structured input. Applying them to non-grid data (graphs, point clouds, irregular sequences) requires adaptation (Graph CNNs, PointNet, etc.).

**No explicit attention.** Every position is processed the same way. The network has no mechanism for learning that some positions are more important than others for a given task. This is the gap that attention mechanisms address.

---

## Implementation Notes

See `Networks/04_CNN/CNN.cs` (scaffold — to be implemented).

The 1-D implementation here is intentional: it preserves the mathematics of convolution without the complexity of 2-D index management, letting the learning mechanics stay visible.

Key things to implement and verify:
- The sliding window loop for the forward convolution
- The kernel gradient accumulation (cross-correlation in the backward pass)
- Max pooling with argmax bookkeeping for backprop
- A parameter count comparison: N-position input with K-size kernel uses K parameters; equivalent dense layer uses N parameters

---

## References

1. LeCun, Y., Bottou, L., Bengio, Y., & Haffner, P. (1998). *Gradient-based learning applied to document recognition.* Proceedings of the IEEE, 86(11), 2278–2324.
2. Krizhevsky, A., Sutskever, I., & Hinton, G.E. (2012). *ImageNet classification with deep convolutional neural networks.* NeurIPS 2012.
3. LeCun, Y., Boser, B., Denker, J.S., Henderson, D., Howard, R.E., Hubbard, W., & Jackel, L.D. (1989). *Backpropagation applied to handwritten zip code recognition.* Neural Computation, 1(4), 541–551.
