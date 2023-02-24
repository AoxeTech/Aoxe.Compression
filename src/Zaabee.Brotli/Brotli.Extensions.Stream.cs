namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static void ToBrotli(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        bool leaveOpen = BrotliHelper.LeaveOpen) =>
        BrotliHelper.Compress(rawStream, outputStream, quality, window, leaveOpen);

    public static void UnBrotli(
        this Stream compressedStream,
        Stream outputStream,
        bool leaveOpen = BrotliHelper.LeaveOpen) =>
        BrotliHelper.Decompress(compressedStream, outputStream, leaveOpen);

    public static MemoryStream ToBrotli(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window)
    {
        var outputStream = new MemoryStream();
        rawStream.ToBrotli(outputStream, quality, window, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnBrotli(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnBrotli(outputStream, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}