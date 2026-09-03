# ⚡ NeuralAscent

```
███╗   ██╗███████╗██╗   ██╗██████╗  █████╗ ██╗
████╗  ██║██╔════╝██║   ██║██╔══██╗██╔══██╗██║
██╔██╗ ██║█████╗  ██║   ██║██████╔╝███████║██║
██║╚██╗██║██╔══╝  ██║   ██║██╔══██╗██╔══██║██║
██║ ╚████║███████╗╚██████╔╝██║  ██║██║  ██║███████╗
╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝

 █████╗ ███████╗ ██████╗███████╗███╗   ██╗████████╗
██╔══██╗██╔════╝██╔════╝██╔════╝████╗  ██║╚══██╔══╝
███████║███████╗██║     █████╗  ██╔██╗ ██║   ██║
██╔══██║╚════██║██║     ██╔══╝  ██║╚██╗██║   ██║
██║  ██║███████║╚██████╗███████╗██║ ╚████║   ██║
╚═╝  ╚═╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝
```

> *From a single threshold unit to the architecture that rewired an industry —*
> *built from scratch, in C#, one gradient at a time.*

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-13-239120)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](./LICENSE)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/AndrewPHunter/NeuralAscent/pulls)

---

## What Is This?

NeuralAscent is a working codebase and learning journal that climbs the full arc of neural network history — from Rosenblatt's Perceptron (1957) to Vaswani's Transformer (2017) — implemented from first principles in C# 13 / .NET 9.

No PyTorch. No TensorFlow. No `model.fit()`.

Every matrix multiply is a triple loop. Every gradient is computed explicitly. Every weight update is written as code rather than described as prose. The math *is* the code — and if you can read C#, you can read the math.

This repo exists because there's a difference between *understanding* backpropagation and *having implemented* backpropagation. One of those is a feeling. The other is knowledge.

---

## The Arc

Six architectures. Each one a direct answer to the failure of the previous.

```
  Perceptron ──► MLP ──► RNN ──► CNN ──► Attention ──► Transformer
     1957         1986    1986    1989       2015           2017
  "it learns"  "XOR?"  "time"  "vision"  "context"    "all of it"
```

| # | Network | Paper | Status | Notes |
|---|---------|-------|--------|-------|
| 01 | **Perceptron** | Rosenblatt, 1958 | ✅ Complete | Converges on AND/OR. Breaks on XOR. |
| 02 | **MLP** | Rumelhart, Hinton & Williams, 1986 | 🔧 Up next | Backprop. The engine of everything. |
| 03 | **RNN** | Rumelhart, Hinton & Williams, 1986 | 📐 Scaffold | BPTT and the vanishing gradient problem. |
| 04 | **CNN** | LeCun et al., 1989 | 📐 Scaffold | Convolution, pooling, weight sharing. |
| 05 | **Attention** | Bahdanau et al., 2015 | 📐 Scaffold | Query, Key, Value. The key insight. |
| 06 | **Transformer** | Vaswani et al., 2017 | 📐 Scaffold | Multi-head, positional encoding, the whole thing. |

Each network has a dedicated doc → [`docs/`](./docs/)

---

## Getting Started

**Prerequisites:** [.NET 9 SDK](https://dotnet.microsoft.com/download) — that's it.

```bash
git clone https://github.com/AndrewPHunter/NeuralAscent
cd NeuralAscent
dotnet run --project NeuralAscent
```

You'll get a full interactive CLI. Arrow keys to navigate. The Perceptron is live — watch it converge on AND and OR, then watch it fail on XOR in real time. The rest of the arc follows as the implementations land.

---

## Repository Map

```
NeuralAscent/
├── Core/
│   ├── Matrix.cs           ← Hand-rolled matrix ops. Triple loops. No apologies.
│   ├── Activations.cs      ← Sigmoid, ReLU, Tanh, Softmax — each with derivative
│   └── Extensions.cs       ← ArgMax, Fisher-Yates, array utils, pretty-print
├── UI/
│   ├── ConsoleUI.cs        ← Spectre.Console rendering: header, menus, panels
│   └── AsciiChart.cs       ← ASCII loss curve renderer
├── Networks/
│   ├── INetwork.cs         ← The contract every network honours
│   ├── 01_Perceptron/      ← ✅ Rosenblatt's original. Beautifully limited.
│   ├── 02_MLP/             ← 🔧 Coming next
│   ├── 03_RNN/             ← 📐 Scaffold
│   ├── 04_CNN/             ← 📐 Scaffold
│   ├── 05_Attention/       ← 📐 Scaffold
│   └── 06_Transformer/     ← 📐 Scaffold
├── Data/
│   ├── LogicGates.cs       ← AND, OR, NAND, XOR
│   └── Sequences.cs        ← Sine wave, Fibonacci, sliding-window builder
└── docs/
    ├── 00_overview.md      ← The full arc, explained
    ├── 01_perceptron.md    ← Theory, math, limitations, references
    ├── ...                 ← One doc per network
    └── learning/           ← Reading plan, library, and session notes
```

---

## The Learning Plan

This repo is a learning journal as much as a codebase. The reading that runs alongside the
implementation — nine print texts plus MacKay, mapped phase-by-phase onto the six modules —
lives in [`docs/learning/`](./docs/learning/).

It is kept in public in its actual state: implementations that aren't written yet are
scaffolds, notes that aren't taken yet are empty files, and chapter citations that haven't
been checked against the shelf are flagged as unverified rather than presented as fact.

---

## On the Math

This repo doesn't shy away from equations. Activation functions are implemented alongside their exact derivatives. Matrix operations are annotated with the operation they represent. When backpropagation arrives, every delta and every chain rule application will be visible in the code — not abstracted, not hidden, *there*.

The `docs/` folder exists for the theory layer: historical context, the core intuition, key equations, and what each architecture *cannot* do (which is always more instructive than what it can).

If something looks unfamiliar, the docs are the first stop. The papers are the second.

---

## Why C#?

Because the interesting question isn't *which framework can train this fastest* — it's *what is actually happening*. C# is expressive enough to write clean pedagogical code, typed strictly enough to make errors obvious, and far enough from the Python ML ecosystem that there's no temptation to reach for a library that does the interesting part for you.

Also, underrepresented in this space. That seemed worth fixing.

---

## Contributing

If you spot a mathematical error, a misleading comment, or a place where clarity was sacrificed for brevity — open an issue or a PR. This is a learning resource first; correctness matters more than elegance.

Feature additions (new architectures, additional datasets, visualisation improvements) are welcome with a note on the pedagogical intent.

---

## License

MIT © 2025 [Andrew P. Hunter](https://github.com/AndrewPHunter)

*Built in public. Learning out loud.*