namespace Aoxe.Brotli;

public static partial class BrotliExtensions
{
    public static void ToBrotli(
        this Stream rawStream,
        Stream outputStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window
    ) => BrotliHelper.Compress(rawStream, outputStream, quality, window);

    public static void UnBrotli(this Stream compressedStream, Stream outputStream) =>
        BrotliHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToBrotli(
        this Stream rawStream,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window
    ) => BrotliHelper.Compress(rawStream, quality, window);

    public static MemoryStream UnBrotli(this Stream compressedStream) =>
        BrotliHelper.Decompress(compressedStream);
}
