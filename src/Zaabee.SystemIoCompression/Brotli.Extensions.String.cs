#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(this string str, Encoding? encoding = null) =>
        BrotliHelper.Compress(str, encoding);

    public static string UnBrotliToString(this byte[] compressedBytes, Encoding? encoding = null) =>
        BrotliHelper.DecompressToString(compressedBytes, encoding);
}
#endif