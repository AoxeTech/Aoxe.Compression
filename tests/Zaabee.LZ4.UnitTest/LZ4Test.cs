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
        var result = new MemoryStream(Consts.Data.ToLz4()).UnLz4<MemoryStream>().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToLz4<MemoryStream>().ToArray().UnLz4();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToLz4<MemoryStream>();
        var decompressStream = compressStream.UnLz4<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToLz4Async<MemoryStream>();
        var decompressStream = await compressStream.UnLz4Async<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}