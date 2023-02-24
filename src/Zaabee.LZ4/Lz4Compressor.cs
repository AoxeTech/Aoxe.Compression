namespace Zaabee.LZ4;

public class Lz4Compressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToLz4Async();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnLz4Async();

    public async Task CompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.ToLz4Async(outputStream);

    public async Task DecompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.UnLz4Async(outputStream);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToLz4();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnLz4();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToLz4();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnLz4();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToLz4(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnLz4(outputStream);
}