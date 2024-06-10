namespace Aoxe.SharpZipLib;

public static partial class GzipExtensions
{
    public static byte[] ToGZip(this string str, Encoding? encoding = null) =>
        GzipHelper.Compress(str, encoding);

    public static string UnGZipToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        GzipHelper.DecompressToString(compressedBytes, encoding);
}
