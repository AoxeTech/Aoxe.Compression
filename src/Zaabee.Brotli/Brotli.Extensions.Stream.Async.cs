namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static async Task ToBrotliAsync(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        bool leaveOpen = BrotliHelper.LeaveOpen) =>
        await BrotliHelper.CompressAsync(rawStream, outputStream, quality, window, leaveOpen);

    public static async Task UnBrotliAsync(
        this Stream compressedStream,
        Stream outputStream,
        bool leaveOpen = BrotliHelper.LeaveOpen) =>
        await BrotliHelper.DecompressAsync(compressedStream, outputStream, leaveOpen);

    public static async Task<MemoryStream> ToBrotliAsync(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToBrotliAsync(outputStream, quality, window, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnBrotliAsync(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnBrotliAsync(outputStream, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}