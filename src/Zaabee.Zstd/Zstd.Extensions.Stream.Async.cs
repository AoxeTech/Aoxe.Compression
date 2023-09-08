namespace Zaabee.Zstd;

public static partial class ZstdExtensions
{
    public static ValueTask ToZstdAsync(
        this Stream rawStream,
        Stream outputStream,
        int level = ZstdHelper.Level,
        CancellationToken cancellationToken = default) =>
        ZstdHelper.CompressAsync(rawStream, outputStream, level, cancellationToken);

    public static ValueTask UnZstdAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        ZstdHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToZstdAsync(
        this Stream rawStream,
        int level = ZstdHelper.Level,
        CancellationToken cancellationToken = default) =>
        ZstdHelper.CompressAsync(rawStream, level, cancellationToken);

    public static ValueTask<MemoryStream> UnZstdAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        ZstdHelper.DecompressAsync(compressedStream, cancellationToken);
}