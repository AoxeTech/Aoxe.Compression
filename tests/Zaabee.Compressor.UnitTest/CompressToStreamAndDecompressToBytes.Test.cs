namespace Zaabee.Compressor.UnitTest;

public class CompressToStreamAndDecompressToBytes
{
    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new BrotliCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new GzipCompressor());

    private void CompressToStreamAndDecompressToBytesTest(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        compressor.Compress(new MemoryStream(Consts.Data), compressedStream);
        compressedStream.Position = 0;
        var compressedBytes = compressedStream.ToArray();
        var decompressedBytes = compressor.Decompress(compressedBytes);
        Assert.Equal(Consts.Data, decompressedBytes);
    }
}