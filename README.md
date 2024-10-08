# Aoxe.Compression

English | [简体中文](README-zh_CN.md)

---

Provide an easy way to use compressions. These packages support the wraps and extensions for compressors. It is also the compressor provider for all Aoxe technology stacks like configuration, cache, queue, rpc, etc.

## 1. Why use Aoxe.Compression?

There are many compressors in the .NET ecosystem, but they are not easy to use. Aoxe.Compression provides a unified interface / helper / extensions for all compressors, and it is also the compressor provider for all Aoxe technology stacks.

The compressors that Aoxe.Compression supports are as follows:

| Compressor |                   Package                   |              Reference              |
|:----------:|:-------------------------------------------:|:-----------------------------------:|
|   Brotli   |   Aoxe.Brotli / Aoxe.SystemIoCompression    | Brotli.NET / System.IO.Compression  |
|    LZ4     |                  Aoxe.LZ4                   |        K4os.Compression.LZ4         |
|    LZMA    |                  Aoxe.LZMA                  |              LZMA-SDK               |
|   BZip2    |              Aoxe.SharpZipLib               |             SharpZipLib             |
|  Deflate   | Aoxe.SharpZipLib / Aoxe.SystemIoCompression | SharpZipLib / System.IO.Compression |
|    GZip    | Aoxe.SharpZipLib / Aoxe.SystemIoCompression | SharpZipLib / System.IO.Compression |
|   Snappy   |                 Aoxe.Snappy                 |             IronSnappy              |
|    ZLib    |          Aoxe.SystemIoCompression           |        System.IO.Compression        |
|     XZ     |                   Aoxe.XZ                   |         XZ.NET-netstandard          |
|    Zstd    |                  Aoxe.Zstd                  |               ZstdNet               |

## 2. How to use Aoxe.Compression?

### 2.1. Install

You can install the package which you want on nuget

```shell
dotnet add package Aoxe.Brotli
dotnet add package Aoxe.LZ4
dotnet add package Aoxe.LZMA
dotnet add package Aoxe.SharpZipLib
dotnet add package Aoxe.Snappy
dotnet add package Aoxe.SystemIoCompression
dotnet add package Aoxe.XZ
dotnet add package Aoxe.Zstd
```

### 2.2. Compress (use extension method)

```csharp
var bytes = Encoding.UTF8.GetBytes("Hello World");

var brotliBytes = bytes.ToBrotli();
var bzipBytes = bytes.ToBZip();
var gzipBytes = bytes.ToGZip();
var lz4Bytes = bytes.ToLz4();
var lzmaBytes = bytes.ToLzma();
var xzBytes = bytes.ToXz();
var zstdBytes = bytes.ToZstd();
```

### 2.3. Decompress (use extension method)

```csharp
var brotliDecompressBytes = brotliBytes.UnBrotli();
var bzipDecompressBytes = bzipBytes.UnBZip();
var gzipDecompressBytes = gzipBytes.UnGZip();
var lz4DecompressBytes = lz4Bytes.UnLz4();
var lzmaDecompressBytes = lzmaBytes.UnLzma();
var xzDecompressBytes = xzBytes.UnXz();
var zstdDecompressBytes = zstdBytes.UnZstd();
```

### 2.4. Compress with stream

```csharp
var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello World"));

var brotliStream = memoryStream.ToBrotli();
var bzipStream = memoryStream.ToBZip();
var gzipStream = memoryStream.ToGZip();
var lz4Stream = memoryStream.ToLz4();
var lzmaStream = memoryStream.ToLzma();
var xzStream = memoryStream.ToXz();
var zstdStream = memoryStream.ToZstd();
```

### 2.5. Decompress with stream

```csharp
var brotliDecompressStream = brotliStream.UnBrotli();
var bzipDecompressStream = bzipStream.UnBZip();
var gzipDecompressStream = gzipStream.UnGZip();
var lz4DecompressStream = lz4Stream.UnLz4();
var lzmaDecompressStream = lzmaStream.UnLzma();
var xzDecompressStream = xzStream.UnXz();
var zstdDecompressStream = zstdStream.UnZstd();
```

### 2.6. IComepressor

