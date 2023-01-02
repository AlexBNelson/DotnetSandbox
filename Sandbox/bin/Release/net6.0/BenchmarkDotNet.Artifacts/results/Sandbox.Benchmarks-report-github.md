``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2


```
|                                            Method |     Mean |     Error |    StdDev |   Median |      Gen0 |    Gen1 |   Gen2 |  Allocated |
|-------------------------------------------------- |---------:|----------:|----------:|---------:|----------:|--------:|-------:|-----------:|
|                       UserGenerator_GenerateUsers | 1.588 ms | 0.0795 ms | 0.2280 ms | 1.504 ms |  179.6875 | 74.2188 |      - |  956.73 KB |
|                UserGenerator_GenerateDynamicUsers | 1.395 ms | 0.0190 ms | 0.0168 ms | 1.397 ms |  177.7344 | 76.1719 |      - |  956.76 KB |
|                 UserProcessor_GetUserNameWithRole | 1.506 ms | 0.0415 ms | 0.1191 ms | 1.455 ms |  212.8906 | 50.7813 | 1.9531 | 1019.68 KB |
| UserProcessor_GetUserNameWithRoleStringArithmetic | 2.351 ms | 0.0519 ms | 0.1463 ms | 2.315 ms | 2000.0000 | 74.2188 | 3.9063 | 8340.18 KB |
|                             ObjectBoxer_BoxObject | 1.470 ms | 0.0277 ms | 0.0470 ms | 1.452 ms |  224.6094 | 93.7500 |      - | 1119.69 KB |
|                           ObjectBoxer_NoBoxObject | 1.522 ms | 0.0294 ms | 0.0705 ms | 1.513 ms |  208.9844 | 58.5938 |      - | 1076.78 KB |
