namespace Zaabee.SharpZipLib;

public static partial class GzipHelper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
#if NETSTANDARD2_0
        using (var gzipOutputStream = new GZipOutputStream(outputStream))
#else
        await using (var gzipOutputStream = new GZipOutputStream(outputStream))
#endif
        {
            await inputStream.CopyToAsync(gzipOutputStream);
            gzipOutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
#if NETSTANDARD2_0
        using (var gzipInputStream = new GZipInputStream(inputStream))
#else
        await using (var gzipInputStream = new GZipInputStream(inputStream))
#endif
        {
            await gzipInputStream.CopyToAsync(outputStream);
            gzipInputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}