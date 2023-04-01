namespace Zaabee.Compressor.UnitTest;

public class StreamTest
{
    [Fact]
    public void NullCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new NullCompressor());

    [Fact]
    public void BrotliCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new BrotliCompressor());

    [Fact]
    public void LzmaCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new GzipCompressor());

    [Fact]
    public void ZstdCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new ZstdCompressor());

    [Fact]
    public void XzCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new XzCompressor());

    private void CompressToBytesAndDecompressToStreamTest(ICompressor compressor)
    {
        var compressedBytes = compressor.Compress(Consts.Data);
        var compressedStream = compressedBytes.ToMemoryStream();
        var decompressedStream = compressor.Decompress(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(Consts.Data, decompressedBytes);
    }
}