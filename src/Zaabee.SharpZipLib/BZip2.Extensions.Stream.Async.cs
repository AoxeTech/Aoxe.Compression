namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static ValueTask ToBZip2Async(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => Bzip2Helper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static ValueTask UnBZip2Async(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => Bzip2Helper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static ValueTask<MemoryStream> ToBZip2Async(
        this Stream rawStream,
        CancellationToken cancellationToken = default
    ) => Bzip2Helper.CompressAsync(rawStream, cancellationToken);

    public static ValueTask<MemoryStream> UnBZip2Async(
        this Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => Bzip2Helper.DecompressAsync(compressedStream, cancellationToken);
}
