namespace Zaabee.Compressor.UnitTest;

public class CompressToStreamAndDecompressToStreamAsync
{
    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new BrotliCompressor());

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new Lz4Compressor());

    [Fact]
    public async Task Bzip2CompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new Bzip2Compressor());

    [Fact]
    public async Task GzipCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new GzipCompressor());

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new BrotliCompressor());

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Lz4Compressor());

    [Fact]
    public async Task Bzip2CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Bzip2Compressor());

    [Fact]
    public async Task GzipCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new GzipCompressor());

    private async Task CompressToStreamAndDecompressToStreamAsyncTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        await compressor.CompressAsync(new MemoryStream(Consts.Data), compressedStream);
        var decompressedStream = new MemoryStream();
        compressedStream = new MemoryStream(compressedStream.ToArray());
        await compressor.DecompressAsync(compressedStream, decompressedStream);
        var decompressedBytes = decompressedStream.ToArray();
        Assert.Equal(Consts.Data, decompressedBytes);
    }

    private async Task CompressToStreamAndDecompressToStreamAsyncTest2(ICompressor compressor)
    {
        var compressedStream = await compressor.CompressAsync(new MemoryStream(Consts.Data));
        var decompressedStream = await compressor.DecompressAsync(compressedStream);
        var decompressedBytes = decompressedStream.ToArray();
        Assert.Equal(Consts.Data, decompressedBytes);
    }
}