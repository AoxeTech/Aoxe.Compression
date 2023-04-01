namespace Zaabee.Compressor.UnitTest;

public class CompressToStreamAndDecompressToStream
{
    [Fact]
    public void NullCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new NullCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new BrotliCompressor());

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new LzmaCompressor());

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
    public void ZstdCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new ZstdCompressor());

    [Fact]
    public void XzCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new XzCompressor());

    [Fact]
    public void NullCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new NullCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new BrotliCompressor());

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new GzipCompressor());

    [Fact]
    public void ZstdCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new ZstdCompressor());

    [Fact]
    public void XzCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new XzCompressor());

    private void CompressToStreamAndDecompressToStreamTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        var rawStream = Consts.Data.ToMemoryStream();
        compressor.Compress(rawStream, compressedStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = new MemoryStream();
        compressedStream = new MemoryStream(compressedStream.ToArray());
        compressor.Decompress(compressedStream, decompressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(Consts.Data, decompressedBytes);
    }

    private void CompressToStreamAndDecompressToStreamTest2(ICompressor compressor)
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressedStream = compressor.Compress(rawStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = compressor.Decompress(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(Consts.Data, decompressedBytes);
    }
}