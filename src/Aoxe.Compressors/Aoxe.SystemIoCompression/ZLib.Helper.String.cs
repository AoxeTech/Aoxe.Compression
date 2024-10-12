#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibHelper
{
    public static byte[] Compress(
        string str,
        Encoding? encoding = null,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => Compress(str.GetBytes(encoding ?? Consts.DefaultEncoding), compressionLevel);

    public static string DecompressToString(byte[] compressedBytes, Encoding? encoding = null) =>
        Decompress(compressedBytes).GetString(encoding ?? Consts.DefaultEncoding);
}
#endif
