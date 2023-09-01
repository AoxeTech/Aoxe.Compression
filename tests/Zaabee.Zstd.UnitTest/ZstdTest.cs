namespace Zaabee.Zstd.UnitTest;

public class ZstdTest
{
    [Fact]
    public void ZstdCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToZstd().UnZstd();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZstdCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToZstd().ToMemoryStream();
        var decompressStream = compressedStream.UnZstd();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZstdCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToZstd();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnZstd();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZstdCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToZstd();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnZstd();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task ZstdCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToZstdAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnZstdAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZstdCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToZstd();
        var result = compressBytes.UnZstdToString();
        Assert.Equal(TestConsts.Str, result);
    }
}