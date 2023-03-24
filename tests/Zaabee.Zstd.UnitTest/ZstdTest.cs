namespace Zaabee.Zstd.UnitTest;

public class ZstdTest
{
    [Fact]
    public void ZstdCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToZstd().UnZstd();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void ZstdCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = Consts.Data.ToZstd().ToMemoryStream();
        var decompressStream = compressedStream.UnZstd();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void ZstdCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToZstd();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnZstd();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void ZstdCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToZstd();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnZstd();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task ZstdCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToZstdAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnZstdAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}