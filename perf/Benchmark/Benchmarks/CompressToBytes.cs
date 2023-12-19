namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToBytes
{
    [Benchmark]
    public void BrotliToBytes() => Zaabee.Brotli.BrotliHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibBzip2ToBytes() =>
        Zaabee.SharpZipLib.Bzip2Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibDeflateToBytes() =>
        Zaabee.SharpZipLib.DeflateHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SharpZipLibGzipToBytes() => Zaabee.SharpZipLib.GzipHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionBrotliToBytes() =>
        Zaabee.SystemIoCompression.BrotliHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionDeflateToBytes() =>
        Zaabee.SystemIoCompression.DeflateHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SystemIoCompressionGzipToBytes() =>
        Zaabee.SystemIoCompression.GzipHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void Lz4ToBytes() => Zaabee.LZ4.Lz4Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void LzmaToBytes() => Zaabee.LZMA.LzmaHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void SnappyToBytes() => Zaabee.Snappy.SnappyHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void XzToBytes() => Zaabee.XZ.XzHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void ZstdToBytes() => Zaabee.Zstd.ZstdHelper.Compress(Consts.RawBytes);
}
