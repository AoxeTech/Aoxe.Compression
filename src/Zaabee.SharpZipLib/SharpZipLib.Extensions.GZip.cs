namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToGZip(this byte[] rawData) =>
        SharpZipLibHelper.ToGZip(rawData);

    public static byte[] UnGZip(this byte[] bytes) =>
        SharpZipLibHelper.UnGZip(bytes);

    public static TStream ToGZip<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        SharpZipLibHelper.ToGZip<TStream>(rawStream);

    public static TStream UnGZip<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        SharpZipLibHelper.UnGZip<TStream>(rawStream);

    public static async Task<TStream> ToGZipAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        await SharpZipLibHelper.ToGZipAsync<TStream>(rawStream);

    public static async Task<TStream> UnGZipAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new() =>
        await SharpZipLibHelper.UnGZipAsync<TStream>(rawStream);
}