namespace Zaabee.LZ4.UnitTest;

public class BytesTest
{
    [Fact]
    public void CompressAndDecompressBytesToBytesTest()
    {
        var compressBytes = Lz4Helper.ToLz4(Consts.Data);
        var uncompressBytes = Lz4Helper.UnLz4(compressBytes);
        Assert.Equal(Consts.Data, uncompressBytes);
    }
}