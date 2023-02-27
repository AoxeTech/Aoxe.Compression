namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        uint quality = Quality,
        uint window = Window,
        bool leaveOpen = LeaveOpen)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, leaveOpen);
#endif
        brotliStream.SetQuality(quality);
        brotliStream.SetWindow(window);
        await inputStream.CopyToAsync(brotliStream);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = LeaveOpen)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen);
#endif
        await brotliStream.CopyToAsync(outputStream);
    }
}