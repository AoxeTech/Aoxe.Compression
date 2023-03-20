namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static async Task ToGZipAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await GzipHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static async Task UnGZipAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await GzipHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToGZipAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await GzipHelper.CompressAsync(rawStream, cancellationToken);

    public static async Task<MemoryStream> UnGZipAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await GzipHelper.DecompressAsync(compressedStream, cancellationToken);
}