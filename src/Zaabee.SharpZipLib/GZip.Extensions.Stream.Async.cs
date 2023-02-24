namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static async Task ToGZipAsync(this Stream rawStream, Stream outputStream)
    {
        await GzipHelper.CompressAsync(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task UnGZipAsync(this Stream compressedStream, Stream outputStream)
    {
        await GzipHelper.DecompressAsync(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task<TStream> ToGZipAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        await GzipHelper.CompressAsync(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<TStream> UnGZipAsync<TStream>(this Stream compressedStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        await GzipHelper.DecompressAsync(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}