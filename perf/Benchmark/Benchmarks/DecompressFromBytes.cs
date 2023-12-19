namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromBytes
{
    private static readonly byte[] BrotliCompressBytes = Zaabee
        .Brotli
        .BrotliHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibBzip2CompressBytes = Zaabee
        .SharpZipLib
        .Bzip2Helper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibDeflateCompressBytes = Zaabee
        .SharpZipLib
        .DeflateHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SharpZipLibGzipCompressBytes = Zaabee
        .SharpZipLib
        .GzipHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionBrotliCompressBytes = Zaabee
        .SystemIoCompression
        .BrotliHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionDeflateCompressBytes = Zaabee
        .SystemIoCompression
        .DeflateHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SystemIoCompressionGzipCompressBytes = Zaabee
        .SystemIoCompression
        .GzipHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] Lz4CompressBytes = Zaabee
        .LZ4
        .Lz4Helper
        .Compress(Consts.RawBytes);
    private static readonly byte[] LzmaCompressBytes = Zaabee
        .LZMA
        .LzmaHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] SnappyCompressBytes = Zaabee
        .Snappy
        .SnappyHelper
        .Compress(Consts.RawBytes);
    private static readonly byte[] XzCompressBytes = Zaabee.XZ.XzHelper.Compress(Consts.RawBytes);
    private static readonly byte[] ZstdCompressBytes = Zaabee
        .Zstd
        .ZstdHelper
        .Compress(Consts.RawBytes);

    [Benchmark]
    public void BrotliFromBytes() => Zaabee.Brotli.BrotliHelper.Decompress(BrotliCompressBytes);

    [Benchmark]
    public void SharpZipLibBzip2FromBytes() =>
        Zaabee.SharpZipLib.Bzip2Helper.Decompress(SharpZipLibBzip2CompressBytes);

    [Benchmark]
    public void SharpZipLibDeflateFromBytes() =>
        Zaabee.SharpZipLib.DeflateHelper.Decompress(SharpZipLibDeflateCompressBytes);

    [Benchmark]
    public void SharpZipLibGzipFromBytes() =>
        Zaabee.SharpZipLib.GzipHelper.Decompress(SharpZipLibGzipCompressBytes);

    [Benchmark]
    public void SystemIoCompressionBrotliFromBytes() =>
        Zaabee.SystemIoCompression.BrotliHelper.Decompress(SystemIoCompressionBrotliCompressBytes);

    [Benchmark]
    public void SystemIoCompressionDeflateFromBytes() =>
        Zaabee
            .SystemIoCompression
            .DeflateHelper
            .Decompress(SystemIoCompressionDeflateCompressBytes);

    [Benchmark]
    public void SystemIoCompressionGzipFromBytes() =>
        Zaabee.SystemIoCompression.GzipHelper.Decompress(SystemIoCompressionGzipCompressBytes);

    [Benchmark]
    public void Lz4FromBytes() => Zaabee.LZ4.Lz4Helper.Decompress(Lz4CompressBytes);

    [Benchmark]
    public void LzmaFromBytes() => Zaabee.LZMA.LzmaHelper.Decompress(LzmaCompressBytes);

    [Benchmark]
    public void SnappyFromBytes() => Zaabee.Snappy.SnappyHelper.Decompress(SnappyCompressBytes);

    [Benchmark]
    public void XzFromBytes() => Zaabee.XZ.XzHelper.Decompress(XzCompressBytes);

    [Benchmark]
    public void ZstdFromBytes() => Zaabee.Zstd.ZstdHelper.Decompress(ZstdCompressBytes);
}
