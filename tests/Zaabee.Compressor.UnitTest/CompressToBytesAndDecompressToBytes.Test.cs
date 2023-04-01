namespace Zaabee.Compressor.UnitTest;

public class BytesTest
{
    [Fact]
    public void NullCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new NullCompressor());

    [Fact]
    public void BrotliCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new BrotliCompressor());

    [Fact]
    public void LzmaCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new Bzip2Compressor());

    [Fact]
    public void GzipCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new GzipCompressor());

    [Fact]
    public void ZstdCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new ZstdCompressor());

    [Fact]
    public void XzCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new XzCompressor());

    private void CompressToBytesAndDecompressToBytesTest(ICompressor compressor)
    {
        var compressedBytes = compressor.Compress(Consts.Data);
        var decompressedBytes = compressor.Decompress(compressedBytes);

        Assert.Equal(Consts.Data, decompressedBytes);
    }
}