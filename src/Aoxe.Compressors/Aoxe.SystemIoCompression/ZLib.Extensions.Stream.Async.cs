#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibExtensions
{
    public static ValueTask ToZLibAsync(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => ZLibHelper.CompressAsync(rawStream, outputStream, compressionLevel, cancellationToken);

    public static ValueTask UnZLibAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => ZLibHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToZLibAsync(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => ZLibHelper.CompressAsync(rawStream, compressionLevel, cancellationToken);

    public static ValueTask<MemoryStream> UnZLibAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => ZLibHelper.DecompressAsync(compressedStream, cancellationToken);
}
#endif
