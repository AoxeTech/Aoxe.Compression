namespace Aoxe.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public void NullCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new NullCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SystemIoCompression.GzipCompressor());

#if NET6_0_OR_GREATER
    [Fact]
    public void SystemIoCompressionZLibCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SystemIoCompression.ZLibCompressor());
#endif

    [Fact]
    public void ZstdCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new ZstdCompressor());

    [Fact]
    public void XzCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new XzCompressor());

    [Fact]
    public void SnappyCompressToStreamAndDecompressToStreamTest1() =>
        CompressToStreamAndDecompressToStreamTest1(new SnappyCompressor());

    [Fact]
    public void NullCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new NullCompressor());

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Brotli.BrotliCompressor());

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new LzmaCompressor());

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Lz4Compressor());

    [Fact]
    public void SharpZipLibBzip2CompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new Bzip2Compressor());

    [Fact]
    public void SharpZipLibDeflateCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SharpZipLib.DeflateCompressor());

    [Fact]
    public void SharpZipLibGzipCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public void SystemIoCompressionBrotliCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SystemIoCompression.BrotliCompressor());
#endif

    [Fact]
    public void SystemIoCompressionDeflateCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SystemIoCompression.DeflateCompressor());

    [Fact]
    public void SystemIoCompressionGzipCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SystemIoCompression.GzipCompressor());

#if NET6_0_OR_GREATER
    [Fact]
    public void SystemIoCompressionZLibCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SystemIoCompression.ZLibCompressor());
#endif

    [Fact]
    public void ZstdCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new ZstdCompressor());

    [Fact]
    public void XzCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new XzCompressor());

    [Fact]
    public void SnappyCompressToStreamAndDecompressToStreamTest2() =>
        CompressToStreamAndDecompressToStreamTest2(new SnappyCompressor());

    private void CompressToStreamAndDecompressToStreamTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        var rawStream = TestConsts.Data.ToMemoryStream();
        compressor.Compress(rawStream, compressedStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = new MemoryStream();
        compressedStream = new MemoryStream(compressedStream.ToArray());
        compressor.Decompress(compressedStream, decompressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }

    private void CompressToStreamAndDecompressToStreamTest2(ICompressor compressor)
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressedStream = compressor.Compress(rawStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = compressor.Decompress(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }
}
