namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToStream
{
    [Benchmark]
    public void BrotliToStream() => Zaabee.Brotli.BrotliHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibBzip2ToStream() => Zaabee.SharpZipLib.Bzip2Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibDeflateToStream() => Zaabee.SharpZipLib.DeflateHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SharpZipLibGzipToStream() => Zaabee.SharpZipLib.GzipHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionBrotliToStream() => Zaabee.SystemIoCompression.BrotliHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionDeflateToStream() => Zaabee.SystemIoCompression.DeflateHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SystemIoCompressionToStream() => Zaabee.SystemIoCompression.GzipHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4ToStream() => Zaabee.LZ4.Lz4Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void LzmaToStream() => Zaabee.LZMA.LzmaHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void SnappyToStream() => Zaabee.Snappy.SnappyHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void XzToStream() => Zaabee.XZ.XzHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void ZstdToStream() => Zaabee.Zstd.ZstdHelper.Compress(Consts.RawStream, new MemoryStream());
}
