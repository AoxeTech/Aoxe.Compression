namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromBytes
{
    private static readonly byte[] BrotliCompressBytes = Aoxe.Brotli
        .BrotliHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibBzip2CompressBytes = Aoxe.SharpZipLib
        .Bzip2Helper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibDeflateCompressBytes = Aoxe.SharpZipLib
        .DeflateHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibGzipCompressBytes = Aoxe.SharpZipLib
        .GzipHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionBrotliCompressBytes = Aoxe.SystemIoCompression
        .BrotliHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionDeflateCompressBytes =
        Aoxe.SystemIoCompression.DeflateHelper.Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionGzipCompressBytes = Aoxe.SystemIoCompression
        .GzipHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] Lz4CompressBytes = Aoxe.LZ4.Lz4Helper.Compress(Consts.RawBytes);
    private static readonly byte[] LzmaCompressBytes = Aoxe.LZMA
        .LzmaHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SnappyCompressBytes = Aoxe.Snappy
        .SnappyHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] XzCompressBytes = Aoxe.XZ.XzHelper.Compress(Consts.RawBytes);
    private static readonly byte[] ZstdCompressBytes = Aoxe.Zstd
        .ZstdHelper
        .Compress(Consts.RawBytes);

    [Benchmark]
    public void BrotliFromBytes() => Aoxe.Brotli.BrotliHelper.Decompress(BrotliCompressBytes);

    [Benchmark]
    public void SharpZipLibBzip2FromBytes() =>
        Aoxe.SharpZipLib.Bzip2Helper.Decompress(SharpZipLibBzip2CompressBytes);

    [Benchmark]
    public void SharpZipLibDeflateFromBytes() =>
        Aoxe.SharpZipLib.DeflateHelper.Decompress(SharpZipLibDeflateCompressBytes);

    [Benchmark]
    public void SharpZipLibGzipFromBytes() =>
        Aoxe.SharpZipLib.GzipHelper.Decompress(SharpZipLibGzipCompressBytes);

    [Benchmark]
    public void SystemIoCompressionBrotliFromBytes() =>
        Aoxe.SystemIoCompression.BrotliHelper.Decompress(SystemIoCompressionBrotliCompressBytes);

    [Benchmark]
    public void SystemIoCompressionDeflateFromBytes() =>
        Aoxe.SystemIoCompression.DeflateHelper.Decompress(SystemIoCompressionDeflateCompressBytes);

    [Benchmark]
    public void SystemIoCompressionGzipFromBytes() =>
        Aoxe.SystemIoCompression.GzipHelper.Decompress(SystemIoCompressionGzipCompressBytes);

    [Benchmark]
    public void Lz4FromBytes() => Aoxe.LZ4.Lz4Helper.Decompress(Lz4CompressBytes);

    [Benchmark]
    public void LzmaFromBytes() => Aoxe.LZMA.LzmaHelper.Decompress(LzmaCompressBytes);

    [Benchmark]
    public void SnappyFromBytes() => Aoxe.Snappy.SnappyHelper.Decompress(SnappyCompressBytes);

    [Benchmark]
    public void XzFromBytes() => Aoxe.XZ.XzHelper.Decompress(XzCompressBytes);

    [Benchmark]
    public void ZstdFromBytes() => Aoxe.Zstd.ZstdHelper.Decompress(ZstdCompressBytes);
}
