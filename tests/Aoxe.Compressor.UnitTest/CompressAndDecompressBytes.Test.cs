namespace Aoxe.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public void NullCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new NullCompressor());

    [Fact]
    public void BrotliCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SharpZipLib.GzipCompressor());

    [Fact]
    public void ZstdCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new ZstdCompressor());

    [Fact]
    public void XzCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new XzCompressor());

    [Fact]
    public void SnappyCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SnappyCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressToBytesAndDecompressToBytesTest() =>
        CompressToBytesAndDecompressToBytesTest(new SystemIoCompression.GzipCompressor());

    private void CompressToBytesAndDecompressToBytesTest(ICompressor compressor)
    {
        var compressedBytes = compressor.Compress(TestConsts.Data);
        var decompressedBytes = compressor.Decompress(compressedBytes);

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }
}
