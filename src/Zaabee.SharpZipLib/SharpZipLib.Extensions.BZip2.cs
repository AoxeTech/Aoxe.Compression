namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToBZip2(this byte[] rawData) =>
        SharpZipLibHelper.ToBZip2(rawData);

    public static byte[] UnBZip2(this byte[] bytes) =>
        SharpZipLibHelper.UnBZip2(bytes);

    public static TStream ToBZip2<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        SharpZipLibHelper.ToBZip2<TStream>(rawStream);

    public static TStream UnBZip2<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        SharpZipLibHelper.UnBZip2<TStream>(rawStream);

    public static async Task<TStream> ToBZip2Async<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        await SharpZipLibHelper.ToBZip2Async<TStream>(rawStream);

    public static async Task<TStream> UnBZip2Async<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        await SharpZipLibHelper.UnBZip2Async<TStream>(rawStream);
}