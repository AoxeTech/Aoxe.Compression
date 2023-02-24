namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static async Task ToLz4Async(
        this Stream rawStream,
        Stream outputStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory,
        bool leaveOpen = Lz4Helper.LeaveOpen) =>
        await Lz4Helper.CompressAsync(rawStream, outputStream, level, extraMemory, leaveOpen);

    public static async Task UnLz4Async(
        this Stream compressedStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool leaveOpen = Lz4Helper.LeaveOpen,
        bool interactive = Lz4Helper.Interactive) =>
        await Lz4Helper.DecompressAsync(compressedStream, outputStream, settings, leaveOpen, interactive);

    public static async Task<MemoryStream> ToLz4Async(
        this Stream rawStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToLz4Async(outputStream, level, extraMemory, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnLz4Async(
        this Stream compressedStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnLz4Async(outputStream, settings, true, interactive);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}