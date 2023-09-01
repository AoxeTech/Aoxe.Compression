namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromStream
{
    private static readonly MemoryStream BrotliCompressStream = BrotliHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream BzipCompressStream = Bzip2Helper.Compress(Consts.RawStream);
    private static readonly MemoryStream GzipCompressStream = GzipHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream Lz4CompressStream = Lz4Helper.Compress(Consts.RawStream);
    private static readonly MemoryStream LzmaCompressStream = LzmaHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream XzCompressStream = XzHelper.Compress(Consts.RawStream);
    private static readonly MemoryStream ZstdCompressStream = ZstdHelper.Compress(Consts.RawStream);

    [Benchmark]
    public void BrotliFromStream() => BrotliHelper.Decompress(BrotliCompressStream, new MemoryStream());

    [Benchmark]
    public void Bzip2FromStream() => Bzip2Helper.Decompress(BzipCompressStream, new MemoryStream());

    [Benchmark]
    public void GzipFromStream() => GzipHelper.Decompress(GzipCompressStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() => Lz4Helper.Decompress(Lz4CompressStream, new MemoryStream());

    [Benchmark]
    public void LzmaFromStream() => LzmaHelper.Decompress(LzmaCompressStream, new MemoryStream());

    [Benchmark]
    public void SnappyFromStream() => SnappyHelper.Decompress(XzCompressStream, new MemoryStream());

    [Benchmark]
    public void XzFromStream() => XzHelper.Decompress(XzCompressStream, new MemoryStream());

    [Benchmark]
    public void ZstdFromStream() => ZstdHelper.Decompress(ZstdCompressStream, new MemoryStream());
}