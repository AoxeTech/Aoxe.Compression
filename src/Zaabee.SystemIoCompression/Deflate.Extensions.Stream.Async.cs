namespace Zaabee.SystemIoCompression;

public static partial class DeflateExtensions
{
    public static ValueTask ToDeflateAsync(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => DeflateHelper.CompressAsync(rawStream, outputStream, compressionLevel, cancellationToken);

    public static ValueTask UnDeflateAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => DeflateHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToDeflateAsync(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    ) => DeflateHelper.CompressAsync(rawStream, compressionLevel, cancellationToken);

    public static ValueTask<MemoryStream> UnDeflateAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => DeflateHelper.DecompressAsync(compressedStream, cancellationToken);
}