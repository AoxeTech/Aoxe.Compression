namespace Zaabee.Compressor.UnitTest;

public class CompressToStreamAndDecompressToStreamAsync
{
    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new BrotliCompressor());

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new LzmaCompressor());

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
    public async Task ZstdCompressToStreamAndDecompressToStreamAsyncTest1() =>
        await CompressToStreamAndDecompressToStreamAsyncTest1(new ZstdCompressor());

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new BrotliCompressor());

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new LzmaCompressor());

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Lz4Compressor());

    [Fact]
    public async Task Bzip2CompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new Bzip2Compressor());

    [Fact]
    public async Task GzipCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new GzipCompressor());

    [Fact]
    public async Task ZstdCompressToStreamAndDecompressToStreamAsyncTest2() =>
        await CompressToStreamAndDecompressToStreamAsyncTest2(new ZstdCompressor());

    private async Task CompressToStreamAndDecompressToStreamAsyncTest1(ICompressor compressor)
    {
        var compressedStream = new MemoryStream();
        var rawStream = Consts.Data.ToMemoryStream();
        await compressor.CompressAsync(rawStream, compressedStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = new MemoryStream();
        compressedStream = new MemoryStream(compressedStream.ToArray());
        await compressor.DecompressAsync(compressedStream, decompressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(Consts.Data, decompressedBytes);
    }

    private async Task CompressToStreamAndDecompressToStreamAsyncTest2(ICompressor compressor)
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressedStream = await compressor.CompressAsync(rawStream);

        Assert.Equal(0, rawStream.Position);

        var decompressedStream = await compressor.DecompressAsync(compressedStream);

        Assert.Equal(0, compressedStream.Position);

        var decompressedBytes = decompressedStream.ToArray();

        Assert.Equal(Consts.Data, decompressedBytes);
    }
}