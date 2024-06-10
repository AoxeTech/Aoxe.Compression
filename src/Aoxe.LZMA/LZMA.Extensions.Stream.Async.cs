namespace Aoxe.LZMA;

public static partial class LzmaExtensions
{
    public static ValueTask ToLzmaAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => LzmaHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static ValueTask UnLzmaAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => LzmaHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToLzmaAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default
    ) => LzmaHelper.CompressAsync(rawStream, cancellationToken);

    public static ValueTask<MemoryStream> UnLzmaAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => LzmaHelper.DecompressAsync(compressedStream, cancellationToken);
}
