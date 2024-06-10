namespace Aoxe.LZMA;

public static partial class LzmaExtensions
{
    public static byte[] ToLzma(this string str, Encoding? encoding = null) =>
        LzmaHelper.Compress(str, encoding);

    public static string UnLzmaToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        LzmaHelper.DecompressToString(compressedBytes, encoding);
}
