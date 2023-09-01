namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static byte[] ToXz(
        this string str,
        Encoding? encoding = null) =>
        XzHelper.Compress(str, encoding);

    public static string UnXzToString(
        this byte[] compressedBytes,
        Encoding? encoding = null) =>
        XzHelper.DecompressToString(compressedBytes, encoding);
}