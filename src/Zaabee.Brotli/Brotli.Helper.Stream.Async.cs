namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        uint quality = Quality,
        uint window = Window)
    {
#if NETSTANDARD2_0
        using (var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
#else
        await using (var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
#endif
        {
            brotliStream.SetQuality(quality);
            brotliStream.SetWindow(window);
            await inputStream.CopyToAsync(brotliStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
#if NETSTANDARD2_0
        using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, true))
#else
        await using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, true))
#endif
            await brotliStream.CopyToAsync(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}