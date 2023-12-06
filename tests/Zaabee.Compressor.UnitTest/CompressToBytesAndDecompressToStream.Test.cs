namespace Zaabee.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public void NullCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new NullCompressor());

    [Fact]
    public void BrotliCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SystemIoCompression.GzipCompressor());

    [Fact]
    public void ZstdCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new ZstdCompressor());

    [Fact]
    public void XzCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new XzCompressor());

    [Fact]
    public void SnappyCompressToBytesAndDecompressToStreamTest() =>
        CompressToBytesAndDecompressToStreamTest(new SnappyCompressor());

    private void CompressToBytesAndDecompressToStreamTest(ICompressor compressor)
    {
        var compressedBytes = compressor.Compress(TestConsts.Data);
        var compressedStream = compressedBytes.ToMemoryStream();
        var decompressedStream = compressor.Decompress(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }
}
