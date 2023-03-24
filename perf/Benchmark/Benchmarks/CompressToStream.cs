namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToStream
{
    [Benchmark]
    public void BrotliToStream() => BrotliHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Bzip2ToStream() => Bzip2Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void GzipToStream() => GzipHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4ToStream() => Lz4Helper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void LzmaToStream() => LzmaHelper.Compress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void ZstdToStream() => ZstdHelper.Compress(Consts.RawStream, new MemoryStream());
}