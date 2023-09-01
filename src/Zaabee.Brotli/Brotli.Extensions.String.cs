namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(
        this string str,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window,
        Encoding? encoding = null) =>
        BrotliHelper.Compress(str, quality, window, encoding);

    public static string UnBrotliToString(
        this byte[] compressedBytes,
        Encoding? encoding = null) =>
        BrotliHelper.DecompressToString(compressedBytes);
}