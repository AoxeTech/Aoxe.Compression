namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static void ToLz4(
        this Stream rawStream,
        Stream outputStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory) =>
        Lz4Helper.Compress(rawStream, outputStream, level, extraMemory);

    public static void UnLz4(
        this Stream compressedStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive) =>
        Lz4Helper.Decompress(compressedStream, outputStream, settings, interactive);

    public static MemoryStream ToLz4(
        this Stream rawStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory) =>
        Lz4Helper.Compress(rawStream, level, extraMemory);

    public static MemoryStream UnLz4(
        this Stream compressedStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive) =>
        Lz4Helper.Decompress(compressedStream, settings, interactive);
}