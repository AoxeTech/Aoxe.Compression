namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromStream
{
    private readonly MemoryStream _brotliCompressStream = new();
    private readonly MemoryStream _bzipCompressStream = new();
    private readonly MemoryStream _gzipCompressStream = new();
    private readonly MemoryStream _lz4CompressStream = new();
    private readonly MemoryStream _lzmaCompressStream = new();

    public DecompressFromStream()
    {
        BrotliHelper.Compress(Consts.RawStream, _brotliCompressStream);
        Bzip2Helper.Compress(Consts.RawStream, _bzipCompressStream);
        GzipHelper.Compress(Consts.RawStream, _gzipCompressStream);
        Lz4Helper.Compress(Consts.RawStream, _lz4CompressStream);
        LzmaHelper.Compress(Consts.RawStream, _lzmaCompressStream);
    }

    [Benchmark]
    public void BrotliFromStream() => BrotliHelper.Decompress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Bzip2FromStream() => Bzip2Helper.Decompress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void GzipFromStream() => GzipHelper.Decompress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() => Lz4Helper.Decompress(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void LzmaFromStream() => LzmaHelper.Decompress(Consts.RawStream, new MemoryStream());
}