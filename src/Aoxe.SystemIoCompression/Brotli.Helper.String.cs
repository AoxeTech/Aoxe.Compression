#if !NETSTANDARD2_0
namespace Aoxe.SystemIoCompression;

public static partial class BrotliHelper
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
