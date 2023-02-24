namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = IsStreamOwner)
    {
#if NETSTANDARD2_0
        using var bzip2OutputStream = new BZip2OutputStream(outputStream);
#else
        await using var bzip2OutputStream = new BZip2OutputStream(outputStream);
#endif
        await inputStream.CopyToAsync(bzip2OutputStream);
        bzip2OutputStream.IsStreamOwner = isStreamOwner;
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = IsStreamOwner)
    {
#if NETSTANDARD2_0
        using var bzip2InputStream = new BZip2InputStream(inputStream);
#else
        await using var bzip2InputStream = new BZip2InputStream(inputStream);
#endif
        await bzip2InputStream.CopyToAsync(outputStream);
        bzip2InputStream.IsStreamOwner = isStreamOwner;
    }
}