namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static async Task<MemoryStream> CompressAsync(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream);
        return outputStream;
    }

    public static async Task<MemoryStream> DecompressAsync(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream);
        return outputStream;
    }

    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
#if NETSTANDARD2_0
        using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
#else
        await using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
#endif
        {
            await inputStream.CopyToAsync(bzip2OutputStream);
            bzip2OutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
#if NETSTANDARD2_0
        using (var bzip2InputStream = new BZip2InputStream(inputStream))
#else
        await using (var bzip2InputStream = new BZip2InputStream(inputStream))
#endif
        {
            await bzip2InputStream.CopyToAsync(outputStream);
            bzip2InputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}