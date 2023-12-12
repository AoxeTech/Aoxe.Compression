namespace Zaabee.Brotli;

public sealed class BrotliCompressor(
    uint quality = BrotliHelper.Quality,
    uint window = BrotliHelper.Window)
    : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToBrotliAsync(quality, window, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnBrotliAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToBrotliAsync(outputStream, quality, window, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnBrotliAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToBrotli(quality, window);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToBrotli(quality, window);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream, quality, window);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}