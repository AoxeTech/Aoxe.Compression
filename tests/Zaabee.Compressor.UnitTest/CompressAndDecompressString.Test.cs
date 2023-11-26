namespace Zaabee.Compressor.UnitTest;

public class StringTest
{
    [Fact]
    public void NullCompressAndDecompressString() =>
        CompressAndDecompressString(new NullCompressor());

    [Fact]
    public void BrotliCompressAndDecompressString() =>
        CompressAndDecompressString(new BrotliCompressor());

    [Fact]
    public void LzmaCompressAndDecompressString() =>
        CompressAndDecompressString(new LzmaCompressor());

    [Fact]
    public void Lz4CompressAndDecompressString() =>
        CompressAndDecompressString(new Lz4Compressor());

    [Fact]
    public void Bzip2CompressAndDecompressString() =>
        CompressAndDecompressString(new Bzip2Compressor());

    [Fact]
    public void GzipCompressAndDecompressString() =>
        CompressAndDecompressString(new GzipCompressor());

    [Fact]
    public void ZstdCompressAndDecompressString() =>
        CompressAndDecompressString(new ZstdCompressor());

    [Fact]
    public void XzCompressAndDecompressString() => CompressAndDecompressString(new XzCompressor());

    [Fact]
    public void SnappyCompressAndDecompressString() =>
        CompressAndDecompressString(new SnappyCompressor());

    private void CompressAndDecompressString(ICompressor compressor)
    {
        const string str = "Hello World!";
        var compressed = compressor.Compress(str);
        var decompressedString = compressor.DecompressToString(compressed);

        Assert.Equal(str, decompressedString);
    }
}
