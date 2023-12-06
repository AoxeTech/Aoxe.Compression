namespace Zaabee.SystemIoCompression;

public sealed class GzipCompressor : ICompressor
{
    private readonly CompressionLevel _compressionLevel;

    public GzipCompressor(CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        _compressionLevel = compressionLevel;
    }

    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToGZipAsync(_compressionLevel, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnGZipAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToGZipAsync(outputStream, _compressionLevel, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnGZipAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToGZip(_compressionLevel);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnGZip();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToGZip(_compressionLevel);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnGZip();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToGZip(outputStream, _compressionLevel);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnGZip(outputStream);
}