namespace Zaabee.SharpZipLib;

public class GzipCompressor : ICompressor
{
    private readonly bool _isStreamOwner;

    public GzipCompressor(bool isStreamOwner = Bzip2Helper.IsStreamOwner)
    {
        _isStreamOwner = isStreamOwner;
    }

    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToGZipAsync();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnGZipAsync();

    public async Task CompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.ToGZipAsync(outputStream, _isStreamOwner);

    public async Task DecompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.UnGZipAsync(outputStream, _isStreamOwner);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToGZip();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnGZip();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToGZip();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnGZip();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToGZip(outputStream, _isStreamOwner);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnGZip(outputStream, _isStreamOwner);
}