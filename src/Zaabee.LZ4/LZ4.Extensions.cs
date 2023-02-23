namespace Zaabee.LZ4;

public static class Lz4Extensions
{
    public static byte[] ToLz4(this byte[] rawBytes) =>
        Lz4Helper.ToLz4(rawBytes);

    public static byte[] UnLz4(this byte[] compressBytes) =>
        Lz4Helper.UnLz4(compressBytes);

    public static TStream ToLz4<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        Lz4Helper.ToLz4(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnLz4<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        Lz4Helper.UnLz4(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToLz4Async<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        await Lz4Helper.ToLz4Async(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnLz4Async<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        await Lz4Helper.UnLz4Async(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}