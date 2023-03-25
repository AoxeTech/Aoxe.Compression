namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static async Task ToXzAsync(
        this Stream rawStream,
        Stream outputStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        bool levelOpen = XzHelper.LevelOpen,
        CancellationToken cancellationToken = default) =>
        await XzHelper.CompressAsync(rawStream, outputStream, threads, preset, levelOpen, cancellationToken);

    public static async Task UnXzAsync(
        this Stream compressedStream,
        Stream outputStream,
        bool levelOpen = XzHelper.LevelOpen,
        CancellationToken cancellationToken = default) =>
        await XzHelper.DecompressAsync(compressedStream, outputStream, levelOpen, cancellationToken);

    public static async Task<MemoryStream> ToXzAsync(
        this Stream rawStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        bool levelOpen = XzHelper.LevelOpen,
        CancellationToken cancellationToken = default) =>
        await XzHelper.CompressAsync(rawStream, threads, preset, levelOpen, cancellationToken);

    public static async Task<MemoryStream> UnXzAsync(
        this Stream compressedStream,
        bool levelOpen = XzHelper.LevelOpen,
        CancellationToken cancellationToken = default) =>
        await XzHelper.DecompressAsync(compressedStream, levelOpen, cancellationToken);
}