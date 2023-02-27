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
        var result = Consts.Data.ToGZip().ToMemoryStream().UnGZip().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToMemoryStream().ToGZip().ToArray().UnGZip();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = Consts.Data.ToMemoryStream().ToGZip();
        var decompressStream = compressStream.UnGZip();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task GZipCompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await Consts.Data.ToMemoryStream().ToGZipAsync();
        var decompressStream = await compressStream.UnGZipAsync();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}