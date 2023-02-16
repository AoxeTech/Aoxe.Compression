namespace Zaabee.SharpZipLib.UnitTest;

public class GZipTest
{
    [Fact]
    public void GZipCompressionTest()
    {
        var result = Consts.Data.ToGZip().UnGZip();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task GZipCompressionTestAsync()
    {
        var compressStream = await Consts.Data.ToGZipStreamAsync<MemoryStream>();
        var compressBytes = compressStream.ToArray();
        var decompressStream = await new MemoryStream(compressBytes).UnGZipStreamAsync<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}