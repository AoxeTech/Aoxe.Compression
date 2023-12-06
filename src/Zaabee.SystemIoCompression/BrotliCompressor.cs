#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public sealed class BrotliCompressor : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToBrotliAsync(cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnBrotliAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToBrotliAsync(outputStream, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnBrotliAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToBrotli();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToBrotli();

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}
#endif