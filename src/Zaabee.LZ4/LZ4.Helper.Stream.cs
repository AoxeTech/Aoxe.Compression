namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory,
        bool leaveOpen = LeaveOpen)
    {
        using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
        inputStream.CopyTo(lz4Stream);

        inputStream.Flush();
        lz4Stream.Flush();
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Settings,
        bool leaveOpen = LeaveOpen,
        bool interactive = Interactive)
    {
        using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
        lz4Stream.CopyTo(outputStream);

        inputStream.Flush();
        lz4Stream.Flush();
    }
}