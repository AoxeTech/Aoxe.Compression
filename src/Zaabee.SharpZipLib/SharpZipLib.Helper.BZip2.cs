namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibHelper
{
    public static byte[] ToBZip2(byte[] rawBytes)
    {
        var compressStream = new MemoryStream();
        using (var outputStream = new BZip2OutputStream(compressStream))
            rawBytes.WriteTo(outputStream);
        return compressStream.ToArray();
    }

    public static byte[] UnBZip2(byte[] compressBytes)
    {
        var decompressStream = new MemoryStream();
        using (var inputStream = new BZip2InputStream(new MemoryStream(compressBytes)))
            inputStream.CopyTo(decompressStream);
        return decompressStream.ToArray();
    }

    public static void ToBZip2(
        Stream rawStream,
        Stream compressStream,
        bool isStreamOwner = false)
    {
        using var outputStream = new BZip2OutputStream(compressStream);
        rawStream.CopyTo(outputStream);
        outputStream.IsStreamOwner = isStreamOwner;
    }

    public static void UnBZip2(
        Stream compressStream,
        Stream decompressStream,
        bool isStreamOwner = false)
    {
        using var inputStream = new BZip2InputStream(compressStream);
        inputStream.CopyTo(decompressStream);
        inputStream.IsStreamOwner = isStreamOwner;
    }

    public static async Task ToBZip2Async(
        Stream rawStream,
        Stream compressStream,
        bool isStreamOwner = false)
    {
#if NETSTANDARD2_0
        using var outputStream = new BZip2OutputStream(compressStream);
#else
        await using var outputStream = new BZip2OutputStream(compressStream);
#endif
        await rawStream.CopyToAsync(outputStream);
        outputStream.IsStreamOwner = isStreamOwner;
    }

    public static async Task UnBZip2Async(
        Stream compressStream,
        Stream decompressStream,
        bool isStreamOwner = false)
    {
#if NETSTANDARD2_0
        using var inputStream = new BZip2InputStream(compressStream);
#else
        await using var inputStream = new BZip2InputStream(compressStream);
#endif
        await inputStream.CopyToAsync(decompressStream);
        inputStream.IsStreamOwner = isStreamOwner;
    }
}