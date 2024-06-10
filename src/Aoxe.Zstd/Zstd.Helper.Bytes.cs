namespace Aoxe.Zstd;

public static partial class ZstdHelper
{
    public static byte[] Compress(byte[] rawBytes, int level = Level)
    {
        using var options = new CompressionOptions(level);
        using var compressor = new ZstdNet.Compressor(options);
        return compressor.Wrap(rawBytes);
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        using var decompressor = new Decompressor();
        return decompressor.Unwrap(compressedBytes);
    }
}
