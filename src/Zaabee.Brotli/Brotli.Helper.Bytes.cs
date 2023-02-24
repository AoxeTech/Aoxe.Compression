namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static byte[] Compress(
        byte[] rawBytes,
        uint quality = Quality,
        uint window = Window) =>
        rawBytes.CompressToBrotli(quality, window);

    public static byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.DecompressFromBrotli();
}