Also you can use the interface `IComepressor` to compress and decompress. All Aoxe compressors implement this interface.

```csharp
// Inject (ICompressor compressor)
var bytes = Encoding.UTF8.GetBytes("Hello World");
var compressedBytes = compressor.Compress(bytes);
var decompressedBytes = compressor.Decompress(compressedBytes);

// Or use with stream
var memoryStream = new MemoryStream(bytes);
var compressedStream = compressor.Compress(memoryStream);
var decompressedStream = compressor.Decompress(compressedStream);

// You can use stream out of the box
var compressedStream = new MemoryStream();
compressor.Compress(memoryStream, compressedStream);
var decompressedStream = new MemoryStream();
compressor.Decompress(compressedStream, decompressedStream);

// Also the stream functions support async mode
```

## 3. Benchmark

```ini
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1105/22H2/2022Update/SunValley2)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-preview.2.23157.25
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
```

### 3.1. Compress to bytes

|        Method |         Mean |       Error |      StdDev |       Median |          Min |          Max |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|-------------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|---------:|---------:|---------:|-----------:|
| BrotliToBytes |    58.171 μs |   0.9971 μs |   1.2246 μs |    57.813 μs |    56.325 μs |    61.702 μs |   8.1177 |   0.3662 |        - |    67986 B |
|  Bzip2ToBytes |   631.366 μs |  13.7806 μs |  39.3168 μs |   626.461 μs |   563.547 μs |   763.059 μs | 840.8203 | 830.0781 | 823.2422 | 12101792 B |
|   GzipToBytes |    86.458 μs |   1.7207 μs |   3.6669 μs |    85.666 μs |    81.680 μs |    95.782 μs |  38.0859 |  15.1367 |        - |   321112 B |
|    Lz4ToBytes |     1.394 μs |   0.0275 μs |   0.0403 μs |     1.400 μs |     1.336 μs |     1.491 μs |   0.1221 |        - |        - |     1024 B |
|   LzmaToBytes | 7,045.124 μs | 253.8111 μs | 748.3677 μs | 6,693.738 μs | 6,247.715 μs | 9,145.466 μs | 968.7500 | 953.1250 | 929.6875 | 48880615 B |
|     XzToBytes |   174.001 μs |   1.4839 μs |   1.2391 μs |   173.823 μs |   172.278 μs |   176.960 μs |   0.4883 |        - |        - |     4848 B |
|   ZstdToBytes |     4.715 μs |   0.0175 μs |   0.0137 μs |     4.715 μs |     4.695 μs |     4.746 μs |   0.0153 |        - |        - |      128 B |

### 3.2. Decompress from bytes

|          Method |       Mean |      Error |     StdDev |     Median |        Min |        Max |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|---------------- |-----------:|-----------:|-----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-----------:|
| BrotliFromBytes |  39.426 μs |  0.7356 μs |  1.1011 μs |  39.271 μs |  37.872 μs |  41.571 μs |  13.4888 |   2.8076 |        - |   95.88 KB |
|  Bzip2FromBytes | 259.059 μs | 21.2853 μs | 62.7601 μs | 215.391 μs | 206.746 μs | 376.599 μs | 510.7422 | 500.9766 | 500.0000 | 4477.55 KB |
|   GzipFromBytes |  34.385 μs |  0.6699 μs |  0.8471 μs |  34.411 μs |  33.315 μs |  36.232 μs |   7.3853 |   0.8545 |        - |   60.84 KB |
|    Lz4FromBytes |   3.407 μs |  0.0677 μs |  0.1256 μs |   3.437 μs |   3.235 μs |   3.708 μs |   2.5291 |   0.0916 |        - |   20.69 KB |
|   LzmaFromBytes | 199.142 μs |  3.3706 μs |  3.8816 μs | 198.042 μs | 194.970 μs | 211.838 μs | 498.2910 | 491.6992 | 491.2109 | 4150.62 KB |
|     XzFromBytes |  41.167 μs |  0.3790 μs |  0.3360 μs |  41.078 μs |  40.768 μs |  41.675 μs |   2.9297 |        - |        - |   24.38 KB |
|   ZstdFromBytes |   2.414 μs |  0.0478 μs |  0.0850 μs |   2.402 μs |   2.291 μs |   2.610 μs |   1.2321 |        - |        - |   10.09 KB |

