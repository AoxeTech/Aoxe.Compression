namespace Zaabee.LZMA;

public static partial class LzmaExtensions
{
    public static async Task ToLzmaAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await LzmaHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static async Task UnLzmaAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await LzmaHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToLzmaAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await LzmaHelper.CompressAsync(rawStream, cancellationToken);

    public static async Task<MemoryStream> UnLzmaAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await LzmaHelper.DecompressAsync(compressedStream, cancellationToken);
}