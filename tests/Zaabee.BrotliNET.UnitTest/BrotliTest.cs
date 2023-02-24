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
        var result = new MemoryStream(Consts.Data.ToBrotli()).UnBrotli().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToBrotli().ToArray().UnBrotli();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToBrotli();
        var decompressStream = compressStream.UnBrotli();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToBrotliAsync();
        var decompressStream = await compressStream.UnBrotliAsync();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}