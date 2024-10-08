#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression.UnitTest;

public class ZLibTest
{
    [Fact]
    public void ZLibCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToZLib().UnZLib();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZLibCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToZLib().ToMemoryStream();
        var decompressStream = compressedStream.UnZLib();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZLibCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToZLib();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnZLib();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZLibCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToZLib();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnZLib();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task ZLibCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToZLibAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnZLibAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void ZLibCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToZLib();
        var result = compressBytes.UnZLibToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
#endif
