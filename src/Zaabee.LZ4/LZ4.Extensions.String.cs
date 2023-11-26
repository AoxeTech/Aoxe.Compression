namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static byte[] ToLz4(
        this string str,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory,
        Encoding? encoding = null
    ) => Lz4Helper.Compress(str, level, extraMemory, encoding);

    public static string UnLz4ToString(
        this byte[] compressedBytes,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive,
        Encoding? encoding = null
    ) => Lz4Helper.DecompressToString(compressedBytes, settings, interactive, encoding);
}
