namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        uint quality = Quality,
        uint window = Window,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, quality, window, cancellationToken);
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
        uint quality = Quality,
        uint window = Window,
        CancellationToken cancellationToken = default
    )
    {
#if NETSTANDARD2_0
        using (var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
        {
            brotliStream.SetQuality(quality);
            brotliStream.SetWindow(window);
            await inputStream.CopyToAsync(brotliStream);
#else
        await using (
            var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, true)
        )
        {
            brotliStream.SetQuality(quality);
            brotliStream.SetWindow(window);
            await inputStream.CopyToAsync(brotliStream, cancellationToken);
#endif
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
        using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, true))
            await brotliStream.CopyToAsync(outputStream);
#else
        await using (
            var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, true)
        )
            await brotliStream.CopyToAsync(outputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
