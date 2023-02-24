namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static byte[] Compress(
        byte[] rawBytes,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0)
    {
        var outputStream = new MemoryStream();
        Compress(new MemoryStream(rawBytes), outputStream, level, extraMemory, false);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(
        byte[] compressedBytes,
        LZ4DecoderSettings? settings = null,
        bool interactive = false)
    {
        var outputStream = new MemoryStream();
        Decompress(new MemoryStream(compressedBytes), outputStream, settings, false, interactive);
        return outputStream.ToArray();
    }
}