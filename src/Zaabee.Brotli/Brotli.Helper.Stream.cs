namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        uint quality = 5,
        uint window = 22,
        bool leaveOpen = true)
    {
        using var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, leaveOpen);
        brotliStream.SetQuality(quality);
        brotliStream.SetWindow(window);
        inputStream.CopyTo(brotliStream);
        inputStream.Flush();
        brotliStream.Flush();
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = true)
    {
        using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen);
        brotliStream.CopyTo(outputStream);
        outputStream.Flush();
        brotliStream.Flush();
    }
}