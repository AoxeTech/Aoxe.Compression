namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToBZip2(this byte[] rawData) =>
        SharpZipLibHelper.ToBZip2(rawData);

    public static byte[] UnBZip2(this byte[] bytes) =>
        SharpZipLibHelper.UnBZip2(bytes);

    public static TStream ToBZip2<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        SharpZipLibHelper.ToBZip2(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnBZip2<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        SharpZipLibHelper.UnBZip2(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToBZip2Async<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        await SharpZipLibHelper.ToBZip2Async(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnBZip2Async<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        await SharpZipLibHelper.UnBZip2Async(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}