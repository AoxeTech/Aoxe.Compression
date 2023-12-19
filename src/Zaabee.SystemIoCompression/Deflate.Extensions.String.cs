namespace Zaabee.SystemIoCompression;

public static partial class DeflateExtensions
{
    public static byte[] ToDeflate(
        this string str,
        Encoding? encoding = null,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => DeflateHelper.Compress(str, encoding, compressionLevel);

    public static string UnDeflateToString(
        this byte[] compressedBytes,
        Encoding? encoding = null
    ) => DeflateHelper.DecompressToString(compressedBytes, encoding);
}
