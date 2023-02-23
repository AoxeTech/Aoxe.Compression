namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibHelper
{
    public static byte[] ToGZip(byte[] rawBytes)
    {
        var compressStream = new MemoryStream();
        using (var outputStream = new GZipOutputStream(compressStream))
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

    public static byte[] UnGZip(byte[] compressBytes)
    {
        var decompressStream = new MemoryStream();
        using (var inputStream = new GZipInputStream(new MemoryStream(compressBytes)))
        {
            inputStream.CopyTo(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        return decompressStream.ToArray();
    }

    public static TStream ToGZip<TStream>(Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
        using (var outputStream = new GZipOutputStream(compressStream))
        {
            rawStream.CopyTo(outputStream);
            outputStream.IsStreamOwner = false;
        }
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static TStream UnGZip<TStream>(Stream compressStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
        using (var inputStream = new GZipInputStream(compressStream))
        {
            inputStream.CopyTo(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }

    public static async Task<TStream> ToGZipAsync<TStream>(Stream rawStream)
        where TStream : Stream, new()
    {
        var compressStream = new TStream();
#if NETSTANDARD2_0
        using (var outputStream = new GZipOutputStream(compressStream))
#else
        await using (var outputStream = new GZipOutputStream(compressStream))
#endif
        {
            await rawStream.CopyToAsync(outputStream);
            outputStream.IsStreamOwner = false;
        }
        compressStream.TrySeek(0, SeekOrigin.Begin);
        return compressStream;
    }

    public static async Task<TStream> UnGZipAsync<TStream>(Stream compressStream)
        where TStream : Stream, new()
    {
        var decompressStream = new TStream();
#if NETSTANDARD2_0
        using (var inputStream = new GZipInputStream(compressStream))
#else
        await using (var inputStream = new GZipInputStream(compressStream))
#endif
        {
            await inputStream.CopyToAsync(decompressStream);
            inputStream.IsStreamOwner = false;
        }
        decompressStream.TrySeek(0, SeekOrigin.Begin);
        return decompressStream;
    }
}