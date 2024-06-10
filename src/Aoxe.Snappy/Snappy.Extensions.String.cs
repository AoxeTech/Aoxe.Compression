namespace Aoxe.Snappy;

public static partial class SnappyExtensions
{
    public static byte[] ToSnappy(this string str, Encoding? encoding = null) =>
        SnappyHelper.Compress(str, encoding);

    public static string UnSnappyToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        SnappyHelper.DecompressToString(compressedBytes, encoding);
}
