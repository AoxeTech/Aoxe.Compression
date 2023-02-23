namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToGZip(this byte[] rawData) =>
        SharpZipLibHelper.ToGZip(rawData);

    public static byte[] UnGZip(this byte[] bytes) =>
        SharpZipLibHelper.UnGZip(bytes);

    public static TStream ToGZip<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        SharpZipLibHelper.ToGZip(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnGZip<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        SharpZipLibHelper.UnGZip(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToGZipAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        await SharpZipLibHelper.ToGZipAsync(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnGZipAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        await SharpZipLibHelper.UnGZipAsync(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}