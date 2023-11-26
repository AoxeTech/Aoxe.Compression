namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static ValueTask ToXzAsync(
        this Stream rawStream,
        Stream outputStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        CancellationToken cancellationToken = default
    ) => XzHelper.CompressAsync(rawStream, outputStream, threads, preset, cancellationToken);

    public static ValueTask UnXzAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => XzHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToXzAsync(
        this Stream rawStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        CancellationToken cancellationToken = default
    ) => XzHelper.CompressAsync(rawStream, threads, preset, cancellationToken);

    public static ValueTask<MemoryStream> UnXzAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => XzHelper.DecompressAsync(compressedStream, cancellationToken);
}
