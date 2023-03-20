namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static async Task<MemoryStream> CompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async Task<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
        {
            await inputStream.CopyToAsync(bzip2OutputStream);
#else
        await using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
        {
            await inputStream.CopyToAsync(bzip2OutputStream, cancellationToken);
#endif
            bzip2OutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var bzip2InputStream = new BZip2InputStream(inputStream))
        {
            await bzip2InputStream.CopyToAsync(outputStream);
#else
        await using (var bzip2InputStream = new BZip2InputStream(inputStream))
        {
            await bzip2InputStream.CopyToAsync(outputStream, cancellationToken);
#endif
            bzip2InputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}