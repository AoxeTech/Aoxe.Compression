# Zaabee.Compression

---

The wraps and extensions for compressors. It is also the compressor provider for all Zaabee technology stacks.

## Why use Zaabee.Compression?

There are many compressors in the .NET ecosystem, but they are not easy to use. Zaabee.Compression provides a unified interface / helper / extensions for all compressors, and it is also the compressor provider for all Zaabee technology stacks.

The compressors that Zaabee.Compression supports are as follows:

| Compressor |      Package       |      Reference       |
| :--------: | :----------------: | :------------------: |
|   Brotli   |   Zaabee.Brotli    |      Brotli.NET      |
|    BZip    | Zaabee.SharpZipLib |     SharpZipLib      |
|    GZip    | Zaabee.SharpZipLib |     SharpZipLib      |
|    LZ4     |     Zaabee.LZ4     | K4os.Compression.LZ4 |
|    LZMA    |    Zaabee.LZMA     |       LZMA-SDK       |
|    Zstd    |    Zaabee.Zstd     |       ZstdNet        |

## How to use Zaabee.Compression?

### Install

```shell
dotnet add package Zaabee.Brotli
dotnet add package Zaabee.SharpZipLib
dotnet add package Zaabee.LZ4
dotnet add package Zaabee.LZMA
dotnet add package Zaabee.Zstd
```

### Compress

```csharp
var bytes = Encoding.UTF8.GetBytes("Hello World");

var brotliBytes = bytes.ToBrotli();
var bzipBytes = bytes.ToBZip();
var gzipBytes = bytes.ToGZip();
var lz4Bytes = bytes.ToLZ4();
var lzmaBytes = bytes.ToLZMA();
var zstdBytes = bytes.ToZstd();
```

### Decompress

```csharp
var brotliDecompressBytes = brotliBytes.UnBrotli();
var bzipDecompressBytes = bzipBytes.UnBZip();
var gzipDecompressBytes = gzipBytes.UnGZip();
var lz4DecompressBytes = lz4Bytes.UnLZ4();
var lzmaDecompressBytes = lzmaBytes.UnLZMA();
var zstdDecompressBytes = zstdBytes.UnZstd();
```

### Compress with stream

```csharp
var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello World"));

var brotliStream = memoryStream.ToBrotli();
var bzipStream = memoryStream.ToBZip();
var gzipStream = memoryStream.ToGZip();
var lz4Stream = memoryStream.ToLZ4();
var lzmaStream = memoryStream.ToLZMA();
var zstdStream = memoryStream.ToZstd();
```

### Decompress with stream

```csharp
var brotliDecompressStream = brotliStream.UnBrotli();
var bzipDecompressStream = bzipStream.UnBZip();
var gzipDecompressStream = gzipStream.UnGZip();
var lz4DecompressStream = lz4Stream.UnLZ4();
var lzmaDecompressStream = lzmaStream.UnLZMA();
var zstdDecompressStream = zstdStream.UnZstd();
```

### IComepressor

Also you can use the interface `IComepressor` to compress and decompress. All Zaabee compressors implement this interface.

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

## Benchmark

```ini
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1105/22H2/2022Update/SunValley2)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-preview.2.23157.25
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
```

### Compress to bytes

|        Method |         Mean |       Error |      StdDev |          Min |          Max |       Median |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|-------------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|---------:|---------:|---------:|-----------:|
| BrotliToBytes |    57.230 μs |   0.2742 μs |   0.2565 μs |    56.843 μs |    57.681 μs |    57.109 μs |   8.1177 |   0.4272 |        - |    67985 B |
|  Bzip2ToBytes |   704.570 μs |  17.3233 μs |  51.0781 μs |   612.249 μs |   839.251 μs |   692.302 μs | 911.1328 | 901.3672 | 892.5781 | 12109517 B |
|   GzipToBytes |    85.141 μs |   1.6660 μs |   2.2241 μs |    81.175 μs |    89.705 μs |    86.203 μs |  38.0859 |  15.1367 |        - |   321114 B |
|    Lz4ToBytes |     1.320 μs |   0.0206 μs |   0.0193 μs |     1.291 μs |     1.355 μs |     1.317 μs |   0.1221 |        - |        - |     1025 B |
|   LzmaToBytes | 7,963.309 μs | 293.8978 μs | 866.5644 μs | 6,476.894 μs | 9,815.058 μs | 7,929.018 μs | 953.1250 | 937.5000 | 921.8750 | 48880617 B |
|   ZstdToBytes |     4.528 μs |   0.0320 μs |   0.0283 μs |     4.497 μs |     4.586 μs |     4.520 μs |   0.0153 |        - |        - |      128 B |

