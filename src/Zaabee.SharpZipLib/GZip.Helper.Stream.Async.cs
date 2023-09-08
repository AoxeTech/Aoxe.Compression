namespace Zaabee.SharpZipLib;

public static partial class GzipHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var gzipOutputStream = new GZipOutputStream(outputStream))
        {
            await inputStream.CopyToAsync(gzipOutputStream);
#else
        await using (var gzipOutputStream = new GZipOutputStream(outputStream))
        {
            await inputStream.CopyToAsync(gzipOutputStream, cancellationToken);
#endif
            gzipOutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var gzipInputStream = new GZipInputStream(inputStream))
        {
            await gzipInputStream.CopyToAsync(outputStream);
#else
        await using (var gzipInputStream = new GZipInputStream(inputStream))
        {
            await gzipInputStream.CopyToAsync(outputStream, cancellationToken);
#endif
            gzipInputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}