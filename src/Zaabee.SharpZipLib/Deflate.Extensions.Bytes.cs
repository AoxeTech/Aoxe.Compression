namespace Zaabee.SharpZipLib;

public static partial class DeflateExtensions
{
    public static byte[] ToDeflate(this byte[] rawBytes) => DeflateHelper.Compress(rawBytes);

    public static byte[] UnDeflate(this byte[] compressedBytes) =>
        DeflateHelper.Decompress(compressedBytes);
}
