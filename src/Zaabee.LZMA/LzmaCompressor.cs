namespace Zaabee.LZMA;

public class LzmaCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToLzmaAsync();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnLzmaAsync();

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.ToLzmaAsync(outputStream);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.UnLzmaAsync(outputStream);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToLzma();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnLzma();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToLzma();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnLzma();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToLzma(outputStream);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnLzma(outputStream);
}