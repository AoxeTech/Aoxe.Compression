namespace Aoxe.LZ4;

public static partial class Lz4Extensions
{
    public static byte[] ToLz4(
        this byte[] rawBytes,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory
    ) => Lz4Helper.Compress(rawBytes, level, extraMemory);

    public static byte[] UnLz4(
        this byte[] compressedBytes,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive
    ) => Lz4Helper.Decompress(compressedBytes, settings, interactive);
}
