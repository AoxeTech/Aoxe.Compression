namespace Zaabee.SharpZipLib;

public static partial class DeflateHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    )
    {
#if NETSTANDARD2_0
        using (var deflateOutputStream = new DeflaterOutputStream(outputStream))
        {
            await inputStream.CopyToAsync(deflateOutputStream);
#else
        await using (var deflateOutputStream = new DeflaterOutputStream(outputStream))
        {
            await inputStream.CopyToAsync(deflateOutputStream, cancellationToken);
#endif
            deflateOutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    )
    {
#if NETSTANDARD2_0
        using (var deflateInputStream = new InflaterInputStream(inputStream))
        {
            await deflateInputStream.CopyToAsync(outputStream);
#else
        await using (var deflateInputStream = new InflaterInputStream(inputStream))
        {
            await deflateInputStream.CopyToAsync(outputStream, cancellationToken);
#endif
            deflateInputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
