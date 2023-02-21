namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToBZip2(this byte[] rawData) =>
        ToBZip2Stream<MemoryStream>(rawData).ToArray();

    public static byte[] UnBZip2(this byte[] bytes) =>
        UnBZip2Stream<MemoryStream>(new MemoryStream(bytes)).ToArray();

    public static TStream ToBZip2Stream<TStream>(this byte[] rawData)
        where TStream : Stream, new()
    {
        var stream = new TStream();
        using (var outputStream = new BZip2OutputStream(stream))
        {
            outputStream.IsStreamOwner = false;
            CompressToStream(outputStream, rawData);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static TStream UnBZip2Stream<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var stream = new TStream();
        using (var inputStream = new BZip2InputStream(rawStream))
        {
            inputStream.IsStreamOwner = false;
            DecompressFromStream(inputStream, stream);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static async Task<TStream> ToBZip2StreamAsync<TStream>(this byte[] rawData)
        where TStream : Stream, new()
    {
        var stream = new TStream();
#if NETSTANDARD2_0
        using (var outputStream = new BZip2OutputStream(stream))
#else
        await using (var outputStream = new BZip2OutputStream(stream))
#endif
        {
            outputStream.IsStreamOwner = false;
            await CompressToStreamAsync(outputStream, rawData);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static async Task<TStream> UnBZip2StreamAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var stream = new TStream();
#if NETSTANDARD2_0
        using (var inputStream = new BZip2InputStream(rawStream))
#else
        await using (var inputStream = new BZip2InputStream(rawStream))
#endif
        {
            inputStream.IsStreamOwner = false;
            await DecompressFromStreamAsync(inputStream, stream);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }
}