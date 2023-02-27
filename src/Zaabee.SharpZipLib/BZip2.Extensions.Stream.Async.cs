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

    public static async Task<MemoryStream> ToBZip2Async(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToBZip2Async(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnBZip2Async(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnBZip2Async(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}