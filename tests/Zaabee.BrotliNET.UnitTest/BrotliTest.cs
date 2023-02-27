namespace Zaabee.BrotliNET.UnitTest;

public class BrotliTest
{
    [Fact]
    public void BrotliCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToBrotli().UnBrotli();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToBytesAndDecompressToStreamTest()
    {
        var result = Consts.Data.ToBrotli().ToMemoryStream().UnBrotli().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToMemoryStream().ToBrotli().ToArray().UnBrotli();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = Consts.Data.ToMemoryStream().ToBrotli();
        var decompressStream = compressStream.UnBrotli();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await Consts.Data.ToMemoryStream().ToBrotliAsync();
        var decompressStream = await compressStream.UnBrotliAsync();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}