namespace Zaabee.SharpZipLib;

public class GzipCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToGZipAsync();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnGZipAsync();

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.ToGZipAsync(outputStream);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.UnGZipAsync(outputStream);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToGZip();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnGZip();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToGZip();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnGZip();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToGZip(outputStream);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnGZip(outputStream);
}