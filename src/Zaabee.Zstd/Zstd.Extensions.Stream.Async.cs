namespace Zaabee.Zstd;

public static partial class ZstdExtensions
{
    public static async Task ToZstdAsync(
        this Stream rawStream,
        Stream outputStream,
        int level = ZstdHelper.Level,
        CancellationToken cancellationToken = default) =>
        await ZstdHelper.CompressAsync(rawStream, outputStream, level, cancellationToken);

    public static async Task UnZstdAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await ZstdHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToZstdAsync(
        this Stream rawStream,
        int level = ZstdHelper.Level,
        CancellationToken cancellationToken = default) =>
        await ZstdHelper.CompressAsync(rawStream, level, cancellationToken);

    public static async Task<MemoryStream> UnZstdAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await ZstdHelper.DecompressAsync(compressedStream, cancellationToken);
}