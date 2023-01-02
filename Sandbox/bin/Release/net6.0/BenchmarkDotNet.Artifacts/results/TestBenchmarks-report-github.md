``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2


```
|                             Method |     Mean |     Error |    StdDev |     Gen0 |    Gen1 | Allocated |
|----------------------------------- |---------:|----------:|----------:|---------:|--------:|----------:|
|        UserGenerator_GenerateUsers | 1.177 ms | 0.0492 ms | 0.1371 ms | 140.6250 | 66.4063 | 774.56 KB |
| UserGenerator_GenerateDynamicUsers | 1.288 ms | 0.0923 ms | 0.2722 ms | 138.6719 | 68.3594 | 774.47 KB |
