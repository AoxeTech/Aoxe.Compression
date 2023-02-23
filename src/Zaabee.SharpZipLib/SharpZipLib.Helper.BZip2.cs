namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibHelper
{
    public static byte[] ToBZip2(byte[] rawBytes)
    {
        var compressStream = new MemoryStream();
        using (var outputStream = new BZip2OutputStream(compressStream))
        {
#if NETSTANDARD2_0
            outputStream.Write(rawBytes, 0, rawBytes.Length);
#else
            outputStream.Write(rawBytes);
#endif
            outputStream.IsStreamOwner = false;
        }
        return compressStream.ToArray();
    }

    public static byte[] UnBZip2(byte[] compressBytes)
    {
        var decompressStream = new MemoryStream();
        using (var inputStream = new BZip2InputStream(new MemoryStream(compressBytes)))
        {
            inputStream.CopyTo(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        return decompressStream.ToArray();
    }

    public static TStream ToBZip2<TStream>(Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        using (var outputStream = new BZip2OutputStream(compressStream))
        {
            rawStream.CopyTo(outputStream);
            outputStream.IsStreamOwner = false;
        }
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnBZip2<TStream>(Stream compressStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        using (var inputStream = new BZip2InputStream(compressStream))
        {
            inputStream.CopyTo(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToBZip2Async<TStream>(Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
#if NETSTANDARD2_0
        using (var outputStream = new BZip2OutputStream(compressStream))
#else
        await using (var outputStream = new BZip2OutputStream(compressStream))
#endif
        {
            await rawStream.CopyToAsync(outputStream);
            outputStream.IsStreamOwner = false;
        }
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnBZip2Async<TStream>(Stream compressStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
#if NETSTANDARD2_0
        using (var inputStream = new BZip2InputStream(compressStream))
#else
        await using (var inputStream = new BZip2InputStream(compressStream))
#endif
        {
            await inputStream.CopyToAsync(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}