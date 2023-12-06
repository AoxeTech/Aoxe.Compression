namespace Zaabee.SystemIoCompression;

public static partial class GzipExtensions
{
    public static ValueTask ToGZipAsync(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => GzipHelper.CompressAsync(rawStream, outputStream, compressionLevel, cancellationToken);

    public static ValueTask UnGZipAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToGZipAsync(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => GzipHelper.CompressAsync(rawStream, compressionLevel, cancellationToken);

    public static ValueTask<MemoryStream> UnGZipAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => GzipHelper.DecompressAsync(compressedStream, cancellationToken);
}