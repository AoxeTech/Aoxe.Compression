namespace Zaabee.Snappy;

public static partial class SnappyExtensions
{
    public static async Task ToSnappyAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await SnappyHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static async Task UnSnappyAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await SnappyHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToSnappyAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await SnappyHelper.CompressAsync(rawStream, cancellationToken);

    public static async Task<MemoryStream> UnSnappyAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await SnappyHelper.DecompressAsync(compressedStream, cancellationToken);
}