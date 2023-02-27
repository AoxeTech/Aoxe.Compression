namespace Zaabee.Compressor.UnitTest;

public class LeaveOpenAsyncTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task BrotliIsKeepOpenTestAsync(bool leaveOpen) =>
        await IsKeepOpenTestAsync(new BrotliCompressor(), leaveOpen);

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Lz4IsKeepOpenTestAsync(bool leaveOpen) =>
        await IsKeepOpenTestAsync(new Lz4Compressor(), leaveOpen);

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Bzip2IsKeepOpenTestAsync(bool leaveOpen) =>
        await IsKeepOpenTestAsync(new Bzip2Compressor(), leaveOpen);

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GzipIsKeepOpenTestAsync(bool leaveOpen) =>
        await IsKeepOpenTestAsync(new GzipCompressor(), leaveOpen);

    private async Task IsKeepOpenTestAsync(ICompressor compressor, bool leaveOpen)
    {
        var compressedStream = new MemoryStream();
        await compressor.CompressAsync(new MemoryStream(Consts.Data), compressedStream, leaveOpen);
        Assert.Equal(leaveOpen, compressedStream.CanWrite);
        var decompressedStream = new MemoryStream();
        var reCompressedStream = new MemoryStream(compressedStream.ToArray());
        await compressor.DecompressAsync(reCompressedStream, decompressedStream, leaveOpen);
        Assert.Equal(leaveOpen, reCompressedStream.CanWrite);
        var decompressedBytes = decompressedStream.ToArray();
        Assert.Equal(Consts.Data, decompressedBytes);
    }
}