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
#if NETSTANDARD2_0
            outputStream.Write(rawData, 0, rawData.Length);
#else
            outputStream.Write(rawData);
#endif
            outputStream.IsStreamOwner = false;
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
            inputStream.CopyTo(stream);
            inputStream.IsStreamOwner = false;
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
        {
            await outputStream.WriteAsync(rawData, 0, rawData.Length);
#else
        await using (var outputStream = new GZipOutputStream(stream))
        {
            await outputStream.WriteAsync(rawData);
#endif
            outputStream.IsStreamOwner = false;
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
            await inputStream.CopyToAsync(stream);
            inputStream.IsStreamOwner = false;
        }
        stream.TrySeek(0, SeekOrigin.Begin);
        return stream;
    }
}