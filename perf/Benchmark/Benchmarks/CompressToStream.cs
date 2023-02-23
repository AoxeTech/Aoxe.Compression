namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToStream
{
    [Benchmark]
    public void BrotliToStream() => BrotliHelper.ToBrotli(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Bzip2ToStream() => SharpZipLibHelper.ToBZip2(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void GzipToStream() => SharpZipLibHelper.ToGZip(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4ToStream() => Lz4Helper.ToLz4(Consts.RawStream, new MemoryStream());
}