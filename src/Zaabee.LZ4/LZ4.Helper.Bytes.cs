namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static byte[] Compress(
        byte[] rawBytes,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory)
    {
        var outputStream = new MemoryStream();
        Compress(new MemoryStream(rawBytes), outputStream, level, extraMemory);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(
        byte[] compressedBytes,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive)
    {
        var outputStream = new MemoryStream();
        Decompress(new MemoryStream(compressedBytes), outputStream, settings, interactive);
        return outputStream.ToArray();
    }
}