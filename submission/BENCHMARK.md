# Benchmark Analysis — String Concatenation vs StringBuilder

Run with:
```
cd AcademyScheduleAnalyzer
dotnet run -c Release -- --benchmark
```

## Results

BenchmarkDotNet, `[MemoryDiagnoser]`, `[Params(100, 1000, 10000, 100000)]`:

| Method                     | Iterations | Mean                 | Error               | StdDev               | Gen0          | Gen1          | Gen2          | Allocated        |
|----------------------------|-----------:|---------------------:|---------------------:|----------------------:|--------------:|--------------:|--------------:|-----------------:|
| StringConcatenation        | 100        | 10,241.0 ns           | 1,100.09 ns           | 3,243.6 ns             | 13.2446       | 0.0458        | -             | 81.21 KB         |
| StringBuilderConcatenation | 100        | 730.2 ns              | 37.15 ns              | 105.4 ns               | 0.6657        | 0.0057        | -             | 4.08 KB          |
| StringConcatenation        | 1000       | 506,119.1 ns           | 11,630.81 ns          | 32,422.0 ns            | 1278.3203     | 50.7813       | -             | 7,843.71 KB      |
| StringBuilderConcatenation | 1000       | 3,945.5 ns             | 86.65 ns              | 243.0 ns               | 5.2719        | 0.3128        | -             | 32.35 KB         |
| StringConcatenation        | 10000      | 103,941,100.0 ns       | 2,031,001.45 ns       | 3,448,794.9 ns         | 912800.0000   | 883800.0000   | 149800.0000   | 781,611.25 KB    |
| StringBuilderConcatenation | 10000      | 125,729.3 ns           | 2,479.65 ns           | 5,176.0 ns             | 239.0137      | 239.0137      | 39.7949       | 314.25 KB        |
| StringConcatenation        | 100000     | 18,145,708,005.2 ns    | 405,700,481.09 ns     | 1,170,538,734.9 ns     | 14581000.0000 | 14538000.0000 | 14532000.0000 | 78,132,434.63 KB |
| StringBuilderConcatenation | 100000     | 1,393,201.8 ns         | 34,832.69 ns          | 99,379.6 ns            | 498.0469      | 498.0469      | 498.0469      | 3,133.3 KB       |

## Comparison: string vs StringBuilder

StringBuilder was faster at every size, and it wins by more as the size grows:

- 100 iterations: ~14x faster
- 1,000 iterations: ~128x faster
- 10,000 iterations: ~827x faster
- 100,000 iterations: ~13,000x faster

## Memory allocation observations

StringConcatenation allocated way more memory than StringBuilder at every size:

- 100 iterations: 81 KB vs 4 KB
- 1,000 iterations: 7,844 KB vs 32 KB
- 10,000 iterations: 781,611 KB vs 314 KB
- 100,000 iterations: 78 GB vs 3 MB

At 100,000 iterations, StringConcatenation also causes millions of Gen2 collections (the most expensive kind), while StringBuilder barely touches Gen2.

## Answers to the benchmark analysis questions

**Which approach was faster with 100 iterations?**
StringBuilder — 730 ns vs 10,241 ns.

**Which approach was faster with 100,000 iterations?**
StringBuilder — 1.39 ms vs 18.15 seconds.

**Which approach allocated more memory?**
StringConcatenation, by a huge margin — 78 GB vs 3 MB at 100,000 iterations.

**What happened to string concatenation performance as the loop size increased?**
It got much worse than expected. 10x more iterations should mean ~10x more time, but it actually took ~170–200x longer each step up. Time grows roughly with the square of the loop size, not in a straight line.

**Why does repeated string concatenation create additional allocations?**
Strings can't be changed once created. Every `+=` makes a whole new string (old content + new text copied together) and throws away the old one. So more appends = more copies = more memory.

**Why does StringBuilder usually perform better when text is repeatedly appended?**
StringBuilder keeps one buffer in memory and just writes into it. It only needs to resize that buffer occasionally, not on every single append, so it does far less copying.

**Is StringBuilder always better than normal string operations? Explain.**
No. For one or two concatenations, plain strings are simpler and the speed difference doesn't matter. StringBuilder pays off once you're appending in a loop, especially a big one — the numbers above show the gap gets massive as the loop grows.
