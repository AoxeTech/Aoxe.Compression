namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromBytes
{
    private readonly byte[] _bzipCompressBytes;
    private readonly byte[] _gzipCompressBytes;
    private readonly byte[] _lz4CompressBytes;

    public DecompressFromBytes()
    {
        _bzipCompressBytes = SharpZipLibHelper.ToBZip2(Consts.RawBytes);
        _gzipCompressBytes = SharpZipLibHelper.ToGZip(Consts.RawBytes);
        _lz4CompressBytes = Lz4Helper.ToLz4(Consts.RawBytes);
    }

    [Benchmark]
    public void Bzip2FromBytes() => SharpZipLibHelper.UnBZip2(_bzipCompressBytes);

    [Benchmark]
    public void GzipFromBytes() => SharpZipLibHelper.UnGZip(_gzipCompressBytes);

    [Benchmark]
    public void Lz4FromBytes() => Lz4Helper.UnLz4(_lz4CompressBytes);
}