namespace Zaabee.LZMA;

public sealed class LzmaCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToLzmaAsync(cancellationToken: cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnLzmaAsync(cancellationToken: cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToLzmaAsync(outputStream, cancellationToken: cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnLzmaAsync(outputStream, cancellationToken: cancellationToken);

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