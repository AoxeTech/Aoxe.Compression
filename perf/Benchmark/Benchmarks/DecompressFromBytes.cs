namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromBytes
{
    private static readonly byte[] BrotliCompressBytes = BrotliHelper.Compress(Consts.RawBytes);
    private static readonly byte[] BzipCompressBytes = Bzip2Helper.Compress(Consts.RawBytes);
    private static readonly byte[] GzipCompressBytes = GzipHelper.Compress(Consts.RawBytes);
    private static readonly byte[] Lz4CompressBytes = Lz4Helper.Compress(Consts.RawBytes);
    private static readonly byte[] LzmaCompressBytes = LzmaHelper.Compress(Consts.RawBytes);
    private static readonly byte[] XzCompressBytes = XzHelper.Compress(Consts.RawBytes);
    private static readonly byte[] ZstdCompressBytes = ZstdHelper.Compress(Consts.RawBytes);

    [Benchmark]
    public void BrotliFromBytes() => BrotliHelper.Decompress(BrotliCompressBytes);

    [Benchmark]
    public void Bzip2FromBytes() => Bzip2Helper.Decompress(BzipCompressBytes);

    [Benchmark]
    public void GzipFromBytes() => GzipHelper.Decompress(GzipCompressBytes);

    [Benchmark]
    public void Lz4FromBytes() => Lz4Helper.Decompress(Lz4CompressBytes);

    [Benchmark]
    public void LzmaFromBytes() => LzmaHelper.Decompress(LzmaCompressBytes);

    [Benchmark]
    public void XzFromBytes() => XzHelper.Decompress(XzCompressBytes);

    [Benchmark]
    public void ZstdFromBytes() => ZstdHelper.Decompress(ZstdCompressBytes);
}