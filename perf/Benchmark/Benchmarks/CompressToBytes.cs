namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToBytes
{
    [Benchmark]
    public void Bzip2ToBytes() => SharpZipLibHelper.ToBZip2(Consts.RawBytes);

    [Benchmark]
    public void GzipToBytes() => SharpZipLibHelper.ToGZip(Consts.RawBytes);

    [Benchmark]
    public void Lz4ToBytes() => Lz4Helper.ToLz4(Consts.RawBytes);
}