#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static ValueTask ToBrotliAsync(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => BrotliHelper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static ValueTask UnBrotliAsync(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => BrotliHelper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToBrotliAsync(
        this Stream rawStream,
        CancellationToken cancellationToken = default
    ) => BrotliHelper.CompressAsync(rawStream, cancellationToken);

    public static ValueTask<MemoryStream> UnBrotliAsync(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => BrotliHelper.DecompressAsync(compressedStream, cancellationToken);
}
#endif