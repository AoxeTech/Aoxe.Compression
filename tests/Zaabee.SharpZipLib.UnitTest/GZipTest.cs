namespace Zaabee.SharpZipLib.UnitTest;

public class GZipTest
{
    [Fact]
    public void GZipCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToGZip().UnGZip();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = Consts.Data.ToGZip().ToMemoryStream();
        var decompressStream = compressedStream.UnGZip();

        Assert.Equal(0, decompressStream.Position);
        
        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToGZip();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnGZip();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToGZip();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnGZip();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task GZipCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToGZipAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnGZipAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}