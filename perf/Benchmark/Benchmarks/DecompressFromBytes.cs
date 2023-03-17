namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromBytes
{
    private readonly byte[] _brotliCompressBytes = BrotliHelper.Compress(Consts.RawBytes);
    private readonly byte[] _bzipCompressBytes = Bzip2Helper.Compress(Consts.RawBytes);
    private readonly byte[] _gzipCompressBytes = GzipHelper.Compress(Consts.RawBytes);
    private readonly byte[] _lz4CompressBytes = Lz4Helper.Compress(Consts.RawBytes);
    private readonly byte[] _lzmaCompressBytes = LzmaHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void BrotliFromBytes() => BrotliHelper.Decompress(_brotliCompressBytes);

    [Benchmark]
    public void Bzip2FromBytes() => Bzip2Helper.Decompress(_bzipCompressBytes);

    [Benchmark]
    public void GzipFromBytes() => GzipHelper.Decompress(_gzipCompressBytes);

    [Benchmark]
    public void Lz4FromBytes() => Lz4Helper.Decompress(_lz4CompressBytes);

    [Benchmark]
    public void LzmaFromBytes() => LzmaHelper.Decompress(_lzmaCompressBytes);
}