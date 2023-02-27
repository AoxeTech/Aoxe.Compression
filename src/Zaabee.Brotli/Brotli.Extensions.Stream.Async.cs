namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static async Task ToBrotliAsync(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window) =>
        await BrotliHelper.CompressAsync(rawStream, outputStream, quality, window);

    public static async Task UnBrotliAsync(
        this Stream compressedStream,
        Stream outputStream) =>
        await BrotliHelper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToBrotliAsync(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToBrotliAsync(outputStream, quality, window);
        return outputStream;
    }

    public static async Task<MemoryStream> UnBrotliAsync(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnBrotliAsync(outputStream);
        return outputStream;
    }
}