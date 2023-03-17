namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DecompressFromStream
{
    private readonly MemoryStream _brotliCompressStream = BrotliHelper.Compress(Consts.RawStream);
    private readonly MemoryStream _bzipCompressStream = Bzip2Helper.Compress(Consts.RawStream);
    private readonly MemoryStream _gzipCompressStream = GzipHelper.Compress(Consts.RawStream);
    private readonly MemoryStream _lz4CompressStream = Lz4Helper.Compress(Consts.RawStream);
    private readonly MemoryStream _lzmaCompressStream = LzmaHelper.Compress(Consts.RawStream);

    [Benchmark]
    public void BrotliFromStream() => BrotliHelper.Decompress(_brotliCompressStream, new MemoryStream());

    [Benchmark]
    public void Bzip2FromStream() => Bzip2Helper.Decompress(_bzipCompressStream, new MemoryStream());

    [Benchmark]
    public void GzipFromStream() => GzipHelper.Decompress(_gzipCompressStream, new MemoryStream());

    [Benchmark]
    public void Lz4FromStream() => Lz4Helper.Decompress(_lz4CompressStream, new MemoryStream());

    [Benchmark]
    public void LzmaFromStream() => LzmaHelper.Decompress(_lzmaCompressStream, new MemoryStream());
}