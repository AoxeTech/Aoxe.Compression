namespace Zaabee.SharpZipLib;

public sealed class GzipCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToGZipAsync(cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnGZipAsync(cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToGZipAsync(outputStream, cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnGZipAsync(outputStream, cancellationToken);

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