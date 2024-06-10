namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToBytes
{
    [Benchmark]
    public void BrotliToBytes() => Aoxe.Brotli.BrotliHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibBzip2ToBytes() => Aoxe.SharpZipLib.Bzip2Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibDeflateToBytes() =>
        Aoxe.SharpZipLib.DeflateHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibGzipToBytes() => Aoxe.SharpZipLib.GzipHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionBrotliToBytes() =>
        Aoxe.SystemIoCompression.BrotliHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionDeflateToBytes() =>
        Aoxe.SystemIoCompression.DeflateHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionGzipToBytes() =>
        Aoxe.SystemIoCompression.GzipHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void Lz4ToBytes() => Aoxe.LZ4.Lz4Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void LzmaToBytes() => Aoxe.LZMA.LzmaHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SnappyToBytes() => Aoxe.Snappy.SnappyHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void XzToBytes() => Aoxe.XZ.XzHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void ZstdToBytes() => Aoxe.Zstd.ZstdHelper.Compress(Consts.RawBytes);
}
