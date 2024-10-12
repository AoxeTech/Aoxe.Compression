namespace Aoxe.Brotli;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(
        this byte[] rawBytes,
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window
    ) => BrotliHelper.Compress(rawBytes, quality, window);

    public static byte[] UnBrotli(this byte[] compressedBytes) =>
        BrotliHelper.Decompress(compressedBytes);
}
