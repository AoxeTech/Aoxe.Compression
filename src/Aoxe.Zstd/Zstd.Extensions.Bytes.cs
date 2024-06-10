namespace Aoxe.Zstd;

public static partial class ZstdExtensions
{
    public static byte[] ToZstd(this byte[] rawBytes, int level = ZstdHelper.Level) =>
        ZstdHelper.Compress(rawBytes, level);

    public static byte[] UnZstd(this byte[] compressedBytes) =>
        ZstdHelper.Decompress(compressedBytes);
}
