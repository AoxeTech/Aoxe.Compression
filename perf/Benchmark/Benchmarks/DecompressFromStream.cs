namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromStream
{
    private static readonly MemoryStream BrotliCompressStream = Aoxe.Brotli
        .BrotliHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibBzip2CompressStream = Aoxe.SharpZipLib
        .Bzip2Helper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibDeflateCompressStream = Aoxe.SharpZipLib
        .DeflateHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibGzipCompressStream = Aoxe.SharpZipLib
        .GzipHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionBrotliCompressStream =
        Aoxe.SystemIoCompression.BrotliHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionDeflateCompressStream =
        Aoxe.SystemIoCompression.DeflateHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionGzipCompressStream =
        Aoxe.SystemIoCompression.GzipHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream Lz4CompressStream = Aoxe.LZ4
        .Lz4Helper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream LzmaCompressStream = Aoxe.LZMA
        .LzmaHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SnappyCompressStream = Aoxe.Snappy
        .SnappyHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream XzCompressStream = Aoxe.XZ
        .XzHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream ZstdCompressStream = Aoxe.Zstd
        .ZstdHelper
        .Compress(Consts.RawStream);

    [Benchmark]
    public void BrotliFromStream() =>
        Aoxe.Brotli.BrotliHelper.Decompress(BrotliCompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibBzip2FromStream() =>
        Aoxe.SharpZipLib.Bzip2Helper.Decompress(SharpZipLibBzip2CompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibDeflateFromStream() =>
        Aoxe.SharpZipLib
            .DeflateHelper
            .Decompress(SharpZipLibDeflateCompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibGzipFromStream() =>
        Aoxe.SharpZipLib.GzipHelper.Decompress(SharpZipLibGzipCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionBzip2FromStream() =>
        Aoxe.SystemIoCompression
            .BrotliHelper
            .Decompress(SystemIoCompressionBrotliCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionDeflateFromStream() =>
        Aoxe.SystemIoCompression
            .DeflateHelper
            .Decompress(SystemIoCompressionDeflateCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionGzipFromStream() =>
        Aoxe.SystemIoCompression
            .GzipHelper
            .Decompress(SystemIoCompressionGzipCompressStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() =>
        Aoxe.LZ4.Lz4Helper.Decompress(Lz4CompressStream, new MemoryStream());

    [Benchmark]
    public void LzmaFromStream() =>
        Aoxe.LZMA.LzmaHelper.Decompress(LzmaCompressStream, new MemoryStream());

    [Benchmark]
    public void SnappyFromStream() =>
        Aoxe.Snappy.SnappyHelper.Decompress(SnappyCompressStream, new MemoryStream());

    [Benchmark]
    public void XzFromStream() => Aoxe.XZ.XzHelper.Decompress(XzCompressStream, new MemoryStream());

    [Benchmark]
    public void ZstdFromStream() =>
        Aoxe.Zstd.ZstdHelper.Decompress(ZstdCompressStream, new MemoryStream());
}
