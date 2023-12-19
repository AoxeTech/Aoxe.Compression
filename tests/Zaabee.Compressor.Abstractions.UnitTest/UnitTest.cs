namespace Zaabee.Compressor.Abstractions.UnitTest;

public class UnitTest
{
    [Fact]
    public void CompressBytesTest()
    {
        var compressor = new NullCompressor();
        var compressedBytes = compressor.Compress(TestConsts.Data);
        var decompressedBytes = compressor.Decompress(compressedBytes);
        Assert.Equal(TestConsts.Data, decompressedBytes);
    }

    [Fact]
    public void CompressStringTest()
    {
        var compressor = new NullCompressor();
        var compressedBytes = compressor.Compress(TestConsts.Str);
        var decompressedStr = compressor.DecompressToString(compressedBytes);
        Assert.Equal(TestConsts.Str, decompressedStr);
    }

    [Fact]
    public void CompressStreamTest()
    {
        var compressor = new NullCompressor();
        var ms = new MemoryStream(TestConsts.Data);
        var compressedStream = compressor.Compress(ms);
        var decompressedMemory = compressor.Decompress(compressedStream);
        Assert.Equal(ms.ToArray(), decompressedMemory.ToArray());
    }

    [Fact]
    public void CompressPackToStreamTest()
    {
        var compressor = new NullCompressor();
        var ms = new MemoryStream(TestConsts.Data);
        var compressedStream = new MemoryStream();
        compressor.Compress(ms, compressedStream);
        var decompressedMemory = new MemoryStream();
        compressor.Decompress(compressedStream, decompressedMemory);
        Assert.Equal(ms.ToArray(), decompressedMemory.ToArray());
    }

    [Fact]
    public async Task CompressStreamTestAsync()
    {
        var compressor = new NullCompressor();
        var ms = new MemoryStream(TestConsts.Data);
        var compressedStream = await compressor.CompressAsync(ms);
        var decompressedMemory = await compressor.DecompressAsync(compressedStream);
        Assert.Equal(ms.ToArray(), decompressedMemory.ToArray());
    }

    [Fact]
    public async Task CompressPackToStreamTestAsync()
    {
        var compressor = new NullCompressor();
        var ms = new MemoryStream(TestConsts.Data);
        var compressedStream = new MemoryStream();
        await compressor.CompressAsync(ms, compressedStream);
        var decompressedMemory = new MemoryStream();
        await compressor.DecompressAsync(compressedStream, decompressedMemory);
        Assert.Equal(ms.ToArray(), decompressedMemory.ToArray());
    }
}