### Decompress from bytes

|          Method |       Mean |     Error |    StdDev |        Min |        Max |     Median |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|---------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-----------:|
| BrotliFromBytes |  37.268 μs | 0.3395 μs | 0.3010 μs |  36.692 μs |  37.682 μs |  37.327 μs |  13.4888 |   2.8076 |        - |   95.88 KB |
|  Bzip2FromBytes | 236.460 μs | 4.6774 μs | 8.0683 μs | 222.455 μs | 257.370 μs | 235.555 μs | 456.5430 | 447.2656 | 445.8008 | 4514.72 KB |
|   GzipFromBytes |  32.196 μs | 0.6187 μs | 0.7365 μs |  31.247 μs |  33.564 μs |  31.894 μs |   7.3853 |   0.8545 |        - |   60.84 KB |
|    Lz4FromBytes |   3.213 μs | 0.0635 μs | 0.0624 μs |   3.124 μs |   3.345 μs |   3.208 μs |   2.5291 |   0.0916 |        - |   20.69 KB |
|   LzmaFromBytes | 201.935 μs | 3.6354 μs | 3.4006 μs | 197.427 μs | 207.364 μs | 201.945 μs | 491.6992 | 484.8633 | 484.6191 | 4150.62 KB |
|   ZstdFromBytes |   2.322 μs | 0.0434 μs | 0.0406 μs |   2.253 μs |   2.393 μs |   2.328 μs |   1.2321 |        - |        - |   10.09 KB |

### Compress to stream

|         Method |         Mean |       Error |        StdDev |       Median |          Min |           Max |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|--------------- |-------------:|------------:|--------------:|-------------:|-------------:|--------------:|---------:|---------:|---------:|-----------:|
| BrotliToStream |    51.318 μs |   1.2666 μs |     3.6135 μs |    51.226 μs |    46.513 μs |     62.695 μs |   8.0566 |   0.4883 |        - |    67307 B |
|  Bzip2ToStream |   629.332 μs |  14.4047 μs |    41.5608 μs |   627.471 μs |   552.053 μs |    741.435 μs | 832.0313 | 822.2656 | 814.4531 | 12101506 B |
|   GzipToStream |    79.013 μs |   1.5438 μs |     2.3575 μs |    77.772 μs |    76.634 μs |     84.856 μs |  38.0859 |  15.1367 |        - |   321040 B |
|    Lz4ToStream |     1.298 μs |   0.0247 μs |     0.0265 μs |     1.302 μs |     1.265 μs |      1.335 μs |   0.1030 |        - |        - |      865 B |
|   LzmaToStream | 7,259.447 μs | 343.5457 μs | 1,012.9523 μs | 6,925.126 μs | 6,039.613 μs | 10,180.380 μs | 664.0625 | 648.4375 | 625.0000 | 48880369 B |
|   ZstdToStream |     5.705 μs |   0.1103 μs |     0.1270 μs |     5.664 μs |     5.563 μs |      5.984 μs |   1.2817 |   0.0458 |        - |    10736 B |

### Decompress from stream

|           Method |       Mean |      Error |     StdDev |     Median |        Min |        Max |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|----------------- |-----------:|-----------:|-----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-----------:|
| BrotliFromStream |  37.277 μs |  0.2171 μs |  0.1925 μs |  37.322 μs |  36.961 μs |  37.567 μs |  12.1460 |   2.4414 |        - |   85.72 KB |
|  Bzip2FromStream | 267.479 μs | 13.9943 μs | 40.5999 μs | 256.466 μs | 217.031 μs | 377.985 μs | 434.0820 | 427.2461 | 424.8047 | 4500.55 KB |
|   GzipFromStream |  32.753 μs |  0.5609 μs |  0.6460 μs |  32.835 μs |  31.453 μs |  33.658 μs |   6.1646 |   0.9766 |        - |   50.76 KB |
|    Lz4FromStream |   2.812 μs |  0.0557 μs |  0.0704 μs |   2.779 μs |   2.717 μs |   2.945 μs |   1.2970 |   0.0267 |        - |    10.6 KB |
|   LzmaFromStream | 200.095 μs |  3.9480 μs |  9.9049 μs | 196.244 μs | 188.099 μs | 228.151 μs | 474.6094 | 468.9941 | 468.7500 | 4140.47 KB |
|   ZstdFromStream |   2.852 μs |  0.0568 μs |  0.1174 μs |   2.828 μs |   2.688 μs |   3.188 μs |   2.4719 |   0.1755 |        - |   20.23 KB |
