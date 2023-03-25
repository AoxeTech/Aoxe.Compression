namespace Zaabee.XZ.UnitTest;

public class XzTest
{
    [Fact]
    public void XzCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToXz().UnXz();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void XzCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = Consts.Data.ToXz().ToMemoryStream();
        var decompressStream = compressedStream.UnXz();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void XzCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToXz();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnXz();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void XzCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToXz();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnXz();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task XzCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToXzAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnXzAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}