namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static byte[] ToBZip2(this string str, Encoding? encoding = null) =>
        Bzip2Helper.Compress(str, encoding);

    public static string UnBZip2ToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        Bzip2Helper.DecompressToString(compressedBytes, encoding);
}
