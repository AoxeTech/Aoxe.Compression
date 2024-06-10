namespace Aoxe.LZ4;

public static partial class Lz4Helper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, level, extraMemory, cancellationToken);
        return outputStream;
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, settings, interactive, cancellationToken);
        return outputStream;
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory,
        CancellationToken cancellationToken = default
    )
    {
#if NETSTANDARD2_0
        using (var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, true))
            await inputStream.CopyToAsync(lz4Stream);
#else
        await using (var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, true))
            await inputStream.CopyToAsync(lz4Stream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive,
        CancellationToken cancellationToken = default
    )
    {
#if NETSTANDARD2_0
        using (var lz4Stream = LZ4Stream.Decode(inputStream, settings, true, interactive))
            await lz4Stream.CopyToAsync(outputStream);
#else
        await using (var lz4Stream = LZ4Stream.Decode(inputStream, settings, true, interactive))
            await lz4Stream.CopyToAsync(outputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
