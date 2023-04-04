namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static async Task ToXzAsync(
        this Stream rawStream,
        Stream outputStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        CancellationToken cancellationToken = default) =>
        await XzHelper.CompressAsync(rawStream, outputStream, threads, preset, cancellationToken);

    public static async Task UnXzAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await XzHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToXzAsync(
        this Stream rawStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        CancellationToken cancellationToken = default) =>
        await XzHelper.CompressAsync(rawStream, threads, preset, cancellationToken);

    public static async Task<MemoryStream> UnXzAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await XzHelper.DecompressAsync(compressedStream, cancellationToken);
}