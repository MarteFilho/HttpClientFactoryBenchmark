```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.2861/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
| Method                              | Mean     | Error    | StdDev   |
|------------------------------------ |---------:|---------:|---------:|
| DefaultHttpClient                   | 25.11 ms | 0.496 ms | 0.726 ms |
| HttpClientWithFactory               | 24.38 ms | 0.450 ms | 0.398 ms |
| HttpClientWithFactoryAndHeadersRead | 24.00 ms | 0.417 ms | 0.370 ms |
