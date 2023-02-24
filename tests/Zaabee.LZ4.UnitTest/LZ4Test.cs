namespace Zaabee.LZ4.UnitTest;

public class BytesTest
{
    [Fact]
    public void Lz4CompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToLz4().UnLz4();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToBytesAndDecompressToStreamTest()
    {
        var result = new MemoryStream(Consts.Data.ToLz4()).UnLz4().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToLz4().ToArray().UnLz4();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToLz4();
        var decompressStream = compressStream.UnLz4();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToLz4Async();
        var decompressStream = await compressStream.UnLz4Async();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}