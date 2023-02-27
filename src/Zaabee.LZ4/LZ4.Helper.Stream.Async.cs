namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory)
    {

#if NETSTANDARD2_0
        using (var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, true))
#else
        await using (var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, true))
#endif
            await inputStream.CopyToAsync(lz4Stream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive)
    {
#if NETSTANDARD2_0
        using (var lz4Stream = LZ4Stream.Decode(inputStream, settings, true, interactive))
#else
        await using (var lz4Stream = LZ4Stream.Decode(inputStream, settings, true, interactive))
#endif
            await lz4Stream.CopyToAsync(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}