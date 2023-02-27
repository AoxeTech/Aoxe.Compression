namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory,
        bool leaveOpen = LeaveOpen)
    {

#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
#else
        await using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
#endif
        await inputStream.CopyToAsync(lz4Stream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Settings,
        bool leaveOpen = LeaveOpen,
        bool interactive = Interactive)
    {
#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
#else
        await using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
#endif
        await lz4Stream.CopyToAsync(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
    }
}