### 3.3. Compress to stream

|         Method |         Mean |       Error |      StdDev |          Min |          Max |       Median |      Gen0 |     Gen1 |     Gen2 |  Allocated |
|--------------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|----------:|---------:|---------:|-----------:|
| BrotliToStream |    53.432 μs |   0.9765 μs |   0.8656 μs |    51.863 μs |    54.851 μs |    53.436 μs |    8.0566 |   0.3662 |        - |    67308 B |
|  Bzip2ToStream |   611.673 μs |  12.4545 μs |  35.7344 μs |   530.748 μs |   706.533 μs |   610.241 μs |  893.5547 | 882.8125 | 875.9766 | 12101857 B |
|   GzipToStream |    84.260 μs |   1.6760 μs |   2.5594 μs |    80.827 μs |    89.060 μs |    83.989 μs |   38.0859 |  15.1367 |        - |   321040 B |
|    Lz4ToStream |     1.301 μs |   0.0116 μs |   0.0102 μs |     1.286 μs |     1.319 μs |     1.299 μs |    0.1030 |        - |        - |      864 B |
|   LzmaToStream | 6,530.159 μs | 129.0695 μs | 138.1029 μs | 6,246.068 μs | 6,789.923 μs | 6,521.767 μs | 1000.0000 | 984.3750 | 960.9375 | 48880472 B |
|     XzToStream |   179.067 μs |   3.5628 μs |   4.2413 μs |   172.960 μs |   185.659 μs |   179.572 μs |    0.4883 |        - |        - |     4648 B |
|   ZstdToStream |     5.819 μs |   0.1149 μs |   0.1534 μs |     5.597 μs |     6.097 μs |     5.797 μs |    1.2817 |   0.0458 |        - |    10736 B |

### 3.4. Decompress from stream

|           Method |       Mean |      Error |     StdDev |     Median |        Min |        Max |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|----------------- |-----------:|-----------:|-----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-----------:|
| BrotliFromStream |  38.357 μs |  0.5158 μs |  0.4825 μs |  38.115 μs |  37.868 μs |  39.138 μs |  12.1460 |   2.4414 |        - |   85.72 KB |
|  Bzip2FromStream | 254.942 μs | 20.5926 μs | 60.7177 μs | 212.982 μs | 198.327 μs | 392.069 μs | 505.8594 | 497.0703 | 496.0938 | 4467.51 KB |
|   GzipFromStream |  34.692 μs |  0.6868 μs |  1.3874 μs |  34.369 μs |  32.555 μs |  38.429 μs |   6.1646 |   0.9766 |        - |   50.75 KB |
|    Lz4FromStream |   2.922 μs |  0.0531 μs |  0.0444 μs |   2.926 μs |   2.844 μs |   3.012 μs |   1.2970 |   0.0267 |        - |    10.6 KB |
|   LzmaFromStream | 204.926 μs |  3.9194 μs |  3.0600 μs | 203.938 μs | 201.239 μs | 210.138 μs | 500.0000 | 494.6289 | 494.1406 | 4140.54 KB |
|     XzFromStream |  40.992 μs |  0.8186 μs |  0.8406 μs |  41.137 μs |  39.477 μs |  42.377 μs |   1.7090 |   0.0610 |        - |    14.3 KB |
|   ZstdFromStream |   3.007 μs |  0.0582 μs |  0.0924 μs |   3.002 μs |   2.845 μs |   3.198 μs |   2.4719 |   0.0877 |        - |   20.23 KB |

Thank`s for [JetBrains](https://www.jetbrains.com/) for the great support in providing assistance and user-friendly environment for my open source projects.

[![JetBrains](https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg?_gl=1*f25lxa*_ga*MzI3ODk2MjY0LjE2NzA0NjY4MDQ.*_ga_9J976DJZ68*MTY4OTY4NzY5OS4zNC4xLjE2ODk2ODgwMDAuNTMuMC4w)](https://www.jetbrains.com/community/opensource/#support)
