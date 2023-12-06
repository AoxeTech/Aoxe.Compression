#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public sealed class BrotliCompressor : ICompressor
{
    private readonly CompressionLevel _compressionLevel;

    public BrotliCompressor(CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        _compressionLevel = compressionLevel;
    }

    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToBrotliAsync(_compressionLevel, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnBrotliAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToBrotliAsync(outputStream, _compressionLevel, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnBrotliAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToBrotli(_compressionLevel);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToBrotli(_compressionLevel);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream, _compressionLevel);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}
#endif