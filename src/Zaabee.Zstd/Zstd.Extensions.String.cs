namespace Zaabee.Zstd;

public static partial class ZstdExtensions
{
    public static byte[] ToZstd(this string str, Encoding? encoding = null) =>
        ZstdHelper.Compress(str, encoding);

    public static string UnZstdToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        ZstdHelper.DecompressToString(compressedBytes, encoding);
}
