namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] ToGZip(this byte[] rawData) =>
        ToGZipStream<MemoryStream>(rawData).ToArray();

    public static byte[] UnGZip(this byte[] bytes) =>
        UnGZipStream<MemoryStream>(new MemoryStream(bytes)).ToArray();

    public static TStream ToGZipStream<TStream>(this byte[] rawData)
        where TStream : Stream, new()
    {
        var stream = new TStream();
        using (var outputStream = new GZipOutputStream(stream))
        {
            outputStream.IsStreamOwner = false;
            CompressToStream(outputStream, rawData);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static TStream UnGZipStream<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var stream = new TStream();
        using (var inputStream = new GZipInputStream(rawStream))
        {
            inputStream.IsStreamOwner = false;
            DecompressFromStream(inputStream, stream);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static async Task<TStream> ToGZipStreamAsync<TStream>(this byte[] rawData)
        where TStream : Stream, new()
    {
        var stream = new TStream();
#if NETSTANDARD2_0
        using (var outputStream = new GZipOutputStream(stream))
#else
        await using (var outputStream = new GZipOutputStream(stream))
#endif
        {
            outputStream.IsStreamOwner = false;
            await CompressToStreamAsync(outputStream, rawData);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }

    public static async Task<TStream> UnGZipStreamAsync<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var stream = new TStream();
#if NETSTANDARD2_0
        using (var inputStream = new GZipInputStream(rawStream))
#else
        await using (var inputStream = new GZipInputStream(rawStream))
#endif
        {
            inputStream.IsStreamOwner = false;
            await DecompressFromStreamAsync(inputStream, stream);
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }
}