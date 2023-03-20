namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static async Task ToBZip2Async(
        this Stream rawStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await Bzip2Helper.CompressAsync(rawStream, outputStream, cancellationToken);

    public static async Task UnBZip2Async(
        this Stream compressedStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await Bzip2Helper.DecompressAsync(compressedStream, outputStream, cancellationToken);

    public static async Task<MemoryStream> ToBZip2Async(
        this Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await Bzip2Helper.CompressAsync(rawStream, cancellationToken);

    public static async Task<MemoryStream> UnBZip2Async(
        this Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await Bzip2Helper.DecompressAsync(compressedStream, cancellationToken);
}