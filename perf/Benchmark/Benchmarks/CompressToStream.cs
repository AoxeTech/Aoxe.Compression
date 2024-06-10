namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToStream
{
    [Benchmark]
    public void BrotliToStream() =>
        Aoxe.Brotli.BrotliHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibBzip2ToStream() =>
        Aoxe.SharpZipLib.Bzip2Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibDeflateToStream() =>
        Aoxe.SharpZipLib.DeflateHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibGzipToStream() =>
        Aoxe.SharpZipLib.GzipHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionBrotliToStream() =>
        Aoxe.SystemIoCompression.BrotliHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionDeflateToStream() =>
        Aoxe.SystemIoCompression.DeflateHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionGzipToStream() =>
        Aoxe.SystemIoCompression.GzipHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4ToStream() => Aoxe.LZ4.Lz4Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void LzmaToStream() =>
        Aoxe.LZMA.LzmaHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SnappyToStream() =>
        Aoxe.Snappy.SnappyHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void XzToStream() => Aoxe.XZ.XzHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void ZstdToStream() =>
        Aoxe.Zstd.ZstdHelper.Compress(Consts.RawStream, new MemoryStream());
}
