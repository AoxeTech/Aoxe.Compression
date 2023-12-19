namespace Zaabee.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public void NullCompressAndDecompressString() =>
        CompressAndDecompressString(new NullCompressor());

    [Fact]
    public void BrotliCompressAndDecompressString() =>
        CompressAndDecompressString(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressAndDecompressString() =>
        CompressAndDecompressString(new LzmaCompressor());

    [Fact]
    public void Lz4CompressAndDecompressString() =>
        CompressAndDecompressString(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressAndDecompressString() =>
        CompressAndDecompressString(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressAndDecompressString() =>
        CompressAndDecompressString(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressAndDecompressString() =>
        CompressAndDecompressString(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressAndDecompressString() =>
        CompressAndDecompressString(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressAndDecompressString() =>
        CompressAndDecompressString(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressAndDecompressString() =>
        CompressAndDecompressString(new SystemIoCompression.GzipCompressor());

    [Fact]
    public void ZstdCompressAndDecompressString() =>
        CompressAndDecompressString(new ZstdCompressor());

    [Fact]
    public void XzCompressAndDecompressString() => CompressAndDecompressString(new XzCompressor());

    [Fact]
    public void SnappyCompressAndDecompressString() =>
        CompressAndDecompressString(new SnappyCompressor());

    [Fact]
    public void SystemIoCompressionGZipCompressAndDecompressString() =>
        CompressAndDecompressString(new SystemIoCompression.GzipCompressor());

    private void CompressAndDecompressString(ICompressor compressor)
    {
        const string str = "Hello World!";
        var compressed = compressor.Compress(str);
        var decompressedString = compressor.DecompressToString(compressed);

        Assert.Equal(str, decompressedString);
    }
}
