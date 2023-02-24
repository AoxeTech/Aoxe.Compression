namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        uint quality = 5,
        uint window = 22,
        bool leaveOpen = true)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, leaveOpen);
#endif
        brotliStream.SetQuality(quality);
        brotliStream.SetWindow(window);
        await inputStream.CopyToAsync(brotliStream);
        await inputStream.FlushAsync();
        brotliStream.Flush();
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = true)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen);
#endif
        await brotliStream.CopyToAsync(outputStream);
        await outputStream.FlushAsync();
        brotliStream.Flush();
    }
}