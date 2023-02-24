namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static byte[] ToBZip2(this byte[] rawBytes) =>
        Bzip2Helper.Compress(rawBytes);

    public static byte[] UnBZip2(this byte[] compressedBytes) =>
        Bzip2Helper.Decompress(compressedBytes);
}