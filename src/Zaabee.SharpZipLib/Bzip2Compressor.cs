namespace Zaabee.SharpZipLib;

public sealed class Bzip2Compressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToBZip2Async(cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnBZip2Async(cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToBZip2Async(outputStream, cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnBZip2Async(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToBZip2();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnBZip2();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToBZip2();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnBZip2();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToBZip2(outputStream);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnBZip2(outputStream);
}