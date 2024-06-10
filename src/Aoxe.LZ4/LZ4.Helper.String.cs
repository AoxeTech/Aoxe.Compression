namespace Aoxe.LZ4;

public static partial class Lz4Helper
{
    public static byte[] Compress(
        string str,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory,
        Encoding? encoding = null
    ) => Compress(str.GetBytes(encoding ?? Consts.DefaultEncoding), level, extraMemory);

    public static string DecompressToString(
        byte[] compressedBytes,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive,
        Encoding? encoding = null
    ) =>
        Decompress(compressedBytes, settings, interactive)
            .GetString(encoding ?? Consts.DefaultEncoding);
}
