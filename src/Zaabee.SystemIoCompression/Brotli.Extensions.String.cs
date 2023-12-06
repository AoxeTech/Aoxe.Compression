#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(this string str, Encoding? encoding = null, CompressionLevel compressionLevel = CompressionLevel.Optimal) =>
        BrotliHelper.Compress(str, encoding, compressionLevel);

    public static string UnBrotliToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        BrotliHelper.DecompressToString(compressedBytes, encoding);
}
#endif