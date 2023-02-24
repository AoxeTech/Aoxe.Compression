namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0,
        bool leaveOpen = true)
    {
        using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
        inputStream.CopyTo(lz4Stream);

        inputStream.Flush();
        lz4Stream.Flush();
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = null,
        bool leaveOpen = true,
        bool interactive = false)
    {
        using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
        lz4Stream.CopyTo(outputStream);

        inputStream.Flush();
        lz4Stream.Flush();
    }
}