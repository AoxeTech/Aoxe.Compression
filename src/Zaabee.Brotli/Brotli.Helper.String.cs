namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static byte[] Compress(
        string str,
        uint quality = Quality,
        uint window = Window,
        Encoding? encoding = null) =>
        Compress(str.GetBytes(encoding ?? Consts.DefaultEncoding), quality, window);

    public static string DecompressToString(
        byte[] compressedBytes,
        Encoding? encoding = null) =>
        Decompress(compressedBytes)
            .GetString(encoding ?? Consts.DefaultEncoding);
}