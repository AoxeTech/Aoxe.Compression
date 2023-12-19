namespace Zaabee.Compressor.UnitTest;

public partial class CompressorTest
{
    [Fact]
    public async Task NullCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new NullCompressor());

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new Brotli.BrotliCompressor());

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new LzmaCompressor());

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new Lz4Compressor());

    [Fact]
    public async Task SharpZipLibBzip2CompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new Bzip2Compressor());

    [Fact]
    public async Task SharpZipLibDeflateCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new SharpZipLib.DeflateCompressor());

    [Fact]
    public async Task SharpZipLibGzipCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public async Task SystemIoCompressionBrotliCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(
            new SystemIoCompression.BrotliCompressor()
        );
#endif

    [Fact]
    public async Task SystemIoCompressionDeflateCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(
            new SystemIoCompression.DeflateCompressor()
        );

    [Fact]
    public async Task SystemIoCompressionGzipCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(
            new SystemIoCompression.GzipCompressor()
        );

    [Fact]
    public async Task ZstdCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new ZstdCompressor());

    [Fact]
    public async Task XzCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new XzCompressor());

    [Fact]
    public async Task SnappyCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new SnappyCompressor());

    [Fact]
    public async Task NullCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new NullCompressor());

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Brotli.BrotliCompressor());

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new LzmaCompressor());

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Lz4Compressor());

    [Fact]
    public async Task SharpZipLibBzip2CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Bzip2Compressor());

    [Fact]
    public async Task SharpZipLibDeflateCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new SharpZipLib.DeflateCompressor());

    [Fact]
    public async Task SharpZipLibGzipCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new SharpZipLib.GzipCompressor());

#if !NET48
    [Fact]
    public async Task SystemIoCompressionBrotliCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(
            new SystemIoCompression.BrotliCompressor()
        );
#endif

    [Fact]
    public async Task SystemIoCompressionDeflateCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(
            new SystemIoCompression.DeflateCompressor()
        );

    [Fact]
    public async Task SystemIoCompressionGzipCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(
            new SystemIoCompression.GzipCompressor()
        );

    [Fact]
    public async Task ZstdCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new ZstdCompressor());

    [Fact]
    public async Task XzCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new XzCompressor());

    [Fact]
    public async Task SnappyCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new SnappyCompressor());

    private async ValueTask CompressToStreamAndDecompressToStreamAsyncTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        var rawStream = TestConsts.Data.ToMemoryStream();
        await compressor.CompressAsync(rawStream, compressedStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = new MemoryStream();
        compressedStream = new MemoryStream(compressedStream.ToArray());
        await compressor.DecompressAsync(compressedStream, decompressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }

    private async ValueTask CompressToStreamAndDecompressToStreamAsyncTest2(ICompressor compressor)
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressedStream = await compressor.CompressAsync(rawStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = await compressor.DecompressAsync(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(TestConsts.Data, decompressedBytes);
    }
}
