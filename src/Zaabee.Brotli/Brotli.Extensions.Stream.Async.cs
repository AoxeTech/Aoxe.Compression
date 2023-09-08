namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static ValueTask ToBrotliAsync(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        CancellationToken cancellationToken = default) =>
        BrotliHelper.CompressAsync(rawStream, outputStream, quality, window, cancellationToken);

    public static ValueTask UnBrotliAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        BrotliHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToBrotliAsync(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        CancellationToken cancellationToken = default) =>
        BrotliHelper.CompressAsync(rawStream, quality, window, cancellationToken);

    public static ValueTask<MemoryStream> UnBrotliAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        BrotliHelper.DecompressAsync(compressedStream, cancellationToken);
}