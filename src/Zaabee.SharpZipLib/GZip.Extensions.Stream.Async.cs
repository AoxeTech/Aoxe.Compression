namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static async Task ToGZipAsync(
        this Stream rawStream,
        Stream outputStream) =>
        await GzipHelper.CompressAsync(rawStream, outputStream);

    public static async Task UnGZipAsync(
        this Stream compressedStream,
        Stream outputStream) =>
        await GzipHelper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToGZipAsync(this Stream rawStream) =>
        await GzipHelper.CompressAsync(rawStream);

    public static async Task<MemoryStream> UnGZipAsync(this Stream compressedStream) =>
        await GzipHelper.DecompressAsync(compressedStream);
}