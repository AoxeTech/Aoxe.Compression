namespace Aoxe.SystemIoCompression;

public static partial class GzipExtensions
{
    public static byte[] ToGZip(
        this string str,
        Encoding? encoding = null,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => GzipHelper.Compress(str, encoding, compressionLevel);

    public static string UnGZipToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        GzipHelper.DecompressToString(compressedBytes, encoding);
}
