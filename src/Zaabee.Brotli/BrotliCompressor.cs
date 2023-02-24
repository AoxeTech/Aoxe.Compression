namespace Zaabee.Brotli;

public class BrotliCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToBrotliAsync();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnBrotliAsync();

    public async Task CompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.ToBrotliAsync(outputStream);

    public async Task DecompressAsync(Stream inputStream, Stream outputStream) =>
        await inputStream.UnBrotliAsync(outputStream);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToBrotli();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToBrotli();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}