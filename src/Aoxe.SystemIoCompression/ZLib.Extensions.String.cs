#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibExtensions
{
    public static byte[] ToZLib(
        this string str,
        Encoding? encoding = null,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => ZLibHelper.Compress(str, encoding, compressionLevel);

    public static string UnZLibToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        ZLibHelper.DecompressToString(compressedBytes, encoding);
}
#endif
