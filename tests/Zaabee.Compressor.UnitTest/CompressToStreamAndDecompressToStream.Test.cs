namespace Zaabee.Compressor.UnitTest;

public class CompressToStreamAndDecompressToStream
{
    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new BrotliCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new GzipCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new BrotliCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new GzipCompressor());

    private void CompressToStreamAndDecompressToStreamTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        compressor.Compress(new MemoryStream(Consts.Data), compressedStream);
        compressedStream.Position = 0;
        var decompressedStream = new MemoryStream();
        compressor.Decompress(compressedStream, decompressedStream);
        var decompressedBytes = decompressedStream.ToArray();
        Assert.Equal(Consts.Data, decompressedBytes);
    }

    private void CompressToStreamAndDecompressToStreamTest2(ICompressor compressor)
    {
        var compressedStream = compressor.Compress(new MemoryStream(Consts.Data));
        var decompressedStream = compressor.Decompress(compressedStream);
        var decompressedBytes = decompressedStream.ToArray();
        Assert.Equal(Consts.Data, decompressedBytes);
    }
}