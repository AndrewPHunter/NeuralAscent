# Source Texts

Local copies of the freely available texts, plus a link to the one that has no legal
electronic copy. **Everything in this folder except this README is gitignored** — the books
are free to obtain but not mine to redistribute, so the repo carries the instructions and
not the files.

Run the commands below from the repository root to populate the folder.

---

## MacKay — *Information Theory, Inference, and Learning Algorithms* (CUP, 2003)

Free from the author's own site. Cambridge's notice on every page permits on-screen
viewing but not printing.

```bash
curl -o "docs/learning/texts/mackay-itila.pdf" http://www.inference.org.uk/itprnn/book.pdf
```

- Homepage: <https://www.inference.org.uk/mackay/itila/>
- 11.7 MB · SHA-256 `868adc5f0ef6630366b122d88d691acfbe8339978b4ec3f38fca5e231f135791`

---

## Hastie, Tibshirani & Friedman — *The Elements of Statistical Learning* (Springer, 2009)

2nd edition, **12th printing with corrections and table of contents, Jan 2017** — newer
than most print copies. Springer has agreed to keep the book on the web; the download page
redirects to Google Drive.

```bash
curl -L -o "docs/learning/texts/esl-2nd-print12.pdf" \
  "https://drive.google.com/uc?export=download&id=1--Wo5Hcl2y_v3DL-tGgcJHRPdtjiVYjS"
```

- Download page: <https://hastie.su.domains/ElemStatLearn/download.html>
- 13.4 MB · 764 pp. · SHA-256 `8d098d65cf53925ba0fc13a52a2790d48a32433223cbd876d0a527cd1afe2e0f`

---

## Goodfellow, Bengio & Courville — *Deep Learning* (MIT Press, 2016)

**No PDF exists, by contract.** The authors state it plainly in their FAQ:

> Can I get a PDF of this book? No, our contract with MIT Press forbids distribution of too
> easily copied electronic formats of the book.
>
> Why are you using HTML format? This format is a sort of weak DRM required by our contract
> with MIT Press.

The free HTML edition is the only authorised electronic form. Unofficial PDFs circulate;
they are unauthorised redistribution and are not used here.

- Read online: <https://www.deeplearningbook.org/>
- `Deep Learning (Goodfellow) — read online.webloc` in this folder opens it directly.

---

## Prince — *Understanding Deep Learning* (MIT Press, 2023)

Free PDF from the author's own GitHub, distributed as **versioned releases** — pin the
version rather than tracking `latest`, so a citation stays valid.

```bash
curl -L -o "docs/learning/texts/prince-udl-v5.0.3.pdf" \
  "https://github.com/udlbook/udlbook/releases/download/v5.0.3/UnderstandingDeepLearning_02_09_26_C.pdf"
```

- Homepage: <https://udlbook.github.io/udlbook/> · Releases: <https://github.com/udlbook/udlbook/releases>
- **v5.0.3** · 21 MB · 541 pp. · SHA-256 `f8237d393163900fa8e43210e680a3f987b45ccac7750b372e156fae3df0bf32`

---

## Jurafsky & Martin — *Speech and Language Processing*, 3rd ed. (draft)

Free from Stanford. **This is a living draft and chapters are renumbered between
releases** — the authors' own page records that the former Ch. 8 (Transformers) was merged
into Ch. 7. Always cite the dated file, never "the current draft".

```bash
curl -L -o "docs/learning/texts/jurafsky-martin-slp3-aug26.pdf" \
  "https://web.stanford.edu/~jurafsky/slp3/ed3book_aug26.pdf"
```

- Homepage: <https://web.stanford.edu/~jurafsky/slp3/>
- **Aug 2026 draft** · 25 MB · 646 pp. · SHA-256 `88d0362c3bcb62a0cd09403fb80fd15e778dd53566943912ab1047cda3ff5c79`

---

## Everything else

The remaining seven texts are print only. See [`../library.md`](../library.md).
