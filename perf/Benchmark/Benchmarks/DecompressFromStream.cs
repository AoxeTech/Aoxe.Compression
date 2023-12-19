namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromStream
{
    private static readonly MemoryStream BrotliCompressStream = Zaabee
        .Brotli
        .BrotliHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibBzip2CompressStream = Zaabee
        .SharpZipLib
        .Bzip2Helper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibDeflateCompressStream = Zaabee
        .SharpZipLib
        .DeflateHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SharpZipLibGzipCompressStream = Zaabee
        .SharpZipLib
        .GzipHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionBrotliCompressStream = Zaabee
        .SystemIoCompression
        .BrotliHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionDeflateCompressStream = Zaabee
        .SystemIoCompression
        .DeflateHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SystemIoCompressionGzipCompressStream = Zaabee
        .SystemIoCompression
        .GzipHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream Lz4CompressStream = Zaabee
        .LZ4
        .Lz4Helper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream LzmaCompressStream = Zaabee
        .LZMA
        .LzmaHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream SnappyCompressStream = Zaabee
        .Snappy
        .SnappyHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream XzCompressStream = Zaabee
        .XZ
        .XzHelper
        .Compress(Consts.RawStream);
    private static readonly MemoryStream ZstdCompressStream = Zaabee
        .Zstd
        .ZstdHelper
        .Compress(Consts.RawStream);

    [Benchmark]
    public void BrotliFromStream() =>
        Zaabee.Brotli.BrotliHelper.Decompress(BrotliCompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibBzip2FromStream() =>
        Zaabee
            .SharpZipLib
            .Bzip2Helper
            .Decompress(SharpZipLibBzip2CompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibDeflateFromStream() =>
        Zaabee
            .SharpZipLib
            .DeflateHelper
            .Decompress(SharpZipLibDeflateCompressStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibGzipFromStream() =>
        Zaabee.SharpZipLib.GzipHelper.Decompress(SharpZipLibGzipCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionBzip2FromStream() =>
        Zaabee
            .SystemIoCompression
            .BrotliHelper
            .Decompress(SystemIoCompressionBrotliCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionDeflateFromStream() =>
        Zaabee
            .SystemIoCompression
            .DeflateHelper
            .Decompress(SystemIoCompressionDeflateCompressStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionGzipFromStream() =>
        Zaabee
            .SystemIoCompression
            .GzipHelper
            .Decompress(SystemIoCompressionGzipCompressStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() =>
        Zaabee.LZ4.Lz4Helper.Decompress(Lz4CompressStream, new MemoryStream());

    [Benchmark]
    public void LzmaFromStream() =>
        Zaabee.LZMA.LzmaHelper.Decompress(LzmaCompressStream, new MemoryStream());

    [Benchmark]
    public void SnappyFromStream() =>
        Zaabee.Snappy.SnappyHelper.Decompress(SnappyCompressStream, new MemoryStream());

    [Benchmark]
    public void XzFromStream() =>
        Zaabee.XZ.XzHelper.Decompress(XzCompressStream, new MemoryStream());

    [Benchmark]
    public void ZstdFromStream() =>
        Zaabee.Zstd.ZstdHelper.Decompress(ZstdCompressStream, new MemoryStream());
}
