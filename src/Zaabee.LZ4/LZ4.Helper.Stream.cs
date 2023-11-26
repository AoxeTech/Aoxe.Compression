namespace Zaabee.LZ4;

public static partial class Lz4Helper
{
    public static MemoryStream Compress(
        Stream inputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory
    )
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream, level, extraMemory);
        return outputStream;
    }

    public static MemoryStream Decompress(
        Stream inputStream,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive
    )
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream, settings, interactive);
        return outputStream;
    }

    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        LZ4Level level = Level,
        int extraMemory = ExtraMemory
    )
    {
        using (var lz4Stream = LZ4Stream.Encode(outputStream, level, extraMemory, true))
            inputStream.CopyTo(lz4Stream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Settings,
        bool interactive = Interactive
    )
    {
        using (var lz4Stream = LZ4Stream.Decode(inputStream, settings, true, interactive))
            lz4Stream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
