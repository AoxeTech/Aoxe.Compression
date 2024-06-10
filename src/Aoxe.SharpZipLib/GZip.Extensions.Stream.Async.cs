namespace Aoxe.SharpZipLib;

public static partial class GzipExtensions
{
    public static ValueTask ToGZipAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static ValueTask UnGZipAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToGZipAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.CompressAsync(rawStream, cancellationToken);

    public static ValueTask<MemoryStream> UnGZipAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.DecompressAsync(compressedStream, cancellationToken);
}
