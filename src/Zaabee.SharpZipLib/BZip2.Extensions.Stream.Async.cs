namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static async Task ToBZip2Async(this Stream rawStream, Stream outputStream)
    {
        await Bzip2Helper.CompressAsync(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task UnBZip2Async(this Stream compressedStream, Stream outputStream)
    {
        await Bzip2Helper.DecompressAsync(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task<TStream> ToBZip2Async<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        await Bzip2Helper.CompressAsync(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<TStream> UnBZip2Async<TStream>(this Stream compressedStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        await Bzip2Helper.DecompressAsync(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}