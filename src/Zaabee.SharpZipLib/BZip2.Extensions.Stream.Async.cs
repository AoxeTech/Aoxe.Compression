namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static async Task ToBZip2Async(
        this Stream rawStream,
        Stream outputStream) =>
        await Bzip2Helper.CompressAsync(rawStream, outputStream);

    public static async Task UnBZip2Async(
        this Stream compressedStream,
        Stream outputStream) =>
        await Bzip2Helper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToBZip2Async(this Stream rawStream) =>
        await Bzip2Helper.CompressAsync(rawStream);

    public static async Task<MemoryStream> UnBZip2Async(this Stream compressedStream) =>
        await Bzip2Helper.DecompressAsync(compressedStream);
}