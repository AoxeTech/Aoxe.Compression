namespace Zaabee.Snappy;

public sealed class SnappyCompressor : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToSnappyAsync(cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnSnappyAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToSnappyAsync(outputStream, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnSnappyAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToSnappy();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnSnappy();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToSnappy();

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnSnappy();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToSnappy(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnSnappy(outputStream);
}
