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

    public DecompressFromStream()
    {
        BrotliHelper.ToBrotli(Consts.RawStream, _brotliCompressStream);
        SharpZipLibHelper.ToBZip2(Consts.RawStream, _bzipCompressStream);
        SharpZipLibHelper.ToGZip(Consts.RawStream, _gzipCompressStream);
        Lz4Helper.ToLz4(Consts.RawStream, _lz4CompressStream);
    }

    [Benchmark]
    public void BrotliFromStream() => BrotliHelper.UnBrotli(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Bzip2FromStream() => SharpZipLibHelper.UnBZip2(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void GzipFromStream() => SharpZipLibHelper.UnGZip(Consts.RawStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() => Lz4Helper.UnLz4(Consts.RawStream, new MemoryStream());
}