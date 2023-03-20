namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static async Task ToBrotliAsync(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        CancellationToken cancellationToken = default) =>
        await BrotliHelper.CompressAsync(rawStream, outputStream, quality, window, cancellationToken);

    public static async Task UnBrotliAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await BrotliHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToBrotliAsync(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        CancellationToken cancellationToken = default) =>
        await BrotliHelper.CompressAsync(rawStream, quality, window, cancellationToken);

    public static async Task<MemoryStream> UnBrotliAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await BrotliHelper.DecompressAsync(compressedStream, cancellationToken);
}