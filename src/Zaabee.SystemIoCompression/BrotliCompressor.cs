#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public sealed class BrotliCompressor(CompressionLevel compressionLevel = CompressionLevel.Optimal) : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToBrotliAsync(compressionLevel, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnBrotliAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToBrotliAsync(outputStream, compressionLevel, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnBrotliAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToBrotli(compressionLevel);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToBrotli(compressionLevel);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream, compressionLevel);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}
#endif