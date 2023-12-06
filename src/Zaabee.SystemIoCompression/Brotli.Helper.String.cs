#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliHelper
{
    public static byte[] Compress(string str, Encoding? encoding = null) =>
        Compress(str.GetBytes(encoding ?? Consts.DefaultEncoding));

    public static string DecompressToString(byte[] compressedBytes, Encoding? encoding = null) =>
        Decompress(compressedBytes).GetString(encoding ?? Consts.DefaultEncoding);
}
#endif