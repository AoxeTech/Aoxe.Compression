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
        var compressedStream = Consts.Data.ToBrotli().ToMemoryStream();
        var decompressStream = compressedStream.UnBrotli();

        Assert.Equal(0, decompressStream.Position);
        
        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToBrotli();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnBrotli();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToBrotli();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnBrotli();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToBrotliAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnBrotliAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}