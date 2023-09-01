namespace Zaabee.Snappy;

public class SnappyCompressor : ICompressor
{
    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToSnappyAsync(cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnSnappyAsync(cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToSnappyAsync(outputStream, cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnSnappyAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToSnappy();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnSnappy();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToSnappy();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnSnappy();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToSnappy(outputStream);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnSnappy(outputStream);
}