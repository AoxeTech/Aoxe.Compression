namespace Zaabee.LZ4.UnitTest;

public class Lz4Test
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
        var compressedStream = Consts.Data.ToLz4().ToMemoryStream();
        var decompressStream = compressedStream.UnLz4();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToLz4();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnLz4();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToLz4();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnLz4();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToLz4Async();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnLz4Async();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}