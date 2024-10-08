#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public sealed class ZLibCompressor(CompressionLevel compressionLevel = CompressionLevel.Optimal)
    : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToZLibAsync(compressionLevel, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnZLibAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToZLibAsync(outputStream, compressionLevel, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnZLibAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToZLib(compressionLevel);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnZLib();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToZLib(compressionLevel);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnZLib();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToZLib(outputStream, compressionLevel);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnZLib(outputStream);
}
#endif
