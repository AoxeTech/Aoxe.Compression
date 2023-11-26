namespace Zaabee.Snappy;

public static partial class SnappyExtensions
{
    public static ValueTask ToSnappyAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => SnappyHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static ValueTask UnSnappyAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => SnappyHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToSnappyAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default
    ) => SnappyHelper.CompressAsync(rawStream, cancellationToken);

    public static ValueTask<MemoryStream> UnSnappyAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => SnappyHelper.DecompressAsync(compressedStream, cancellationToken);
}
