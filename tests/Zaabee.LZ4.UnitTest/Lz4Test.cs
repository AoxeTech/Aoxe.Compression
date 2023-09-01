namespace Zaabee.LZ4.UnitTest;

public class Lz4Test
{
    [Fact]
    public void Lz4CompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToLz4().UnLz4();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void Lz4CompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToLz4().ToMemoryStream();
        var decompressStream = compressedStream.UnLz4();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToLz4();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnLz4();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void Lz4CompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToLz4();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnLz4();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task Lz4CompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToLz4Async();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnLz4Async();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void Lz4CompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToLz4();
        var result = compressBytes.UnLz4ToString();
        Assert.Equal(TestConsts.Str, result);
    }
}