namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class CompressToBytes
{
    [Benchmark]
    public void BrotliToBytes() => BrotliHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void Bzip2ToBytes() => Bzip2Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void GzipToBytes() => GzipHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void Lz4ToBytes() => Lz4Helper.Compress(Consts.RawBytes);

    [Benchmark]
    public void LzmaToBytes() => LzmaHelper.Compress(Consts.RawBytes);
}