namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0,
        bool leaveOpen = true)
    {

#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
#else
        await using var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, leaveOpen);
#endif
        await inputStream.CopyToAsync(lz4Stream);

        await inputStream.FlushAsync();
        lz4Stream.Flush();
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = null,
        bool leaveOpen = true,
        bool interactive = false)
    {
#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
#else
        await using var lz4Stream = LZ4Stream.Decode(inputStream, settings, leaveOpen, interactive);
#endif
        await lz4Stream.CopyToAsync(outputStream);

        await inputStream.FlushAsync();
        lz4Stream.Flush();
    }
}