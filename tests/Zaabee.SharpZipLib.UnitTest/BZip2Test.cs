namespace Zaabee.SharpZipLib.UnitTest;

public class BZip2Test
{
    [Fact]
    public void BZip2CompressionTest()
    {
        var result = Consts.Data.ToBZip2().UnBZip2();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressionTestAsync()
    {
        var compressStream = await Consts.Data.ToBZip2StreamAsync<MemoryStream>();
        var compressBytes = compressStream.ToArray();
        var decompressStream = await new MemoryStream(compressBytes).UnBZip2StreamAsync<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}