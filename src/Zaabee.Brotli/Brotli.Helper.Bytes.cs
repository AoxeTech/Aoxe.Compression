namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static byte[] Compress(
        byte[] rawBytes,
        uint quality = 5,
        uint window = 22)=>
        rawBytes.CompressToBrotli(quality, window);

    public static byte[] Decompress(byte[] compressedBytes)=>
        compressedBytes.DecompressFromBrotli();
}