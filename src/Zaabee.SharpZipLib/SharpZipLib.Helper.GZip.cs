namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibHelper
{
    public static byte[] ToGZip(byte[] rawBytes)
    {
        var compressStream = new MemoryStream();
        using (var outputStream = new GZipOutputStream(compressStream))
            rawBytes.WriteTo(outputStream);
        return compressStream.ToArray();
    }

    public static byte[] UnGZip(byte[] compressBytes)
    {
        var decompressStream = new MemoryStream();
        using (var inputStream = new GZipInputStream(new MemoryStream(compressBytes)))
            inputStream.CopyTo(decompressStream);
        return decompressStream.ToArray();
    }

    public static void ToGZip(
        Stream rawStream,
        Stream compressStream,
        bool isStreamOwner = false)
    {
        using var outputStream = new GZipOutputStream(compressStream);
        rawStream.CopyTo(outputStream);
        outputStream.IsStreamOwner = isStreamOwner;
    }

    public static void UnGZip(
        Stream compressStream,
        Stream decompressStream,
        bool isStreamOwner = false)
    {
        using var inputStream = new GZipInputStream(compressStream);
        inputStream.CopyTo(decompressStream);
        inputStream.IsStreamOwner = isStreamOwner;
    }

    public static async Task ToGZipAsync(
        Stream rawStream,
        Stream compressStream,
        bool isStreamOwner = false)
    {
#if NETSTANDARD2_0
        using var outputStream = new GZipOutputStream(compressStream);
#else
        await using var outputStream = new GZipOutputStream(compressStream);
#endif
        await rawStream.CopyToAsync(outputStream);
        outputStream.IsStreamOwner = isStreamOwner;
    }

    public static async Task UnGZipAsync(
        Stream compressStream,
        Stream decompressStream,
        bool isStreamOwner = false)
    {
#if NETSTANDARD2_0
        using var inputStream = new GZipInputStream(compressStream);
#else
        await using var inputStream = new GZipInputStream(compressStream);
#endif
        await inputStream.CopyToAsync(decompressStream);
        inputStream.IsStreamOwner = isStreamOwner;
    }
}