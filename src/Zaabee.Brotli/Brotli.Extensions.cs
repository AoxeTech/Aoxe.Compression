namespace Zaabee.Brotli;

public static class BrotliExtensions
{
    public static byte[] ToBrotli(this byte[] rawBytes) =>
        BrotliHelper.ToBrotli(rawBytes);

    public static byte[] UnBrotli(this byte[] compressBytes) =>
        BrotliHelper.UnBrotli(compressBytes);

    public static TStream ToBrotli<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        BrotliHelper.ToBrotli(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnBrotli<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        BrotliHelper.UnBrotli(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToBrotliAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        await BrotliHelper.ToBrotliAsync(rawStream, compressStream);
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnBrotliAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        await BrotliHelper.UnBrotliAsync(rawStream, decompressStream);
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}