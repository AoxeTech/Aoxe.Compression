namespace Zaabee.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public void NullCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new NullCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SystemIoCompression.GzipCompressor());

    [Fact]
    public void ZstdCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new ZstdCompressor());

    [Fact]
    public void XzCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new XzCompressor());

    [Fact]
    public void SnappyCompressToStreamAndDecompressToBytesTest() =>
        CompressToStreamAndDecompressToBytesTest(new SnappyCompressor());

    private void CompressToStreamAndDecompressToBytesTest(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        var rawStream = TestConsts.Data.ToMemoryStream();
        compressor.Compress(rawStream, compressedStream);

        Assert.Equal(0, rawStream.Position);

        var compressedBytes = compressedStream.ToArray();
        var decompressedBytes = compressor.Decompress(compressedBytes);

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }
}
